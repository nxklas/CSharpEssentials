using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents the base interface for config classes.
    /// </summary>
    public interface IConfigurable
    {
        /// <summary>
        /// Reads the config at the specified keys.
        /// </summary>
        /// <param name="keys">The keys where to get their associated values from.</param>
        /// <returns>
        /// An <see cref="ImmutableArray{T}"/> of all read values and its keys.
        /// <br>If a value could not be found, its key is associated with <see langword="null"/>.</br>
        /// </returns>
        ImmutableArray<KeyValuePair<string, string?>> Read([DisallowNull] params string[] keys);
        /// <summary>
        /// Reads the config at the specified key.
        /// </summary>
        /// <param name="key">The key where to get its associated value from.</param>
        /// <returns>The value of <paramref name="key"/> or <see langword="null"/> if no value was found.</returns>
        string? Read([DisallowNull] string key);
        /// <summary>
        /// Writes a set of key-value pairs to the config.
        /// </summary>
        /// <param name="keyValues">The key-values pairs to write.</param>
        void Write([DisallowNull] params KeyValuePair<string, string>[] keyValues);
        /// <summary>
        /// Writes a specific key-value pair to the config.
        /// </summary>
        /// <param name="key">The key associated with <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        void Write([DisallowNull] string key, [DisallowNull] string value);
        /// <summary>
        /// Removes a specific key-value pair from the config.
        /// </summary>
        /// <param name="key">The key of the key-value pair to remove.</param>
        /// <returns><see langword="true"/> if <paramref name="key"/> was found and its key-value pair could be removed; otherwise, <see langword="false"/>.</returns>
        bool Remove([DisallowNull] string key);
    }
}