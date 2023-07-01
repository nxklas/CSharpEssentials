using static System.Math;

namespace CSharpEssentials.Mathematics
{
    public static class MathHelper
    {        
        /// <summary>
        /// Represents a value that converts an angle in degreese to a radian angle
        /// </summary>
        public const double DegToRad = PI / 180.0;
        /// <summary>
        /// Represents a value that converts an angle in radian to a degreese angle
        /// </summary>
        public const double RadToDeg = 180.0 / PI;

        /// <summary>
        /// Ensures that the specified value <paramref name="i"/> is between 0 or 255.
        /// </summary>
        /// <param name="i">The value to be checked.</param>
        /// <returns>The value <paramref name="i"/> as an <see cref="int"/> instance which is between 0 or 255.</returns>
        public static int Clamp(double i) => Clamp(i, 0, 255);

        /// <summary>
        /// Ensures that the specified value <paramref name="i"/> is between the specified values <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="i">The value to be checked.</param>
        /// <param name="min">The minumum value of <paramref name="i"/>.</param>
        /// <param name="max">The maximum value of <paramref name="i"/>.</param>
        /// <returns>The value <paramref name="i"/> as an <see cref="int"/> instance which is between <paramref name="min"/> or <paramref name="max"/>.</returns>
        public static int Clamp(double i, int min, int max)
        {
            if (i < min)
                return min;

            if (i > max)
                return max;

            return (int)Round(i);
        }

        /// <summary>
        /// Re-maps a value from one range to another
        /// </summary>
        /// <param name="value">The value to be re-mapped</param>
        /// <param name="start1">The lower bound of the value's current range</param>
        /// <param name="stop1">The upper bound of the value's current range</param>
        /// <param name="start2">The lower bound of the value's target range</param>
        /// <param name="stop2">The upper bound of the value's target range</param>
        /// <param name="withinBounds">Indicates whether to constrain the value to the newly mapped range</param>
        /// <returns>The remapped value</returns>
        public static double Map(double value, double start1, double stop1, double start2, double stop2, bool withinBounds = false)
        {
            var newValue = (value - start1) / (stop1 - start1) * (stop2 - start2) + start2;

            if (!withinBounds)
                return newValue;
            return start2 < stop2 ? Constrain(newValue, start2, stop2) : Constrain(newValue, stop2, start2);
        }

        /// <summary>
        /// Constrains a value between a minimum and maximum value
        /// </summary>
        /// <param name="value">The value to be constrained</param>
        /// <param name="low">The minimum limit</param>
        /// <param name="high">The maximum limit</param>
        /// <returns>The constrained value</returns>
        public static double Constrain(double value, double low, double high) => Max(Min(value, high), low);

        /// <summary>
        /// Converts angles from radian to degrees
        /// </summary>
        /// <param name="angle">The angle to convert (in radians)</param>
        /// <returns>The converted degrees-angle</returns>
        public static double RadianToDegrees(double angle) => angle * RadToDeg;

        /// <summary>
        /// Converts angles from degrees to radian
        /// </summary>
        /// <param name="angle">The angle to convert (in degrees)</param>
        /// <returns>The converted radian-angle</returns>
        public static double DegreesToRadian(double angle) => angle * DegToRad;
    }
}