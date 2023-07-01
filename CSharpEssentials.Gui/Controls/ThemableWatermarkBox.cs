namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a <see cref="WatermarkBox"/> with theming support
    /// </summary>
    public class ThemableWatermarkBox : WatermarkBox, IThemable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemableTextBox"/> class with default watermark ("Search")
        /// </summary>
        public ThemableWatermarkBox() : this("Search")
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ThemableTextBox"/> class with specific watermark
        /// </summary>
        /// <param name="watermarkText"></param>
        public ThemableWatermarkBox(string watermarkText) : base(watermarkText)
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
