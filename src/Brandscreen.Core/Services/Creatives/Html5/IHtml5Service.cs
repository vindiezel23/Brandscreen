using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Framework;

namespace Brandscreen.Core.Services.Creatives.Html5
{
    public interface IHtml5Service : IDependency
    {
        Task<Html5ExtractResult> Extract(byte[] file, string path);
    }

    public class Html5Service : IHtml5Service
    {
        public Task<Html5ExtractResult> Extract(byte[] file, string path)
        {
            return Task.Run(() =>
            {
                try
                {
                    return ExtractInternal(file, path);
                }
                catch
                {
                    return new Html5ExtractResult {Success = false, Error = "zip file is invalid"};
                }
            });
        }

        private Html5ExtractResult ExtractInternal(byte[] file, string path)
        {
            using (var ms = new MemoryStream(file))
            using (var archive = new ZipArchive(ms))
            {
                var retVal = new Html5ExtractResult {BasePath = path, Success = false};
                var htmlEntries = archive.Entries.Where(x => x.FullName.EndsWith(".html") && !x.FullName.Contains("/")).ToList();
                if (htmlEntries.Count != 1)
                {
                    retVal.Error = $"{htmlEntries.Count} html file(s) found in the root folder";
                    return retVal;
                }

                // html file
                var htmlEntry = htmlEntries.Single();
                retVal.HtmlPath = htmlEntry.FullName;

                // other files
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                foreach (var entry in archive.Entries)
                {
                    var fullPath = Path.Combine(path, entry.FullName);
                    var fileName = Path.GetFileName(fullPath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        // folder
                        if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
                        continue;
                    }

                    // extract
                    entry.ExtractToFile(fullPath, true);

                    // html file
                    if (entry == htmlEntry) continue; // skip the html file

                    // other files
                    retVal.OtherPaths.Add(entry.FullName);
                }

                retVal.Success = true;
                return retVal;
            }
        }
    }
}