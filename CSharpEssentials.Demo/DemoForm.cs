using CSharpEssentials.Gui;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Gui.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEssentials.Demo
{
    /// <summary>
    /// Represents a demo for <see cref="ThemeableForm"/>
    /// </summary>
    internal sealed partial class DemoForm : ThemeableForm
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DemoForm"/> class
        /// </summary>
        public DemoForm()
        {
            InitializeComponent();
            comboBox1.DataSource = ThemeController.GetThemes();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            _themeController.Theme = ThemeController.GetThemeByName(comboBox1.Text);

            //comboBox1 needs an extra theme change call bacause i have not implemented a native themeable version of it yet
            _themeController.Theme.SetTheme(comboBox1);
        }
    }
}
