using System;
using System.Drawing;
using static CSharpEssentials.Mathematics.MathHelper;

namespace CSharpEssentials.Drawing
{
    /// <summary>
    /// Provides helper methods for converting color values from one format to another.
    /// </summary>
    public static class ColorConverter
    {
        #region HSV
        /// <summary>
        /// Converts a HSV color value to a RGB color value (<see cref="Color"/>).
        /// </summary>
        /// <param name="h">The hue which is in between of 0° to 360°.</param>
        /// <param name="s">The saturation which is in between of 0% to 100%.</param>
        /// <param name="v">The value which is in between of 0% to 100%.</param>
        /// <param name="a">The alpha component (transparency) which is in between of 0 and 1.</param>
        /// <remarks>NOTE: Color conversions from HSV to RGB are quite accurate; however, small rounding differences might occur.</remarks>
        /// <returns>A <see cref="Color"/> instance that represents the specified <paramref name="h"/>, <paramref name="s"/>, <paramref name="v"/> values.</returns>
        public static Color HsvToRgb(float h, float s, float v, float a = 1)
        {
            while (h < 0)
                h += 360;

            while (h >= 360)
                h -= 360;

            s /= 100;
            v /= 100;

            if (s < 0)
                s = 0;
            else if (s > 1)
                s = 1;

            if (v < 0)
                v = 0;
            else if (v > 1)
                v = 1;

            double r1, g1, b1;
            var hi = Math.Floor(h / 60.0);
            var f = (h / 60.0) - hi;
            var p = v * (1 - s);
            var q = v * (1 - s * f);
            var t = v * (1 - s * (1 - f));

            switch (hi)
            {
                case 0:
                case 6:
                    r1 = v;
                    g1 = t;
                    b1 = p;
                    break;
                case 1:
                    r1 = q;
                    g1 = v;
                    b1 = p;
                    break;
                case 2:
                    r1 = p;
                    g1 = v;
                    b1 = t;
                    break;
                case 3:
                    r1 = p;
                    g1 = q;
                    b1 = v;
                    break;
                case 4:
                    r1 = t;
                    g1 = p;
                    b1 = v;
                    break;
                case 5:
                    r1 = v;
                    g1 = p;
                    b1 = q;
                    break;
                default:
                    r1 = g1 = b1 = v;
                    break;
            }

            var _a = Clamp(a * 255.0);
            var r = Clamp(r1 * 255.0);
            var g = Clamp(g1 * 255.0);
            var b = Clamp(b1 * 255.0);

            return Color.FromArgb(_a, r, g, b);
        }

        /// <summary>
        /// Converts a HSV color value to a RGB color value (<see cref="Color"/>).
        /// </summary>
        /// <param name="color">The HSV color to be converted.</param>
        /// <remarks>NOTE: Color conversions from HSV to RGB are quite accurate; however, small rounding differences might occur.</remarks>
        /// <returns>A <see cref="Color"/> instance that represents the specified (HSV) <paramref name="color"/> value.</returns>
        public static Color HsvToRgb(HsvColor color) => HsvToRgb(color.Hue, color.Saturation, color.Value, color.Alpha);
        #endregion

        #region RGB
        /// <summary>
        /// Converts a RGB color value (<see cref="Color"/>) to a HSV color value.
        /// </summary>
        /// <param name="color">The RGB color to be converted.</param>
        /// <remarks>NOTE: Color conversions from RGB to HSV are quite accurate; however, small rounding differences might occur.</remarks>
        /// <returns>A <see cref="HsvColor"/> instance that represents the specified <paramref name="color"/> value.</returns>
        public static HsvColor RgbToHsv(Color color)
        {
            var max = (float)Math.Max(color.R, Math.Max(color.G, color.B));
            var min = (float)Math.Min(color.R, Math.Min(color.G, color.B));
            var h = color.GetHue();
            var s = (max != min && !(color.R == color.G && color.G == color.B)) ? (max - min) / max * 100 : 0f;
            var v = max / 2.55f;
            var a = color.A / 255.0f;

            return new(h, s, v, a);
        }

        /// <summary>
        /// Converts the current instance to its <see cref="HsvColor"/> representation.
        /// </summary>
        /// <param name="color">The RGB color to be converted.</param>
        /// <remarks>NOTE: Color conversions from RGB to HSV are quite accurate; however, small rounding differences might occur.</remarks>
        /// <returns>The HSV color corresponding to this instance.</returns>
        public static HsvColor ToHsv(this Color color) => RgbToHsv(color);
        #endregion
    }
}