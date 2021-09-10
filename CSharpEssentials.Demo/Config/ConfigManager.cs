using CSharpEssentials.Config;
using static CSharpEssentials.Demo.Config.AppManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Events;

namespace CSharpEssentials.Demo.Config
{
    /// <summary>
    /// Represents the config manager which controls the data management
    /// </summary>
    internal sealed class ConfigManager
    {
        public ThemeBase Theme
        {
            get => _theme;
            set
            {
                if(_theme != value)
                {
                    ThemeBase oldTheme = value;
                    _theme = value;
                    ThemeChanged?.Invoke(this, new PropertyChangedEventArgs<ThemeBase>(oldTheme, _theme));
                    _config.Write(new CSharpEssentials.Config.ThemeKey(), _theme.ToString());
                }
            }
        }

        private static ConfigManager _current = new(new AppDataConfiguration(APP_NAME));
        private IConfigurable _config;
        private ThemeBase _theme;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigManager"/> class
        /// </summary>
        /// <param name="config">The config engine to use</param>
        public ConfigManager(IConfigurable config)
        {
            _config = config;
        }

        public event PropertyChangedEventHandler<ThemeBase> ThemeChanged;
    }
}
