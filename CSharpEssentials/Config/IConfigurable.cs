using System.Collections.Immutable;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents the base interface for config classes
    /// </summary>
    public interface IConfigurable
    {
        /// <summary>
        /// Reads the config
        /// </summary>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public IImmutableList<ConfigKey> Read();
        /// <summary>
        /// Writes a set of values to the config
        /// </summary>
        /// <param name="values">The values to write</param>
        public void Write(params ConfigValue[] values);
        /// <summary>
        /// Writes a specific value to the config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(ConfigKey key, string value);
    }
}
