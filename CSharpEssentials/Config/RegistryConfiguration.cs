using static CSharpEssentials.Registry.Helpers.RegistryHelper;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Versioning;
using CSharpEssentials.Diagnostics;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a config that writes to / reads from the Windows Registry
    /// </summary>
    /// <remarks>NOTO: Untested</remarks>
    [SupportedOSPlatform("windows")]
    public sealed class RegistryConfiguration : IConfigurable
    {
        #region Fields
        private string _subKey;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="RegistryConfiguration"/> class
        /// </summary>
        public RegistryConfiguration(string subKey)
        {
            _subKey = subKey;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads the whole Registry config
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="keys">The keys where to get their associated values from</param>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public IImmutableList<KeyValuePair<ConfigKey, string>> Read(out IImmutableList<string> diagnostics, params ConfigKey[] keys)
        {
            IList<KeyValuePair<ConfigKey, string>> values = new List<KeyValuePair<ConfigKey, string>>();
            DiagnosticBag _diagnostics = DiagnosticBag.Builder.Build();

            foreach (ConfigKey current in keys)
            {
                string value = GetValue(_subKey, current.ToString()).ToString();

                if (value == null)
                {
                    _diagnostics.Add_MissingValue(current.ToString());
                    continue;
                }

                values.Add(new KeyValuePair<ConfigKey, string>(current, value));
            }

            diagnostics = _diagnostics.Diagnostics;
            return values.ToImmutableList();
        }

        /// <summary>
        /// Reads the Registry config at the specific config key
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="key">The key where to get it's associated values from</param>
        /// <returns>The value of <paramref name="key"/></returns>
        public string Read(out IImmutableList<string> diagnostics, ConfigKey key)
        {
            string value = GetValue(_subKey, key.ToString()).ToString();
            DiagnosticBag _diagnostics = DiagnosticBag.Builder.Build();

            if (value == null)
            {
                _diagnostics.Add_MissingValue(key.ToString());
            }

            diagnostics = _diagnostics.Diagnostics;
            return value;
        }

        /// <summary>
        /// Writes the whole Registry config
        /// </summary>
        /// <param name="values">The values to write</param>
        public void Write(params KeyValuePair<ConfigKey, string>[] values)
        {
            foreach(KeyValuePair<ConfigKey, string> current in values)
            {
                SetValue(_subKey,current.Key.ToString(), current.Value);
            }
        }

        /// <summary>
        /// Writes a specific value to the Registry config
        /// </summary>
        /// <param name="key">The key where to write it's value</param>
        /// <param name="value">The value to write</param>
        public void Write(ConfigKey key, string value)
        {
            SetValue(_subKey, key.ToString(), value);
        }
        #endregion
    }
}
