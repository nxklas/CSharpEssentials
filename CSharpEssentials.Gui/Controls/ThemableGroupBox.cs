using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a <see cref="ThemableGroupBox"/> with theming support.
    /// </summary>
    public class ThemableGroupBox : GroupBox, IThemable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemableGroupBox"/> class.
        /// </summary>
        /// <param name="watermarkText"></param>
        public ThemableGroupBox() : base()
        {
            ThemeController = Parent is IThemable themable ? themable.ThemeController : ThemeController.Instance;
            ThemeController.ThemeChanged += OnThemeChanged!;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the theme controller
        /// </summary>
        public ThemeController ThemeController { get; set; }
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
