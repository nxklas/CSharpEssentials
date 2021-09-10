using CSharpEssentials.Events;
using CSharpEssentials.Gui.Config;
using CSharpEssentials.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a controller for gui themeing
    /// </summary>
    public sealed class ThemeController
    {
        #region Properties
        /// <summary>
        /// Represents the theme
        /// </summary>
        /// <returns>The current theme</returns>
        public ThemeBase Theme
        {
            get => _theme;
            set
            {
                if (_theme != value)
                {
                    ThemeBase oldTheme = _theme;
                    _theme = value;
                    ThemeChanged?.Invoke(this, new PropertyChangedEventArgs<ThemeBase>(oldTheme, _theme));
                }
            }
        }
        #endregion

        #region Fields
        private static ThemeController _current;
        private static Dictionary<string, ThemeBase> _themes;
        private ThemeBase _theme;
        #endregion

        #region Constructors and singleton getters
        static ThemeController()
        {
            _themes = new();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ThemeController"/> class and sets the theme to <see cref="LightTheme"/>
        /// </summary>
        public ThemeController() : this("LightTheme")
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ThemeController"/> class and sets the theme to a specific kind
        /// </summary>
        /// <param name="themeName">The kind of the theme</param>
        public ThemeController(string themeName)
        {
            ReflectiveEnumerator.GetEnumerableOfType<ThemeBase>(null);
            _theme = GetThemeByName(themeName);
        }

        /// <summary>
        /// Gets the <see cref="ThemeController"/> singleton with the current theme or with default theme (<see cref="LightTheme"/>) if no singleton exists yet
        /// </summary>
        /// <returns>The <see cref="ThemeController"/> singleton</returns>
        public static ThemeController Get()
        {
            if (_current == null)
            {
                _current = new();
            }

            return _current;
        }

        /// <summary>
        /// Gets the <see cref="ThemeController"/> singleton with a specific theme
        /// </summary>
        /// <param name="theme">The specific theme</param>
        /// <returns>The <see cref="ThemeController"/> singleton</returns>
        public static ThemeController Get(ThemeBase theme)
        {
            if (_current == null)
            {
                _current = new(theme.Name);
            }
            else //if (_current.Theme != theme)
            {
                _current.Theme = theme;
            }

            return _current;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets all themes
        /// </summary>
        /// <returns>All recognized themes</returns>
        public static IEnumerable<ThemeBase> GetThemes()
        {
            return ReflectiveEnumerator.GetEnumerableOfType<ThemeBase>(null);
        }

        /// <summary>
        /// Registers <paramref name="theme"/>
        /// </summary>
        /// <param name="theme">The theme to register</param>
        /// <exception cref="ArgumentException">If <see cref="ThemeBase.Name"/> is already registered</exception>
        public static void RegisterTheme(ThemeBase theme)
        {
            //if (_themes.ContainsKey(theme.Name))
            //{
            //    throw new ArgumentException($"Theme '{theme.Name}' is already registered", nameof(theme));
            //}

            if (!_themes.ContainsKey(theme.Name))
            {
                _themes.Add(theme.Name, theme);
            }
        }

        /// <summary>
        /// Gets the theme associated with <paramref name="themeName"/>
        /// </summary>
        /// <param name="themeName">The name of the theme to get</param>
        /// <returns>The theme or <see langword="null"/> if no theme was found</returns>
        public static ThemeBase GetThemeByName(string themeName)
        {
            return _themes.GetValueOrDefault(themeName, null);
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when <see cref="Theme"/> has changed
        /// </summary>
        public event PropertyChangedEventHandler<ThemeBase> ThemeChanged;
        #endregion
    }
}
