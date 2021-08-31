using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui.Config
{
    /// <summary>
    /// Represents the base class for themes
    /// </summary>
    public abstract class ThemeBase
    {
        #region Properties
        /// <summary>
        /// Represents the name of the specific theme
        /// </summary>
        public abstract string ThemeName { get; }
        /// <summary>
        /// Represents the back color for <see cref="Control"/>s of the specific theme
        /// </summary>
        public abstract Color BackColor { get; }
        /// <summary>
        /// Represents the fore color for <see cref="Control"/>s of the specific theme
        /// </summary>
        public abstract Color ForeColor { get; }
        /// <summary>
        /// Represents the back color for <see cref="Form"/>s of the specific theme
        /// </summary>
        public abstract Color FormColor { get; }
        /// <summary>
        /// Represents the back color for window-like <see cref="Control"/>s (e.g. <see cref="TextBox"/>) of the specific theme
        /// </summary>
        public abstract Color WindowColor { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Themes specified control and it's child controls
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to be themed</param>
        public void SetTheme(Control control)
        {
            //TODO: Implement themeing logic
        }

        /// <summary>
        /// Themes specified control and it's child controls, ignores items in <paramref name="ignoredControls"/> by honoring the specified <see cref="IgnoranceKind"/>
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to be themed</param>
        /// <param name="ignoranceKind">Indicates how items in <paramref name="ignoredControls"/> should be honored</param>
        /// <param name="ignoredControls">An array of items which sould be honored differently than <paramref name="control"/></param>
        public void SetTheme(Control control, IgnoranceKind ignoranceKind, params Control[] ignoredControls)
        {
            //TODO: Implement themeing logic
        }

        /// <summary>
        /// Themes specified control and it's child controls, ignores items in <paramref name="ignoredTypes"/> by honoring the specified <see cref="IgnoranceKind"/>
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to be themed</param>
        /// <param name="ignoranceKind">Indicates how items in <paramref name="ignoredTypes"/> should be honored</param>
        /// <param name="ignoredTypes">An array of items which sould be honored differently than <paramref name="control"/></param>
        public void SetTheme(Control control, IgnoranceKind ignoranceKind, params Type[] ignoredTypes)
        {
            //TODO: Implement themeing logic
        }
        #endregion
    }
}
