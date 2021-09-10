using CSharpEssentials.Events;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Gui.Helpers;
using System.Windows.Forms;

namespace CSharpEssentials.Gui.Forms
{
    /// <summary>
    /// Represents a <see cref="Form"/> with themeing support
    /// </summary>
    public class ThemeableForm : Form, IThemeable<ThemeableForm>
    {
        #region Properties
        /// <summary>
        /// Represents the theme controller
        /// </summary>
        ThemeController IThemeable<ThemeableForm>.ThemeController
        {
            get => _themeController;
            set => _themeController=value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Theme
        {
            get => _themeController.Theme.Name;
            set => _themeController.Theme = ThemeController.GetThemeByName(value)??_themeController.Theme;
        }
        #endregion

        #region Fields
        /// <summary>
        /// Represents form's <see cref="ThemeController"/>
        /// </summary>
        /// <returns>The <see cref="ThemeController"/></returns>
        protected ThemeController _themeController;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemeableForm"/> class
        /// </summary>
        public ThemeableForm() : base()
        {
            _themeController = ThemeController.Get();
            _themeController.ThemeChanged += (sender, e) => OnThemeChanged(sender,e);
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
