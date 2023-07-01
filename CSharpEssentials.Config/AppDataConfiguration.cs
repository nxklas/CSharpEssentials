using System;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a config that writes to / reads from the AppData folder
    /// </summary>
    public sealed class AppDataConfiguration : DirectoryConfiguration
    {
        #region Properties
        /// <summary>
        /// Represents the path to the config file in AppData
        /// </summary>
        protected override string Path => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppName, FileName);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="AppDataConfiguration"/> class
        /// </summary>
        public AppDataConfiguration(string appName) : base(appName)
        {

        }
        #endregion
    }
}