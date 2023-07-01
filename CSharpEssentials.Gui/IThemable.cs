using System.ComponentModel;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents the base interface for themable <see cref="Control"/>s
    /// </summary>
    public interface IThemable
    {
        /// <summary>
        /// Exposes control's theme controller
        /// </summary>
        [Browsable(false)]
        ThemeController ThemeController { get; set; }
    }
}
