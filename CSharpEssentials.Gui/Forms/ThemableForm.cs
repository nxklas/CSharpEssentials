﻿using System.ComponentModel;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a <see cref="Form"/> with theming support
    /// </summary>
    public class ThemableForm : Form, IThemable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemableForm"/> class
        /// </summary>
        public ThemableForm() : base()
        {
            ThemeController = Parent is IThemable themable ? themable.ThemeController : ThemeController.Instance;
            ThemeController.ThemeChanged += OnThemeChanged!;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the theme controller
        /// </summary>
        public ThemeController ThemeController { get;set; }

        /// <summary>
        /// 
        /// </summary>
        public string Theme
        {
            get => ThemeController.Theme.Name;
            set => ThemeController.Theme = ThemeController.GetThemeByName(value) ?? ThemeController.DefaultTheme;
        }
        #endregion

        #region Event methods
        /// <summary>
        /// Triggers when <see cref="ThemeController.ThemeChanged"/> occurs
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The data of the event</param>
        public virtual void OnThemeChanged(object sender, PropertyChangedEventArgs<Theme> e)
        {
            ThemeController.Theme.SetTheme(this);
        }
        #endregion
    }
}