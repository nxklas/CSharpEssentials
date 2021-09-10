using CSharpEssentials.Events;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Gui.Controls.Bases;
using CSharpEssentials.Gui.Helpers;

namespace CSharpEssentials.Gui.Controls
{
    /// <summary>
    /// Represents a <see cref="WatermarkBox"/> with themeing support
    /// </summary>
    public class ThemeableWatermarkBox : WatermarkBox, IThemeable<ThemeableWatermarkBox>
    {
        #region Properties
        /// <summary>
        /// Represents the theme controller
        /// </summary>
        ThemeController IThemeable<ThemeableWatermarkBox>.ThemeController
        {
            get => _themeController;
            set => _themeController = value;
        }
        #endregion

        #region Fields
        private ThemeController _themeController;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemeableTextBox"/> class with default watermark ("Search")
        /// </summary>
        public ThemeableWatermarkBox() : this("Search")
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ThemeableTextBox"/> class with specific watermark
        /// </summary>
        /// <param name="watermarkText"></param>
        public ThemeableWatermarkBox(string watermarkText) : base(watermarkText)
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
