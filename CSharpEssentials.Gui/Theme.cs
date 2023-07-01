using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents the base class for themes.
    /// </summary>
    public abstract class Theme
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        protected Theme()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the name of the current theme.
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Represents the friendly name of the current theme.
        /// </summary>
        public abstract string FriendlyName { get; }
        /// <summary>
        /// Represents the fore color for <see cref="Control"/>s of the current theme.
        /// </summary>
        public abstract Color ForeColor { get; }
        /// <summary>
        /// Represents the back color for <see cref="Control"/>s of the current theme.
        /// </summary>
        public abstract Color ControlColor { get; }
        /// <summary>
        /// Represents the back color for <see cref="Form"/>s of the current theme.
        /// </summary>
        public abstract Color FormColor { get; }
        /// <summary>
        /// Represents the back color for window-like <see cref="Control"/>s (e.g. <see cref="TextBox"/>) of the current theme.
        /// </summary>
        public abstract Color WindowColor { get; }
        /// <summary>
        /// Represents the back color for <see cref="Button"/>s of the current theme.
        /// </summary>
        public abstract Color ButtonColor { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Themes the specified control.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to be themed.</param>
        public void SetTheme(Control control)
        {
            control.ForeColor = ForeColor;

            if (control is Form)
            {
                control.BackColor = FormColor;
                return;
            }
            else if(control is ComboBox box)
            {
                if (box.DropDownStyle == ComboBoxStyle.DropDownList)
                {

                }
                control.BackColor = WindowColor;
                return;
            }
            else if (control is TextBox ||
                control is ListBox)
            {
                control.BackColor = WindowColor;
                return;
            }
            else if (control is Button btn)
            {
                control.BackColor = ButtonColor;
                if (this == LightTheme.Instance)
                    btn.UseVisualStyleBackColor = true;
                return;
            }
            else if (control is GroupBox)
                return;
               

            control.BackColor = ControlColor;
        }

        /// <summary>
        /// Themes the specified item.
        /// </summary>
        /// <param name="item">The <see cref="ToolStripItem"/> to be themed.</param>
        public void SetTheme(ToolStripItem item)
        {
            item.ForeColor = ForeColor;
            item.BackColor = ControlColor;
        }

        /// <summary>
        /// Themes the specified strip.
        /// </summary>
        /// <param name="strip">The <see cref="ToolStrip"/> to be themed.</param>
        public void SetTheme(ToolStrip strip)
        {
            strip.ForeColor = ForeColor;
            strip.BackColor = ControlColor;
        }

        /// <summary>
        /// Gets the name of the current theme.
        /// </summary>
        /// <returns>The name of the theme.</returns>
        public override string ToString() => Name;
        #endregion
    }
}