using CSharpEssentials.Config;
using static CSharpEssentials.Demo.Config.AppManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEssentials.Demo.Config
{
    /// <summary>
    /// Represents the config manager which controls the data management
    /// </summary>
    internal sealed class ConfigManager
    {
        private static ConfigManager _current = new(new AppDataConfiguration(APP_NAME));
        private IConfigurable _config;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigManager"/> class
        /// </summary>
        /// <param name="config">The config engine to use</param>
        public ConfigManager(IConfigurable config)
        {
            _config = config;
        }
    }
}
