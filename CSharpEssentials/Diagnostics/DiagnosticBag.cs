using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CSharpEssentials.Diagnostics
{
    /// <summary>
    /// Represents a collection of diagnostic message
    /// </summary>
    public sealed class DiagnosticBag
    {
        #region Properties
        /// <summary>
        /// Represents the diagnostic messages
        /// </summary>
        public IImmutableList<string> Diagnostics => _diagnostics.ToImmutableList();
        #endregion

        #region Fields
        private IList<string> _diagnostics;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="DiagnosticBag"/> class
        /// </summary>
        private DiagnosticBag() => _diagnostics = new List<string>();
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new diagnostic message
        /// </summary>
        /// <param name="message"></param>
        public void Add(string message) => _diagnostics.Add(message);

        /// <summary>
        /// Adds a new diagnostic message which implies that no value could be found under <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key which had no value</param>
        public void Add_MissingValue(string key) => Add($"ERROR: No associated value could be found under key '{key}'");
        #endregion

        #region Subclasses
        /// <summary>
        /// Represents the builder for <see cref="DiagnosticBag"/> class
        /// </summary>
        public static class Builder
        {
            #region Fields
            private static IList<DiagnosticBag> _diagnosticBags;
            #endregion

            #region Constructors
            /// <summary>
            /// Initializes the static fields of <see cref="Builder"/> class
            /// </summary>
            static Builder() => _diagnosticBags = new List<DiagnosticBag>();
            #endregion

            #region Public methods
            /// <summary>
            /// Builds a new <see cref="DiagnosticBag"/>
            /// </summary>
            /// <returns>A new instance of <see cref="DiagnosticBag"/> class</returns>
            public static DiagnosticBag Build()
            {
                _diagnosticBags.Add(new DiagnosticBag());

                return _diagnosticBags[_diagnosticBags.Count - 1];
            }

            /// <summary>
            /// Builds a new <see cref="DiagnosticBag"/>
            /// </summary>
            /// <param name="index">The index of this <see cref="DiagnosticBag"/> instance</param>
            /// <returns>A new instance of <see cref="DiagnosticBag"/> class</returns>
            public static DiagnosticBag Build(out int index)
            {
                index = _diagnosticBags.Count;
                _diagnosticBags.Add(new DiagnosticBag());

                return _diagnosticBags[index];
            }

            /// <summary>
            /// Gets the <see cref="DiagnosticBag"/> at a specific index
            /// </summary>
            /// <param name="index">The index of the <see cref="DiagnosticBag"/></param>
            /// <returns>The <see cref="DiagnosticBag"/> associated with <paramref name="index"/></returns>
            public static DiagnosticBag Get(int index)
            {
                return index > _diagnosticBags.Count - 1 ? throw new IndexOutOfRangeException
                    ($"The value of parameter '{nameof(index)}' was out of range. {nameof(index)}'s value: '{index}'; " +
                    $"Count of {nameof(DiagnosticBag)}s: '{_diagnosticBags.Count}'") : _diagnosticBags[index];
            }
            #endregion
        }
        #endregion
    }
}
