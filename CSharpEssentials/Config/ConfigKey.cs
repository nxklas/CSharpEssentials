namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents the base class for config keys
    /// </summary>
    public abstract class ConfigKey
    {
        #region Properties
        /// <summary>
        /// Represents the name of the key
        /// </summary>
        protected abstract string Key { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ConfigKey"/> class
        /// </summary>
        protected ConfigKey()
        {

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the key
        /// </summary>
        /// <returns>The name of the key</returns>
        public override string ToString() => Key;
        #endregion
    }
}
