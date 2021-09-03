using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpEssentials.Gui.Helpers
{
    /// <summary>
    /// Represents the base interface for themeable <see cref="Control"/>s
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the control</typeparam>
    public interface IThemeable<T> where T : Control
    {
        /// <summary>
        /// Exposes control's theme controller
        /// </summary>
        [Browsable(false)]
        protected ThemeController ThemeController { get; set; }
    }
}
