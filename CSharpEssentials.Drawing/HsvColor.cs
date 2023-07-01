using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using static CSharpEssentials.Drawing.ColorConverter;

namespace CSharpEssentials.Drawing
{
    /// <summary>
    /// Represents a HSV (hue, saturation, value) color.
    /// </summary>
    public readonly struct HsvColor : IEquatable<HsvColor>
    {
        private static readonly Comparer DefaultComparer = new();

        #region Presets
        #region Web colors
        /// <summary>
        /// Represents the HSV color for <see cref="Color.Transparent"/>.
        /// </summary>
        public static HsvColor Transparent => new(Color.Transparent);
        /// <summary>
        /// Represents the HSV color for <see cref="Color.AliceBlue"/>.
        /// </summary>
        public static HsvColor AliceBlue => new(Color.AliceBlue);
        /// <summary>
        /// Represents the HSV color for <see cref="Color.AntiqueWhite"/>.
        /// </summary>
        public static HsvColor AntiqueWhite => new(Color.AntiqueWhite);
        /// <summary>
        /// Represents the HSV color for <see cref="Color.Aqua"/>.
        /// </summary>
        public static HsvColor Aqua => new(Color.Aqua);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Aquamarine => new(Color.Aquamarine);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Azure => new(Color.Azure);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Beige => new(Color.Beige);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Bisque => new(Color.Bisque);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Black => new(Color.Black);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor BlanchedAlmond => new(Color.BlanchedAlmond);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Blue => new(Color.Blue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor BlueViolet => new(Color.BlueViolet);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Brown => new(Color.Brown);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor BurlyWood => new(Color.BurlyWood);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor CadetBlue => new(Color.CadetBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Chartreuse => new(Color.Chartreuse);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Chocolate => new(Color.Chocolate);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Coral => new(Color.Coral);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor CornflowerBlue => new(Color.CornflowerBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Cornsilk => new(Color.Cornsilk);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Crimson => new(Color.Crimson);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Cyan => new(Color.Cyan);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkBlue => new(Color.DarkBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkCyan => new(Color.DarkCyan);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkGoldenrod => new(Color.DarkGoldenrod);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkGray => new(Color.DarkGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkGreen => new(Color.DarkGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkKhaki => new(Color.DarkKhaki);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkMagenta => new(Color.DarkMagenta);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkOliveGreen => new(Color.DarkOliveGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkOrange => new(Color.DarkOrange);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkOrchid => new(Color.DarkOrchid);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkRed => new(Color.DarkRed);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkSalmon => new(Color.DarkSalmon);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkSeaGreen => new(Color.DarkSeaGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkSlateBlue => new(Color.DarkSlateBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkSlateGray => new(Color.DarkSlateGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkTurquoise => new(Color.DarkTurquoise);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DarkViolet => new(Color.DarkViolet);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DeepPink => new(Color.DeepPink);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DeepSkyBlue => new(Color.DeepSkyBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DimGray => new(Color.DimGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor DodgerBlue => new(Color.DodgerBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Firebrick => new(Color.Firebrick);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor FloralWhite => new(Color.FloralWhite);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor ForestGreen => new(Color.ForestGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Fuchsia => new(Color.Fuchsia);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Gainsboro => new(Color.Gainsboro);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor GhostWhite => new(Color.GhostWhite);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Gold => new(Color.Gold);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Goldenrod => new(Color.Goldenrod);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Gray => new(Color.Gray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Green => new(Color.Green);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor GreenYellow => new(Color.GreenYellow);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Honeydew => new(Color.Honeydew);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor HotPink => new(Color.HotPink);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor IndianRed => new(Color.IndianRed);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Indigo => new(Color.Indigo);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Ivory => new(Color.Ivory);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Khaki => new(Color.Khaki);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Lavender => new(Color.Lavender);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LavenderBlush => new(Color.LavenderBlush);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LawnGreen => new(Color.LawnGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LemonChiffon => new(Color.LemonChiffon);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightBlue => new(Color.LightBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightCoral => new(Color.LightCoral);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightCyan => new(Color.LightCyan);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightGoldenrodYellow => new(Color.LightGoldenrodYellow);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightGreen => new(Color.LightGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightGray => new(Color.LightGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightPink => new(Color.LightPink);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightSalmon => new(Color.LightSalmon);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightSeaGreen => new(Color.LightSeaGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightSkyBlue => new(Color.LightSkyBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightSlateGray => new(Color.LightSlateGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightSteelBlue => new(Color.LightSteelBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LightYellow => new(Color.LightYellow);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Lime => new(Color.Lime);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor LimeGreen => new(Color.LimeGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Linen => new(Color.Linen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Magenta => new(Color.Magenta);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Maroon => new(Color.Maroon);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumAquamarine => new(Color.MediumAquamarine);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumBlue => new(Color.MediumBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumOrchid => new(Color.MediumOrchid);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumPurple => new(Color.MediumPurple);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumSeaGreen => new(Color.MediumSeaGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumSlateBlue => new(Color.MediumSlateBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumSpringGreen => new(Color.MediumSpringGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumTurquoise => new(Color.MediumTurquoise);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MediumVioletRed => new(Color.MediumVioletRed);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MidnightBlue => new(Color.MidnightBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MintCream => new(Color.MintCream);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor MistyRose => new(Color.MistyRose);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Moccasin => new(Color.Moccasin);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor NavajoWhite => new(Color.NavajoWhite);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Navy => new(Color.Navy);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor OldLace => new(Color.OldLace);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Olive => new(Color.Olive);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor OliveDrab => new(Color.OliveDrab);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Orange => new(Color.Orange);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor OrangeRed => new(Color.OrangeRed);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Orchid => new(Color.Orchid);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PaleGoldenrod => new(Color.PaleGoldenrod);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PaleGreen => new(Color.PaleGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PaleTurquoise => new(Color.PaleTurquoise);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PaleVioletRed => new(Color.PaleVioletRed);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PapayaWhip => new(Color.PapayaWhip);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PeachPuff => new(Color.PeachPuff);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Peru => new(Color.Peru);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Pink => new(Color.Pink);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Plum => new(Color.Plum);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor PowderBlue => new(Color.PowderBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Purple => new(Color.Purple);
        #endregion
        #region Other colors (system-defined)
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor RebeccaPurple => new(Color.RebeccaPurple);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Red => new(Color.Red);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor RosyBrown => new(Color.RosyBrown);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor RoyalBlue => new(Color.RoyalBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SaddleBrown => new(Color.SaddleBrown);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Salmon => new(Color.Salmon);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SandyBrown => new(Color.SandyBrown);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SeaGreen => new(Color.SeaGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SeaShell => new(Color.SeaShell);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Sienna => new(Color.Sienna);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Silver => new(Color.Silver);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SkyBlue => new(Color.SkyBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SlateBlue => new(Color.SlateBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SlateGray => new(Color.SlateGray);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Snow => new(Color.Snow);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SpringGreen => new(Color.SpringGreen);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor SteelBlue => new(Color.SteelBlue);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Tan => new(Color.Tan);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Teal => new(Color.Teal);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Thistle => new(Color.Thistle);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Tomato => new(Color.Tomato);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Turquoise => new(Color.Turquoise);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Violet => new(Color.Violet);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Wheat => new(Color.Wheat);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor White => new(Color.White);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor WhiteSmoke => new(Color.WhiteSmoke);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor Yellow => new(Color.Yellow);
        /// <summary>
        /// 
        /// </summary>
        public static HsvColor YellowGreen => new(Color.YellowGreen);
        #endregion
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HsvColor"/> struct.
        /// </summary>
        /// <param name="h">The hue which is in between of 0° and 360°.</param>
        /// <param name="s">The saturation which is in between of 0% and 100%.</param>
        /// <param name="v">The value which is in between of 0% and 100%.</param>
        /// <exception cref="ArgumentException">If <paramref name="h"/>, <paramref name="s"/> or <paramref name="v"/> is not inside their bounds.</exception>
        public HsvColor(float h, float s, float v) : this(h, s, v, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HsvColor"/> struct.
        /// </summary>
        /// <param name="h">The hue which is in between of 0° and 360°.</param>
        /// <param name="s">The saturation which is in between of 0% and 100%.</param>
        /// <param name="v">The value which is in between of 0% and 100%.</param>
        /// <param name="a">The alpha component (tansparency) which is in between of 0 and 1.</param>
        /// <exception cref="ArgumentException">If <paramref name="h"/>, <paramref name="s"/>, <paramref name="v"/> or <paramref name="a"/> is not inside their bounds.</exception>
        public HsvColor(float h, float s, float v, float a)
        {
            if (h < 0 || h > 360)
                throw new ArgumentException($"The value of '{nameof(h)}' must be in between of 0 and 360, actual: {h}", nameof(h));

            if (s < 0 || s > 100)
                throw new ArgumentException($"The value of '{nameof(s)}' must be in between of 0 and 100, actual: {s}", nameof(s));

            if (v < 0 || v > 100)
                throw new ArgumentException($"The value of '{nameof(v)}' must be in between of 0 and 100, actual: {v}", nameof(v));

            if (a < 0 || a > 1)
                throw new ArgumentException($"The value of '{nameof(a)}' must be in between of 0 and 1, actual: {a}", nameof(a));

            Hue = h;
            Saturation = s;
            Value = v;
            Alpha = a;
            Name = null;
            KnownColor = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HsvColor"/> struct from an existing <see cref="Color"/> instance.
        /// </summary>
        /// <param name="color">The RGB color that should be represented as HSV.</param>
        public HsvColor(Color color)
        {
            this = color.ToHsv();

            if (!color.IsKnownColor)
                return;

            Name = color.Name;
            KnownColor = color.ToKnownColor();
        }

        /// <summary>
        /// Represents the hue which is in between of 0° and 360°.
        /// </summary>
        public float Hue { get; }
        /// <summary>
        /// Represents the saturation which is in between of 0% and 100%.
        /// </summary>
        public float Saturation { get; }
        /// <summary>
        /// Represents the value which is in between of 0% and 100%.
        /// </summary>
        public float Value { get; }
        /// <summary>
        /// Represents the alpha component (transparency) which is in between of 0 and 1.
        /// </summary>
        public float Alpha { get; }
        /// <summary>
        /// 
        /// </summary>
        public string? Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public KnownColor KnownColor { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsKnownColor() => KnownColor != 0;

        /// <summary>
        /// Gets the string representation of the current instance.
        /// </summary>
        /// <returns>This HSV struct as a string instance.</returns>
        public override string ToString() => ToString(true);

        public string ToString(bool includeAlpha) => $"{nameof(HsvColor)} {(Name != null ? $"[{Name}] " : string.Empty)}[H={Hue}, S={Saturation}, V={Value}{(includeAlpha ? $", A={Alpha}]" : "]")}";
        /// <summary>
        /// Indicates whether this instance and the specified HSV color are equal.
        /// </summary>
        /// <param name="other">The HSV color to compare with this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="other"/> and this instance represent the same value; otherwise, <see langword="false"/>.</returns>
        public bool Equals(HsvColor other) => this == other;

        public bool Equals(Color color) => this == color;

        /// <summary>
        /// Indicates whether this instance and the specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.</returns>
        public override bool Equals([NotNullWhen(true)] object? obj) => (obj is HsvColor other && Equals(other)) || (obj is Color color && Equals(color));

        /// <summary>
        /// Converts the current instance to its <see cref="Color"/> representation.
        /// </summary>
        /// <remarks>NOTE: Color conversions from HSV to RGB are quite accurate; however, small rounding differences might occur.</remarks>
        /// <returns>The RGB color corresponding to this instance.</returns>
        public Color ToRgb() => HsvToRgb(this);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Name != null ? Name.GetHashCode() : HashCode.Combine(Hue, Saturation, Value, Alpha);

        /// <summary>
        /// Determines whether the specified HSV colors have the same value.
        /// </summary>
        /// <param name="left">The first HSV color to compare.</param>
        /// <param name="right">The second HSV color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(HsvColor left, HsvColor right) =>
            left.Hue == right.Hue &&
            left.Saturation == right.Saturation &&
            left.Value == right.Value &&
            left.Alpha == right.Alpha;
        /// <summary>
        /// Determines whether the specified HSV color and the specified RGB color, according to default <see cref="Comparer"/>, have the same value.
        /// </summary>
        /// <param name="left">The HSV color to compare.</param>
        /// <param name="right">The RGB color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(HsvColor left, Color right) => DefaultComparer.Equals(left, right.ToHsv());
        /// <summary>
        /// Determines whether the specified RGB color and the specified HSV color, according to default <see cref="Comparer"/>, have the same value.
        /// </summary>
        /// <param name="left">The RGB color to compare.</param>
        /// <param name="right">The HSV color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Color left, HsvColor right) => right == left;
        /// <summary>
        /// Determines whether the specified HSV colors have the same value.
        /// </summary>
        /// <param name="left">The first HSV color to compare.</param>
        /// <param name="right">The second HSV color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(HsvColor left, HsvColor right) => !(left == right);
        /// <summary>
        /// Determines whether the specified HSV color and the specified RGB color, according to default <see cref="Comparer"/>, do not have the same value.
        /// </summary>
        /// <param name="left">The HSV color to compare.</param>
        /// <param name="right">The RGB color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(HsvColor left, Color right) => !(left == right);
        /// <summary>
        /// Determines whether the specified RGB color and the specified HSV color, according to default <see cref="Comparer"/>, do not have the same value.
        /// </summary>
        /// <param name="left">The RGB color to compare.</param>
        /// <param name="right">The HSV color to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Color left, HsvColor right) => right != left;

        #region Comparer
        /// <summary>
        /// Represents an <see cref="IEqualityComparer{T}"/> implementation to approximately determine "equality" of two <see cref="HsvColor"/> instances using an offset.
        /// </summary>
        public sealed class Comparer : Helpers.ApproximateComparer<HsvColor>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Comparer"/> class with a default offset of 1.
            /// </summary>
            public Comparer() : this(1)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Comparer"/> class with a custom offset.
            /// </summary>
            /// <param name="offset">The offset.</param>
            public Comparer(float offset) : base(offset)
            {
                
            }

            public override bool Equals(HsvColor x, HsvColor y) =>
                Equals(x.Hue, y.Hue) &&
                Equals(x.Saturation, y.Saturation) &&
                Equals(x.Value, y.Value) && x.Alpha == y.Alpha;
        }
        #endregion
    }
}