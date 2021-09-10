using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Write appdata read / write logic

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
        protected override string Path => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppName + FileName;
        #endregion

        #region Fields

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="AppDataConfiguration"/> class
        /// </summary>
        public AppDataConfiguration(string appName) : base(appName)
        {

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads the whole AppData config
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="keys">The keys where to get their associated values from</param>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public override IImmutableList<KeyValuePair<ConfigKey, string>> Read(out IImmutableList<string> diagnostics, params ConfigKey[] keys)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the AppData config at the specific config key
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="key">The key where to get it's associated values from</param>
        /// <returns>The value of <paramref name="key"/></returns>
        public override string Read(out IImmutableList<string> diagnostics, ConfigKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the whole AppData config
        /// </summary>
        /// <param name="values">The values to write</param>
        public override void Write(params KeyValuePair<ConfigKey, string>[] values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a specific value to the AppData config
        /// </summary>
        /// <param name="key">The key where to write it's value</param>
        /// <param name="value">The value to write</param>
        public override void Write(ConfigKey key, string value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private methods

        #endregion
    }
}
