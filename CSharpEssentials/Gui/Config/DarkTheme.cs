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
        /// Represents the name of the dark theme
        /// </summary>
        public override string Name => "DarkTheme";
        /// <summary>
        /// Represents the friendly name of the dark theme
        /// </summary>
        public override string FriendlyName => "Dark";
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
        public override Color FormColor => Color.FromArgb(255,33, 33, 33);
        /// <summary>
        /// Represents the back color for window-like <see cref="System.Windows.Forms.Control"/>s (e.g. <see cref="System.Windows.Forms.TextBox"/>) of the dark mode
        /// </summary>
        public override Color WindowColor => Color.FromArgb(255, 54, 54, 54);
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
