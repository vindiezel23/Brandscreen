using System;
using System.IO;
using Brandscreen.Framework;

namespace Brandscreen.Core.FileSystems
{
    /// <summary>
    /// Abstraction over the root location of "~/App_Data", mainly to enable
    /// unit testing of AppDataFolder.
    /// </summary>
    public interface IAppDataFolderRoot : ISingletonDependency
    {
        /// <summary>
        /// Virtual path of root ("~/App_Data")
        /// </summary>
        string RootPath { get; }

        /// <summary>
        /// Physical path of root (typically: MapPath(RootPath))
        /// </summary>
        string RootFolder { get; }
    }

    public class AppDataFolderRoot : IAppDataFolderRoot
    {
        public string RootPath => "~/App_Data";

        public string RootFolder => AppDomain.CurrentDomain.GetData("DataDirectory") as string ?? Path.GetTempPath();
    }
}