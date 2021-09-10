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
        /// Reads the config
        /// </summary>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public override IImmutableList<ConfigKey> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a set of values to the config
        /// </summary>
        /// <param name="values">The values to write</param>
        public override void Write(params ConfigValue[] values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a specific value to the config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Write(ConfigKey key, string value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private methods

        #endregion
    }
}
