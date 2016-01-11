using System;
using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.FileSystems;
using Brandscreen.Framework;
using NReco.PhantomJS;
using NuGet;
using ILogger = Castle.Core.Logging.ILogger;
using NullLogger = Castle.Core.Logging.NullLogger;

namespace Brandscreen.Core.Services.ScreenCaptures
{
    public interface IScreenCaptureService : IDependency
    {
        Task<byte[]> Capture(string html, int width, int height, string format);
        Task<byte[]> CaptureByFile(string path, int width, int height, string format);
    }

    public class ScreenCaptureService : IScreenCaptureService
    {
        private readonly IAppDataFolderRoot _appDataFolderRoot;

        private static readonly object Sync = new object();

        public ScreenCaptureService(IAppDataFolderRoot appDataFolderRoot)
        {
            _appDataFolderRoot = appDataFolderRoot;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public async Task<byte[]> Capture(string html, int width, int height, string format)
        {
            // process
            var guid = Guid.NewGuid().ToString("N");
            var workingFolder = EnsurePhantomJsWorkingFolder();
            var htmlPath = Path.Combine(workingFolder, $"{guid}.html");
            File.WriteAllText(htmlPath, html); // save as html file and pass to phantom js
            try
            {
                return await CaptureByFile(htmlPath, width, height, format);
            }
            finally
            {
                // clean up html
                File.Delete(htmlPath);
            }
        }

        public async Task<byte[]> CaptureByFile(string htmlPath, int width, int height, string format)
        {
            // phantomJs
            var workingFolder = EnsurePhantomJsWorkingFolder();
            var phantomJs = new PhantomJS
            {
                ToolPath = Path.Combine(workingFolder, @"PhantomJS.2.0.0\tools\phantomjs"), // combine with the nuget package path
                TempFilesPath = workingFolder
            };
            phantomJs.OutputReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // there is no output if generated successfully, using warn to log any error
                    Logger.Warn(args.Data);
                }
            };

            // process
            EnsurePhantomJsExe(phantomJs, workingFolder);
            var jsPath = Path.Combine(phantomJs.ToolPath, @"examples\rasterize.js");
            var outputPath = Path.Combine(workingFolder, $"{Path.GetFileNameWithoutExtension(htmlPath)}-{Guid.NewGuid().ToString("N")}.{format}");
            try
            {
                await phantomJs.RunAsync(jsPath, new[]
                {
                    new Uri(htmlPath).AbsoluteUri, // note: using file:///xxx.html
                    outputPath,
                    $"{width}px*{height}px"
                });

                // result
                return File.Exists(outputPath) ? File.ReadAllBytes(outputPath) : null;
            }
            finally
            {
                // clean up output
                if (File.Exists(outputPath)) File.Delete(outputPath);
            }
        }

        /// <summary>
        /// Downloads PhantomJS package from nuget and unzips it if not exists.
        /// </summary>
        private void EnsurePhantomJsExe(PhantomJS phantomJs, string installPath)
        {
            var filePath = Path.Combine(phantomJs.ToolPath, phantomJs.PhantomJsExeName);
            if (!File.Exists(filePath))
            {
                lock (Sync)
                {
                    if (!File.Exists(filePath))
                    {
                        const string packageId = "PhantomJS";
                        const string version = "2.0.0";
                        var repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
                        var packageManager = new PackageManager(repo, installPath);
                        try
                        {
                            Logger.Info($"downloading {packageId} version {version}");
                            packageManager.InstallPackage(packageId, SemanticVersion.Parse(version));
                            Logger.Info($"downloaded {packageId} version {version}");
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"failed to download {packageId} version {version}", ex);
                            throw;
                        }
                    }
                }
            }
        }

        private string EnsurePhantomJsWorkingFolder()
        {
            var path = Path.Combine(_appDataFolderRoot.RootFolder, "PhantomJs");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }
    }
}