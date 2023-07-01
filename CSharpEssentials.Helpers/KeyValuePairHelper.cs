using System.Collections.Generic;
using System.Linq;

namespace CSharpEssentials.Helpers
{
    /// <summary>
    /// Provides helper methods for manipulating <see cref="KeyValuePair{TKey, TValue}"/>s
    /// </summary>
    public static class KeyValuePairHelper
    {
        /// <summary>
        /// Creates a <see cref="KeyValuePair{TKey, TValue}"/>[] instance with the content of <paramref name="enumerative"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="enumerative">The object to convert.</param>
        /// <returns>The <see cref="KeyValuePair{TKey, TValue}"/>[] equivalent of <paramref name="enumerative"/>.</returns>
        public static KeyValuePair<TKey, TValue>[] ToKeyValuePairArray<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> enumerative)
        {
            var keyValuePairs = new KeyValuePair<TKey, TValue>[enumerative.Count()];
            var i = 0;

            foreach (var current in enumerative)
            {
                i++;
                keyValuePairs[i] = current;
            }

            return keyValuePairs;
        }
    }
}