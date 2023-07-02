using CSharpEssentials.Config;
using CSharpEssentials.Demo.Config;
using CSharpEssentials.Gui;
using System;
using System.Collections;

namespace CSharpEssentials.Demo
{
    /// <summary>
    /// Represents a demo for the <see cref="ThemableForm"/>.
    /// </summary>
    internal sealed partial class DemoForm : ThemableForm
    {
        private readonly ConfigManager _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoForm"/> class.
        /// </summary>
        public DemoForm()
        {
            InitializeComponent();
            comboBox1.DataSource = ThemeController.GetThemes() as IList;
            _config = new ConfigManager(new AppDataConfiguration(AppManager.APP_NAME));
            foreach (var theme in ThemeController.GetThemes())
                comboBox1.Items.Add(theme);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            ThemeController.Theme = ThemeController.GetThemeByName(comboBox1.Text)!;
            //comboBox1 needs an extra theme change call bacause i have not implemented a native themeable version of it yet
            // ThemeController.Theme.SetTheme(comboBox1);
        }
    }
}
