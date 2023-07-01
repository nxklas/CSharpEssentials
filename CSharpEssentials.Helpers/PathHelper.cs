using System;
using System.IO;
using System.Linq;

namespace CSharpEssentials.Helpers
{
    public static class PathHelper
    {
        private static readonly char[] IllegalChars = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

        /// <summary>
        /// Considering each (sub-)directory, which is, in a path, separated by <c>'\\'</c>, is a section, gets the specified section from a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="sectionNumber">The section identifier.</param>
        /// <param name="fromRightToLeft">Indicates whether <paramref name="path"/> is read from right to left.</param>
        /// <returns>A <see cref="string"/> instance that represents the with <paramref name="sectionNumber"/> specified section in <paramref name="path"/>.</returns>
        public static string GetSection(string path, int sectionNumber, bool fromRightToLeft = true)
        {
            const int LowerBound = 1;

            if (sectionNumber < LowerBound)
            {
                const string ParamName = nameof(sectionNumber);
                throw new ArgumentOutOfRangeException(ParamName, $"{ParamName} must be between {LowerBound} and the section count; actual: {sectionNumber}.");
            }

            var passedSections = 0;
            var builder = new System.Text.StringBuilder();
            var sections = path.Split('\\');
            var driveIdentifier = sections[0];

            // Check if drive identifier contains illegal chars; ignoring the last char because it's checked below
            for (var i = 0; i < driveIdentifier.Length - 1; i++)
                if (IllegalChars.Contains(driveIdentifier[i]))
                    throw new InvalidOperationException($"Specified path was not in a format of a valid path.");

            // Check if drive identifier ends with ':'
            if (!driveIdentifier.EndsWith(':'))
                throw new InvalidOperationException($"Specified path was not in a format of a valid path.");

            // Check if other sections contain illegal chars or if they're empty
            for (var i = 1; i < sections.Length; i++)
            {
                var section = sections[i];

                if (section == string.Empty)
                    throw new InvalidOperationException($"Specified path was not in a format of a valid path.");

                foreach (var c in section)
                    if (IllegalChars.Contains(c))
                        throw new InvalidOperationException($"Specified path was not in a format of a valid path.");
            }

            if (fromRightToLeft)
                for (var i = sections.Length - 1; i > -1; i--)
                {
                    passedSections++;

                    if (passedSections == sectionNumber)
                    {
                        builder.Insert(0, sections[i]);
                        break;
                    }
                }
            else
            {
                foreach (var section in sections)
                {
                    passedSections++;

                    if (passedSections == sectionNumber)
                    {
                        builder.Append(section);
                        break;
                    }
                }
            }

            if (passedSections < sectionNumber)
            {
                const string ParamName = nameof(sectionNumber);
                throw new ArgumentOutOfRangeException(ParamName, $"{ParamName} must be between 0 and the section count of: {passedSections}; actual: {sectionNumber}.");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Determines whether the specified path is in a valid format; no matter if the addressing directory/file actually exitsts.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><see langword="true"/> if <paramref name="path"/> is in a valid path format; otherwise, <see langword="false"/>.</returns>
        public static bool IsPath(string path)
        {
            if (path == string.Empty)
                return false;

            var pathInSections = path.Split('\\');
            var first = pathInSections[0];

            if (!first.EndsWith(':') || first.StartsWith(':'))
                return false;

            for (var i = 1; i < pathInSections.Length; i++)
            {
                var section = pathInSections[i];

                if (section == string.Empty)
                    return false;

                foreach (var c in section)
                    if (IllegalChars.Contains(c))
                        return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified path is in a valid format; no matter if the addressing directory/file actually exitsts.
        /// <br>Also, outputs the number of sections in the specified path.</br>
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <param name="sections">The number of sections in <paramref name="path"/> or -1 if <paramref name="path"/> is not in a valid format.</param>
        /// <returns><see langword="true"/> if <paramref name="path"/> is in a valid path format; otherwise, <see langword="false"/>.</returns>
        public static bool IsPath(string path, out int sections)
        {
            sections = -1;

            if (path == string.Empty)
                return false;

            var pathInSections = path.Split('\\');

            if (!pathInSections[0].EndsWith(':') || pathInSections[0].StartsWith(':'))
                return false;

            for (var i = 1; i < pathInSections.Length; i++)
            {
                var section = pathInSections[i];

                if (section == string.Empty)
                    return false;

                foreach (var c in section)
                    if (IllegalChars.Contains(c))
                        return false;
            }

            sections = pathInSections.Length;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static string RemoveFileName(string fullPath)
        {
            for (var i = fullPath.Length - 1; i > 0; i--)
            {
                var currentChar = fullPath[i];
                fullPath = fullPath.Remove(i);

                if (currentChar == '\\')
                    break;
            }

            return fullPath;
        }

        /// <summary>
        /// Splits a full path into its file name and path.
        /// </summary>
        /// <param name="fullPath">The full path which is a path to an existing file in the directory.</param>
        /// <param name="name">The file name.</param>
        /// <param name="path">The path.</param>
        /// <param name="includeExtension">Indicates whether the file's extension should be included in <paramref name="name"/>.</param>
        /// <exception cref="ArgumentException">If <paramref name="fullPath"/> was not an existing file.</exception>
        public static void Cleave(string fullPath, out string name, out string path, bool includeExtension = true)
        {
            if (!File.Exists(fullPath))
                throw new ArgumentException($"{typeof(string)} {nameof(fullPath)} must represent a path to an existing file. Actual value: \"{fullPath}\".", nameof(fullPath));

            name = includeExtension ? Path.GetFileName(fullPath) : Path.GetFileNameWithoutExtension(fullPath);
            path = RemoveFileName(fullPath);
        }

        /// <summary>
        /// Determines whether the specified path addresses an existing directory.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><see langword="true"/> if <paramref name="path"/> addresses an existings directory; otherwise, <see langword="false"/>.</returns>
        public static bool IsDirectory(string path)
        {
            if (File.Exists(path))
                return false;
            return Directory.Exists(path);
        }

        /// <summary>
        /// Determines whether the specified path addresses an existing file.
        /// </summary>
        /// <param name="fullPath">The path to check.</param>
        /// <returns><see langword="true"/> if <paramref name="fullPath"/> addresses an existing file; otherwise, <see langword="false"/>.</returns>
        public static bool IsFile(string fullPath)
        {
            if (Directory.Exists(fullPath))
                return false;
            return File.Exists(fullPath);
        }
    }
}