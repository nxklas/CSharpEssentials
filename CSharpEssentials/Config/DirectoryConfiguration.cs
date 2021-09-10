using System.Collections.Generic;
using System.Collections.Immutable;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents the base class for configs that write / read in the file-system
    /// </summary>
    public abstract class DirectoryConfiguration : IConfigurable
    {
        #region Properties
        /// <summary>
        /// Represents the path to the config file
        /// </summary>
        protected abstract string Path { get; }
        /// <summary>
        /// Represents the name of the application
        /// </summary>
        protected string AppName => _appName;
        /// <summary>
        /// Represents the name of the config file
        /// </summary>
        protected const string FileName = "\\config.conf";
        #endregion

        #region Fields
        private readonly string _appName;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="DirectoryConfiguration"/> class
        /// </summary>
        /// <param name="appName">The name of the application (the folder name where config is in should use the it)</param>
        protected DirectoryConfiguration(string appName)
        {
            _appName = appName;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads the whole directory config
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="keys">The keys where to get their associated values from</param>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public abstract IImmutableList<KeyValuePair<ConfigKey, string>> Read(out IImmutableList<string> diagnostics, params ConfigKey[] keys);
        /// <summary>
        /// Reads the directory config at the specific config key
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="key">The key where to get it's associated values from</param>
        /// <returns>The value of <paramref name="key"/></returns>
        public abstract string Read(out IImmutableList<string> diagnostics, ConfigKey key);
        /// <summary>
        /// Writes the whole directory config
        /// </summary>
        /// <param name="values">The values to write</param>
        public abstract void Write(params KeyValuePair<ConfigKey, string>[] values);
        /// <summary>
        /// Writes a specific value to the directory config
        /// </summary>
        /// <param name="key">The key where to write it's value</param>
        /// <param name="value">The value to write</param>
        public abstract void Write(ConfigKey key, string value);
        #endregion
    }
}
