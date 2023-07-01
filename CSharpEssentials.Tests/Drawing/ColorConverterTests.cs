using CSharpEssentials.Drawing;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace CSharpEssentials.Tests.Drawing
{
    /// <summary>
    /// Represents a set of tests for the <see cref="CSharpEssentials.Drawing.ColorConverter"/>.
    /// </summary>
    /// <remarks>NOTE: To allow small rounding differences due to color conversion, we use custom <see cref="IEqualityComparer{T}"/>s to let offsets of +-1 on each color component (alpha excluded).</remarks>
    public sealed class ColorConverterTests
    {
        private static readonly List<(HsvColor, Color)> HsvRgbColors;
        private static readonly RgbComparer RgbComp;

        static ColorConverterTests()
        {
            HsvRgbColors = new()
            {
                Red,
                OrgangeRed,
                Orange,
                OrangeYellow,
                Yellow,
                GreenYellow,
                GrasGreen,
                YellowGreen,
                LightGreen,
                LightBlueGreen,
                SpringGreen,
                GreenCyan,
                Cyan,
                BlueCyan,
                GreenBlue,
                LightGreenBlue,
                Blue,
                Indigo,
                Purple,
                BlueMagenta,
                Magenta,
                RedMagenta,
                BlueRed,
                LightBlueRed,
                Chestnut,
                Olive,
                Green,
                BlueGreen,
                NavyBlue,
                Crimson,
                White,
                Gray,
                Black,
                (HsvColor.Transparent, Color.Transparent),
                (HsvColor.AliceBlue, Color.AliceBlue),
                (HsvColor.AntiqueWhite, Color.AntiqueWhite),
                (HsvColor.Aqua, Color.Aqua),
                (HsvColor.Aquamarine, Color.Aquamarine),
                (HsvColor.Azure, Color.Azure),
                (HsvColor.Beige, Color.Beige),
                (HsvColor.Bisque, Color.Bisque),
                (HsvColor.Black, Color.Black),
                (HsvColor.BlanchedAlmond, Color.BlanchedAlmond),
                (HsvColor.Blue, Color.Blue),
                (HsvColor.BlueViolet, Color.BlueViolet),
                (HsvColor.Brown, Color.Brown),
                (HsvColor.BurlyWood, Color.BurlyWood),
                (HsvColor.CadetBlue, Color.CadetBlue),
                (HsvColor.Chartreuse, Color.Chartreuse),
                (HsvColor.Chocolate, Color.Chocolate),
                (HsvColor.Coral, Color.Coral),
                (HsvColor.CornflowerBlue, Color.CornflowerBlue),
                (HsvColor.Cornsilk, Color.Cornsilk),
                (HsvColor.Crimson, Color.Crimson),
                (HsvColor.Cyan, Color.Cyan),
                (HsvColor.DarkBlue, Color.DarkBlue),
                (HsvColor.DarkCyan, Color.DarkCyan),
                (HsvColor.DarkGoldenrod, Color.DarkGoldenrod),
                (HsvColor.DarkGray, Color.DarkGray),
                (HsvColor.DarkGreen, Color.DarkGreen),
                (HsvColor.DarkKhaki, Color.DarkKhaki),
                (HsvColor.DarkMagenta, Color.DarkMagenta),
                (HsvColor.DarkOliveGreen, Color.DarkOliveGreen),
                (HsvColor.DarkOrange, Color.DarkOrange),
                (HsvColor.DarkOrchid, Color.DarkOrchid),
                (HsvColor.DarkRed, Color.DarkRed),
                (HsvColor.DarkSalmon, Color.DarkSalmon),
                (HsvColor.DarkSeaGreen, Color.DarkSeaGreen),
                (HsvColor.DarkSlateBlue, Color.DarkSlateBlue),
                (HsvColor.DarkSlateGray, Color.DarkSlateGray),
                (HsvColor.DarkTurquoise, Color.DarkTurquoise),
                (HsvColor.DarkViolet, Color.DarkViolet),
                (HsvColor.DeepPink, Color.DeepPink),
                (HsvColor.DeepSkyBlue, Color.DeepSkyBlue),
                (HsvColor.DimGray, Color.DimGray),
                (HsvColor.DodgerBlue, Color.DodgerBlue),
                (HsvColor.Firebrick, Color.Firebrick),
                (HsvColor.FloralWhite, Color.FloralWhite),
                (HsvColor.ForestGreen, Color.ForestGreen),
                (HsvColor.Fuchsia, Color.Fuchsia),
                (HsvColor.Gainsboro, Color.Gainsboro),
                (HsvColor.GhostWhite, Color.GhostWhite),
                (HsvColor.Gold, Color.Gold),
                (HsvColor.Goldenrod, Color.Goldenrod),
                (HsvColor.Gray, Color.Gray),
                (HsvColor.Green, Color.Green),
                (HsvColor.GreenYellow, Color.GreenYellow),
                (HsvColor.Honeydew, Color.Honeydew),
                (HsvColor.HotPink, Color.HotPink),
                (HsvColor.IndianRed, Color.IndianRed),
                (HsvColor.Indigo, Color.Indigo),
                (HsvColor.Ivory, Color.Ivory),
                (HsvColor.Khaki, Color.Khaki),
                (HsvColor.Lavender, Color.Lavender),
                (HsvColor.LavenderBlush, Color.LavenderBlush),
                (HsvColor.LawnGreen, Color.LawnGreen),
                (HsvColor.LemonChiffon, Color.LemonChiffon),
                (HsvColor.LightBlue, Color.LightBlue),
                (HsvColor.LightCoral, Color.LightCoral),
                (HsvColor.LightCyan, Color.LightCyan),
                (HsvColor.LightGoldenrodYellow, Color.LightGoldenrodYellow),
                (HsvColor.LightGreen, Color.LightGreen),
                (HsvColor.LightGray, Color.LightGray),
                (HsvColor.LightPink, Color.LightPink),
                (HsvColor.LightSalmon, Color.LightSalmon),
                (HsvColor.LightSeaGreen, Color.LightSeaGreen),
                (HsvColor.LightSkyBlue, Color.LightSkyBlue),
                (HsvColor.LightSlateGray, Color.LightSlateGray),
                (HsvColor.LightSteelBlue, Color.LightSteelBlue),
                (HsvColor.LightYellow, Color.LightYellow),
                (HsvColor.Lime, Color.Lime),
                (HsvColor.LimeGreen, Color.LimeGreen),
                (HsvColor.Linen, Color.Linen),
                (HsvColor.Magenta, Color.Magenta),
                (HsvColor.Maroon, Color.Maroon),
                (HsvColor.MediumAquamarine, Color.MediumAquamarine),
                (HsvColor.MediumBlue, Color.MediumBlue),
                (HsvColor.MediumOrchid, Color.MediumOrchid),
                (HsvColor.MediumPurple, Color.MediumPurple),
                (HsvColor.MediumSeaGreen, Color.MediumSeaGreen),
                (HsvColor.MediumSlateBlue, Color.MediumSlateBlue),
                (HsvColor.MediumSpringGreen, Color.MediumSpringGreen),
                (HsvColor.MediumTurquoise, Color.MediumTurquoise),
                (HsvColor.MediumVioletRed, Color.MediumVioletRed),
                (HsvColor.MidnightBlue, Color.MidnightBlue),
                (HsvColor.MintCream, Color.MintCream),
                (HsvColor.MistyRose, Color.MistyRose),
                (HsvColor.Moccasin, Color.Moccasin),
                (HsvColor.NavajoWhite, Color.NavajoWhite),
                (HsvColor.Navy, Color.Navy),
                (HsvColor.OldLace, Color.OldLace),
                (HsvColor.Olive, Color.Olive),
                (HsvColor.OliveDrab, Color.OliveDrab),
                (HsvColor.Orange, Color.Orange),
                (HsvColor.OrangeRed, Color.OrangeRed),
                (HsvColor.Orchid, Color.Orchid),
                (HsvColor.PaleGoldenrod, Color.PaleGoldenrod),
                (HsvColor.PaleGreen, Color.PaleGreen),
                (HsvColor.PaleTurquoise, Color.PaleTurquoise),
                (HsvColor.PaleVioletRed, Color.PaleVioletRed),
                (HsvColor.PapayaWhip, Color.PapayaWhip),
                (HsvColor.PeachPuff, Color.PeachPuff),
                (HsvColor.Peru, Color.Peru),
                (HsvColor.Pink, Color.Pink),
                (HsvColor.Plum, Color.Plum),
                (HsvColor.PowderBlue, Color.PowderBlue),
                (HsvColor.Purple, Color.Purple),
                (HsvColor.RebeccaPurple , Color.RebeccaPurple),
                (HsvColor.Red , Color.Red),
                (HsvColor.RosyBrown , Color.RosyBrown),
                (HsvColor.RoyalBlue , Color.RoyalBlue),
                (HsvColor.SaddleBrown , Color.SaddleBrown),
                (HsvColor.Salmon , Color.Salmon),
                (HsvColor.SandyBrown , Color.SandyBrown),
                (HsvColor.SeaGreen , Color.SeaGreen),
                (HsvColor.SeaShell , Color.SeaShell),
                (HsvColor.Sienna , Color.Sienna),
                (HsvColor.Silver , Color.Silver),
                (HsvColor.SkyBlue , Color.SkyBlue),
                (HsvColor.SlateBlue , Color.SlateBlue),
                (HsvColor.SlateGray , Color.SlateGray),
                (HsvColor.Snow , Color.Snow),
                (HsvColor.SpringGreen , Color.SpringGreen),
                (HsvColor.SteelBlue , Color.SteelBlue),
                (HsvColor.Tan , Color.Tan),
                (HsvColor.Teal , Color.Teal),
                (HsvColor.Thistle , Color.Thistle),
                (HsvColor.Tomato , Color.Tomato),
                (HsvColor.Turquoise , Color.Turquoise),
                (HsvColor.Violet , Color.Violet),
                (HsvColor.Wheat , Color.Wheat),
                (HsvColor.White , Color.White),
                (HsvColor.WhiteSmoke , Color.WhiteSmoke),
                (HsvColor.Yellow , Color.Yellow),
                (HsvColor.YellowGreen , Color.YellowGreen)
            };
            RgbComp = new();
        }

        #region Color presets from Wikipedia https://de.wikipedia.org/wiki/HSV-Farbraum#Transformation_von_HSV/HSL_und_RGB, called on Feb 22, 2023, at 23:28
        private static (HsvColor, Color) Red => (new(0, 100, 100), FromRgb(100, 0, 0));
        private static (HsvColor, Color) OrgangeRed => (new(15, 100, 100), FromRgb(100, 25, 0));
        private static (HsvColor, Color) Orange => (new(30, 100, 100), FromRgb(100, 50, 0));
        private static (HsvColor, Color) OrangeYellow => (new(45, 100, 100), FromRgb(100, 75, 0));
        private static (HsvColor, Color) Yellow => (new(60, 100, 100), FromRgb(100, 100, 0));
        private static (HsvColor, Color) GreenYellow => (new(75, 100, 100), FromRgb(75, 100, 0));
        private static (HsvColor, Color) GrasGreen => (new(90, 100, 100), FromRgb(50, 100, 0));
        private static (HsvColor, Color) YellowGreen => (new(105, 100, 100), FromRgb(25, 100, 0));
        private static (HsvColor, Color) LightGreen => (new(120, 100, 100), FromRgb(0, 100, 0));
        private static (HsvColor, Color) LightBlueGreen => (new(135, 100, 100), FromRgb(0, 100, 25));
        private static (HsvColor, Color) SpringGreen => (new(150, 100, 100), FromRgb(0, 100, 50));
        private static (HsvColor, Color) GreenCyan => (new(165, 100, 100), FromRgb(0, 100, 75));
        private static (HsvColor, Color) Cyan => (new(180, 100, 100), FromRgb(0, 100, 100));
        private static (HsvColor, Color) BlueCyan => (new(195, 100, 100), FromRgb(0, 75, 100));
        private static (HsvColor, Color) GreenBlue => (new(210, 100, 100), FromRgb(0, 50, 100));
        private static (HsvColor, Color) LightGreenBlue => (new(225, 100, 100), FromRgb(0, 25, 100));
        private static (HsvColor, Color) Blue => (new(240, 100, 100), FromRgb(0, 0, 100));
        private static (HsvColor, Color) Indigo => (new(255, 100, 100), FromRgb(25, 0, 100));
        private static (HsvColor, Color) Purple => (new(270, 100, 100), FromRgb(50, 0, 100));
        private static (HsvColor, Color) BlueMagenta => (new(285, 100, 100), FromRgb(75, 0, 100));
        private static (HsvColor, Color) Magenta => (new(300, 100, 100), FromRgb(100, 0, 100));
        private static (HsvColor, Color) RedMagenta => (new(315, 100, 100), FromRgb(100, 0, 75));
        private static (HsvColor, Color) BlueRed => (new(330, 100, 100), FromRgb(100, 0, 50));
        private static (HsvColor, Color) LightBlueRed => (new(345, 100, 100), FromRgb(100, 0, 25));
        private static (HsvColor, Color) Chestnut => (new(0, 100, 50), FromRgb(50, 0, 0));
        private static (HsvColor, Color) Olive => (new(60, 100, 50), FromRgb(50, 50, 0));
        private static (HsvColor, Color) Green => (new(120, 100, 50), FromRgb(0, 50, 0));
        private static (HsvColor, Color) BlueGreen => (new(180, 100, 50), FromRgb(0, 50, 50));
        private static (HsvColor, Color) NavyBlue => (new(240, 100, 50), FromRgb(0, 0, 50));
        private static (HsvColor, Color) Crimson => (new(300, 100, 50), FromRgb(50, 0, 50));
        private static (HsvColor, Color) White => (new(0, 0, 100), FromRgb(100, 100, 100));
        private static (HsvColor, Color) Gray => (new(0, 0, 50), FromRgb(50, 50, 50));
        private static (HsvColor, Color) Black => (new(0, 0, 0), FromRgb(0, 0, 0));
        #endregion

        [Theory]
        [MemberData(nameof(GetHsvRgbColors))]
        public void HsvColorConverterComputesCorrectRgbColor(HsvColor hsv, Color rgb)
        {
            var convertedRgb = hsv.ToRgb();
            Assert.Equal(rgb, convertedRgb, RgbComp);
        }

        [Theory]
        [MemberData(nameof(GetHsvRgbColors))]
        public void RgbColorConverterComputesCorrectHsvColor(HsvColor hsv, Color rgb) => Assert.True(hsv == rgb);

        public static IEnumerable<object[]> GetHsvRgbColors()
        {
            foreach (var hsvRgb in HsvRgbColors)
                yield return new object[] { hsvRgb.Item1, hsvRgb.Item2 };
        }

        /// <summary>
        /// Gets a RGB color with max alpha value from the specified values.
        /// </summary>
        /// <param name="r">The red component which is represented in percent.</param>
        /// <param name="g">The green component which is represented in percent.</param>
        /// <param name="b">The blue component which is represented in percent.</param>
        /// <returns>A <see cref="Color"/> that represents the specified <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> values.</returns>
        private static Color FromRgb(int r, int g, int b)
        {
            r = (int)(r * 2.55f);
            g = (int)(g * 2.55f);
            b = (int)(b * 2.55f);
            return Color.FromArgb(r, g, b);
        }

        #region Comparer
        private readonly struct RgbComparer : IEqualityComparer<Color>
        {
            public bool Equals(Color x, Color y) => Equals(x.R, y.R, 1) && Equals(x.G, y.G, 1) && Equals(x.B, y.B, 1);

            public int GetHashCode([System.Diagnostics.CodeAnalysis.DisallowNull] Color obj) => obj.GetHashCode();

            private static bool Equals(byte x, byte y, byte offset) => x >= y - offset && x <= y + offset;
        }
        #endregion
    }
}