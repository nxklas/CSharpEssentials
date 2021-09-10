using System.Drawing;

namespace CSharpEssentials.Gui.Config
{
    /// <summary>
    /// Represents <see cref="CSharpEssentials"/>' dark mode
    /// </summary>
    public sealed class DarkTheme : ThemeBase
    {
        #region Properties
        /// <summary>
        /// Represents the name of the specific theme
        /// </summary>
        public override string Name => "DarkTheme";
        /// <summary>
        /// Represents the back color for <see cref="System.Windows.Forms.Control"/>s of the dark mode
        /// </summary>
        public override Color BackColor => Color.FromKnownColor(KnownColor.ControlDark);
        /// <summary>
        /// Represents the fore color for <see cref="System.Windows.Forms.Control"/>s of the dark mode
        /// </summary>
        public override Color ForeColor => Color.White;
        /// <summary>
        /// Represents the back color for <see cref="System.Windows.Forms.Form"/>s of the dark mode
        /// </summary>
        public override Color FormColor => Color.FromKnownColor(KnownColor.ControlDarkDark);
        /// <summary>
        /// Represents the back color for window-like <see cref="System.Windows.Forms.Control"/>s (e.g. <see cref="System.Windows.Forms.TextBox"/>) of the dark mode
        /// </summary>
        public override Color WindowColor => Color.FromKnownColor(KnownColor.ControlDark);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="DarkTheme"/> class
        /// </summary>
        public DarkTheme() : base()
        {
        }
        #endregion
    }
}
