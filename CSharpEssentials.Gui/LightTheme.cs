using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents <see cref="CSharpEssentials"/>' light mode (standard .NET 7 theme).
    /// </summary>
    public sealed class LightTheme : Theme
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LightTheme"/> class.
        /// </summary>
        public LightTheme() : base()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the name of the light theme.
        /// </summary>
        public override string Name => "LightTheme";
        /// <summary>
        /// Represents the friendly name of the light theme.
        /// </summary>
        public override string FriendlyName => "Light";
        /// <summary>
        /// Represents the fore color for <see cref="Control"/>s of the light theme.
        /// </summary>
        public override Color ForeColor => Color.FromKnownColor(KnownColor.ControlText);
        /// <summary>
        /// Represents the back color for <see cref="Control"/>s of the light theme.
        /// </summary>
        public override Color ControlColor => Color.FromKnownColor(KnownColor.Control);
        /// <summary>
        /// Represents the back color for <see cref="Form"/>s of the light theme.
        /// </summary>
        public override Color FormColor => Color.FromKnownColor(KnownColor.Control);
        /// <summary>
        /// Represents the back color for window-like <see cref="Control"/>s (e.g. <see cref="TextBox"/>) of the light theme.
        /// </summary>
        public override Color WindowColor => Color.FromKnownColor(KnownColor.Window);
        /// <summary>
        /// Represents the back color for <see cref="Button"/>s of the light theme.
        /// </summary>
        public override Color ButtonColor => ControlColor;
        /// <summary>
        /// Represents the light theme.
        /// </summary>
        public static Theme Instance = new LightTheme();
        #endregion
    }
}
