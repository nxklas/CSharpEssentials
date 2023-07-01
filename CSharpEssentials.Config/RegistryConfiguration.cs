using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using static CSharpEssentials.Helpers.RegistryHelper;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a config that writes to / reads from the Windows Registry.
    /// </summary>
    /// <remarks>NOTE: Untested</remarks>
    [SupportedOSPlatform("windows")]
    public sealed class RegistryConfiguration : IConfigurable
    {
        #region Fields
        private string _subKey;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryConfiguration"/> class.
        /// </summary>
        /// <param name="subKey">The name of the subkey.</param>
        public RegistryConfiguration(string subKey)
        {
            _subKey = subKey;
        }
        #endregion

        #region Public methods
        public ImmutableArray<KeyValuePair<string, string?>> Read([DisallowNull] params string[] keys)
        {
            var values = ImmutableArray.CreateBuilder<KeyValuePair<string, string?>>();

            foreach (var key in keys)
            {
                var value = Read(key);

                    values.Add(new KeyValuePair<string, string?>(key, value));
            }

            return values.ToImmutable();
        }

        public string? Read([DisallowNull] string key)
        {
            var value = GetValue(_subKey, key)?.ToString();

            return value;
        }

        public void Write([DisallowNull] params KeyValuePair<string, string>[] values)
        {
            foreach (var value in values)
                Write(value.Key, value.Value);
        }

        public void Write([DisallowNull] string key, [DisallowNull] string value) => SetValue(_subKey, key, value);

        public bool Remove([DisallowNull] string key) => RemoveValue(_subKey, key);
        #endregion
    }
}