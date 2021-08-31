using CSharpEssentials.Gui.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ThemeController
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ThemeBase Theme
        {
            get => _theme;
            set => _theme = value;
        }
        #endregion

        #region Fields
        private ThemeBase _theme;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemeController"/> class
        /// </summary>
        public ThemeController()
        {

        }
        #endregion
    }
}
