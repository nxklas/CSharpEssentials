using CSharpEssentials.Helpers;
using System;
using System.Collections.Generic;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a controller for gui theming
    /// </summary>
    public sealed class ThemeController
    {
        #region Fields
        private static Dictionary<string, Theme> Themes;
        private Theme _theme;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="ThemeController"/> class and sets the theme to <see cref="LightTheme"/>
        /// </summary>
        public ThemeController() : this(DefaultTheme)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ThemeController"/> class and sets the theme to a specific kind
        /// </summary>
        /// <param name="themeName">The kind of the theme</param>
        public ThemeController(string themeName) : this(GetThemeByName(themeName) ?? DefaultTheme)
        {
        }

        public ThemeController(Theme theme)
        {
            _theme= theme;
        }

        static ThemeController()
        {
            Themes = new();
            Instance = new();
            RegisterTheme();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the theme
        /// </summary>
        public Theme Theme
        {
            get => _theme;
            set
            {
                if (_theme != value)
                {
                    var oldTheme = _theme;
                    _theme = value;
                    ThemeChanged?.Invoke(this, new PropertyChangedEventArgs<Theme>(oldTheme, _theme));
                }
            }
        }
        /// <summary>
        /// Gets the <see cref="ThemeController"/> singleton with the current theme or with default theme (<see cref="LightTheme"/>) if no singleton exists yet
        /// </summary>
        /// <returns>The <see cref="ThemeController"/> singleton</returns>
        public static ThemeController Instance { get; }
        public static Theme DefaultTheme => LightTheme.Instance;
        #endregion

        #region Public methods
        /// <summary>
        /// Gets all themes
        /// </summary>
        /// <returns>All recognized themes</returns>
        public static IEnumerable<Theme> GetThemes() => Themes.Values;

        /// <summary>
        /// Registers <see cref="Themes"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If <see cref="Theme.Name"/> is already registered.</exception>
        private static void RegisterTheme()
        {
            if (Themes == null)
                return;

            foreach (var theme in ReflectiveEnumerator.GetEnumerableOfType<Theme>())
                if (Themes.ContainsKey(theme.Name))
                    throw new ArgumentException($"Theme '{theme.Name}' has already been registered.");
                else
                    Themes.Add(theme.Name, theme);
        }

        /// <summary>
        /// Gets the theme associated with <paramref name="themeName"/>
        /// </summary>
        /// <param name="themeName">The name of the theme to get</param>
        /// <returns>The theme or <see langword="null"/> if no theme was found</returns>
        public static Theme? GetThemeByName(string themeName)
        {
            var theme = (Theme)null!;
            var passed = themeName != null && Themes.TryGetValue(themeName, out theme);

            return passed ? theme : null;
        }

        /// <summary>
        /// Gets the theme associated with <paramref name="themeName"/>
        /// </summary>
        /// <param name="themeName">The name of the theme to get</param>
        /// <returns>The theme or <see cref="DefaultTheme"/> if no theme was found</returns>
        public static Theme GetThemeByNameOrDefault(string themeName) => GetThemeByName(themeName) ?? DefaultTheme;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when <see cref="Theme"/> has changed
        /// </summary>
        public event PropertyChangedEventHandler<Theme> ThemeChanged;
        #endregion
    }
}