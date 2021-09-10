namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a key/value pair to be written / read by a <see cref="Config.IConfigurable"/>
    /// </summary>
    public sealed class ConfigValue
    {
        #region Properties
        /// <summary>
        /// Represents the key in the config
        /// </summary>
        public ConfigKey Key => _key;
        /// <summary>
        /// Represents the <see cref="Key"/>'s value
        /// </summary>
        public string Value => _value;
        #endregion

        #region Fields
        private readonly ConfigKey _key;
        private readonly string _value;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ConfigValue"/> class
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public ConfigValue(ConfigKey key, string value)
        {
            _key = key;
            _value = value;
        }
        #endregion
    }
}
