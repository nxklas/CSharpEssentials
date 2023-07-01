namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a set of options for <see cref="Theme.SetTheme(System.Windows.Forms.Control)"/> methods
    /// </summary>
    public enum IgnoranceKind
    {
        /// <summary>
        /// Indicates that a <see cref="System.Windows.Forms.Control"/> will be completely ignored by themer
        /// </summary>
        Completely,
        /// <summary>
        /// Indicates that the themer will only ignore the back color of a <see cref="System.Windows.Forms.Control"/>
        /// </summary>
        BackColorOnly,
        /// <summary>
        /// Indicates that the themer will only ignore the fore color of a <see cref="System.Windows.Forms.Control"/>
        /// </summary>
        ForeColorOnly
    }
}
