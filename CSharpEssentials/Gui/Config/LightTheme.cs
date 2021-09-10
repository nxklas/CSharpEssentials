using System.Drawing;

namespace CSharpEssentials.Gui.Config
{
    /// <summary>
    /// Represents <see cref="CSharpEssentials"/>' light mode (Standard .NET 5 theme)
    /// </summary>
    public sealed class LightTheme : ThemeBase
    {
        #region Properties
        /// <summary>
        /// Represents the name of the light theme
        /// </summary>
        public override string Name => "LightTheme";
        /// <summary>
        /// Represents the name of the light theme
        /// </summary>
        public override string FriendlyName => "Light";
        /// <summary>
        /// Represents the back color for <see cref="System.Windows.Forms.Control"/>s of the light mode
        /// </summary>
        public override Color BackColor => Color.FromKnownColor(KnownColor.Control);
        /// <summary>
        /// Represents the fore color for <see cref="System.Windows.Forms.Control"/>s of the light mode
        /// </summary>
        public override Color ForeColor => Color.FromKnownColor(KnownColor.ControlText);
        /// <summary>
        /// Represents the back color for <see cref="System.Windows.Forms.Form"/>s of the dark mode
        /// </summary>
        public override Color FormColor => Color.FromKnownColor(KnownColor.Control);
        /// <summary>
        /// Represents the back color for window-like <see cref="System.Windows.Forms.Control"/>s (e.g. <see cref="System.Windows.Forms.TextBox"/>) of the light mode
        /// </summary>
        public override Color WindowColor => Color.FromKnownColor(KnownColor.Window);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="LightTheme"/> class
        /// </summary>
        public LightTheme() : base()
        {
        }
        #endregion
    }
}
