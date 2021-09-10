using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Write registry read / write logic

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a config that writes to / reads from the Windows Registry
    /// </summary>
    public sealed class RegistryConfiguration : IConfigurable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="RegistryConfiguration"/> class
        /// </summary>
        public RegistryConfiguration()
        {

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads the config
        /// </summary>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public IImmutableList<ConfigKey> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a set of values to the config
        /// </summary>
        /// <param name="values">The values to write</param>
        public void Write(params ConfigValue[] values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a specific value to the config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(ConfigKey key, string value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
