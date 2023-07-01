using CSharpEssentials.Config;
using CSharpEssentials.Gui;

namespace CSharpEssentials.Demo.Config
{
    /// <summary>
    /// Represents the config manager which controls the data management
    /// </summary>
    internal sealed class ConfigManager
    {
        private IConfigurable _config;
        private Theme _theme;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigManager"/> class
        /// </summary>
        /// <param name="config">The config engine to use</param>
        public ConfigManager(IConfigurable config)
        {
            _config = config;
        }

        public Theme Theme
        {
            get => _theme;
            set
            {
                if (_theme != value)
                {
                    var oldTheme = _theme;
                    _theme = value;
                    ThemeChanged?.Invoke(this, new PropertyChangedEventArgs<Theme>(oldTheme, _theme));
                    _config.Write("Theme", _theme.ToString());
                }
            }
        }
        public event PropertyChangedEventHandler<Theme> ThemeChanged;
    }
}
