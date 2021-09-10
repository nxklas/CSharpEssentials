using CSharpEssentials.Config;

namespace CSharpEssentials.Demo.Config
{
    /// <summary>
    /// Represents the config key value the theme
    /// </summary>
    public sealed class ThemeKey : ConfigKey
    {
        /// <summary>
        /// The theme key
        /// </summary>
        protected override string Key => "Theme";

        /// <summary>
        /// Initializes a new instance of <see cref="ThemeKey"/> class
        /// </summary>
        public ThemeKey() : base()
        {

        }
    }
}
