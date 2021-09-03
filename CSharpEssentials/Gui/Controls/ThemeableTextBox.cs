using CSharpEssentials.Events;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEssentials.Gui.Controls
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> with themeing support
    /// </summary>
    public class ThemeableTextBox : TextBox, IThemeable<ThemeableTextBox>
    {
        #region Properties
        /// <summary>
        /// Represents the theme controller
        /// </summary>
        ThemeController IThemeable<ThemeableTextBox>.ThemeController
        {
            get => _themeController;
            set => _themeController=value;
        }
        #endregion

        #region Fields
        private ThemeController _themeController;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemeableTextBox"/> class
        /// </summary>
        public ThemeableTextBox() : base()
        {
            _themeController = ThemeController.Get();
            _themeController.ThemeChanged += (sender, e) => OnThemeChanged(sender, e);
        }
        #endregion

        #region Event methods
        /// <summary>
        /// Triggers when <see cref="ThemeController.ThemeChanged"/> occurs
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The data of the event</param>
        public virtual void OnThemeChanged(object sender, PropertyChangedEventArgs<ThemeBase> e)
        {
            _themeController.Theme.SetTheme(this);
        }
        #endregion
    }
}
