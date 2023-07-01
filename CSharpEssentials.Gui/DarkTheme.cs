using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents <see cref="CSharpEssentials"/>' dark mode.
    /// </summary>
    public sealed class DarkTheme : Theme
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DarkTheme"/> class.
        /// </summary>
        public DarkTheme() : base()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the name of the dark theme.
        /// </summary>
        public override string Name => "DarkTheme";
        /// <summary>
        /// Represents the friendly name of the dark theme.
        /// </summary>
        public override string FriendlyName => "Dark";
        /// <summary>
        /// Represents the fore color for <see cref="Control"/>s of the dark theme.
        /// </summary>
        public override Color ForeColor => Color.White;
        /// <summary>
        /// Represents the back color for <see cref="Control"/>s of the dark theme.
        /// </summary>
        public override Color ControlColor => Color.FromKnownColor(KnownColor.ControlDark);
        /// <summary>
        /// Represents the back color for <see cref="Form"/>s of the dark theme.
        /// </summary>
        public override Color FormColor => Color.FromArgb(33, 33, 33);
        /// <summary>
        /// Represents the back color for window-like <see cref="Control"/>s (e.g. <see cref="TextBox"/>) of the dark theme.
        /// </summary>
        public override Color WindowColor => Color.FromArgb(54, 54, 54);
        /// <summary>
        /// Represents the back color for <see cref="Button"/>s of the dark theme.
        /// </summary>
        public override Color ButtonColor => FormColor;
        /// <summary>
        /// Represents the dark theme.
        /// </summary>
        public static Theme Instance = new DarkTheme();
        #endregion
    }
}
