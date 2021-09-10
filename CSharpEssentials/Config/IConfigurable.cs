using System.Collections.Generic;
using System.Collections.Immutable;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents the base interface for config classes
    /// </summary>
    public interface IConfigurable
    {
        /// <summary>
        /// Reads the whole config
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="keys">The keys where to get their associated values from</param>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public IImmutableList<KeyValuePair<ConfigKey, string>> Read(out IImmutableList<string> diagnostics, params ConfigKey[] keys);
        /// <summary>
        /// Reads the config at the specific config key
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="key">The key where to get it's associated values from</param>
        /// <returns>The value of <paramref name="key"/></returns>
        public string Read(out IImmutableList<string> diagnostics, ConfigKey key);
        /// <summary>
        /// Writes the whole config
        /// </summary>
        /// <param name="values">The values to write</param>
        public void Write(params KeyValuePair<ConfigKey, string>[] values);
        /// <summary>
        /// Writes a specific value to the config
        /// </summary>
        /// <param name="key">The key where to write it's value</param>
        /// <param name="value">The value to write</param>
        public void Write(ConfigKey key, string value);
    }
}
