<<<<<<< Updated upstream
﻿using CSharpEssentials.Gui;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Gui.Forms;
=======
﻿using CSharpEssentials.Config;
using CSharpEssentials.Demo.Config;
using CSharpEssentials.Gui;
>>>>>>> Stashed changes
using System;

namespace CSharpEssentials.Demo
{
    /// <summary>
    /// Represents a demo for the <see cref="ThemableForm"/>.
    /// </summary>
    internal sealed partial class DemoForm : ThemableForm
    {
<<<<<<< Updated upstream
=======
        private readonly ConfigManager _config;

>>>>>>> Stashed changes
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoForm"/> class.
        /// </summary>
        public DemoForm()
        {
            InitializeComponent();
<<<<<<< Updated upstream
            comboBox1.DataSource = ThemeController.GetThemes();
=======
            _config = new ConfigManager(new AppDataConfiguration(AppManager.APP_NAME));
            foreach(var theme in ThemeController.GetThemes())
                comboBox1.Items.Add(theme);
            comboBox1.SelectedIndex= 0;
>>>>>>> Stashed changes
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            _themeController.Theme = ThemeController.GetThemeByName(comboBox1.Text);

            //comboBox1 needs an extra theme change call bacause i have not implemented a native themeable version of it yet
            _themeController.Theme.SetTheme(comboBox1);
=======
            ThemeController.Theme = ThemeController.GetThemeByName(comboBox1.Text)!;
>>>>>>> Stashed changes
        }
    }
}
