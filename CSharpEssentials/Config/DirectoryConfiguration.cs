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
        /// Reads the config
        /// </summary>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public abstract IImmutableList<ConfigKey> Read();
        /// <summary>
        /// Writes a set of values to the config
        /// </summary>
        /// <param name="values">The values to write</param>
        public abstract void Write(params ConfigValue[] values);
        /// <summary>
        /// Writes a specific value to the config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract void Write(ConfigKey key, string value);
        #endregion
    }
}
