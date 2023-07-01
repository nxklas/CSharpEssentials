using CSharpEssentials.Diagnostics;
using System.Collections.Generic;
using System.Numerics;
using TokenKind = CSharpEssentials.Mathematics.Vector2Helper.TokenKind;

namespace CSharpEssentials.Mathematics
{
    /// <summary>
    /// Represents an enumeration of diagnostical messages which are errors that can occur during the conversion of <see cref="string"/>s into <see cref="Vector2"/> instances.
    /// </summary>
    internal sealed class Vector2DiagnosticBag : DiagnosticBag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticBag"/> class and adds the specified range.
        /// </summary>
        /// <param name="diagnostics">The range to add.</param>
        public Vector2DiagnosticBag(IEnumerable<Diagnostic> diagnostics) : base(diagnostics)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticBag"/> class.
        /// </summary>
        public Vector2DiagnosticBag() : base()
        {

        }

        // Validating diagnostics
        /// <summary>
        /// Reports that the specified component name could not be parsed during validation.
        /// </summary>
        /// <param name="componentName">The name of the component which failed to parse.</param>
        /// <param name="actual">The value that should get parsed.</param>
        public void ReportInvalidComponent(string componentName, string actual)
        {
            ReportError($"Unable to parse {componentName} component, actual value: {actual}.", componentName, actual);
        }

        // Parsing diagnostics
        /// <summary>
        /// Reports that there occured an unexpected token.
        /// </summary>
        /// <param name="actual">The actual token that was found.</param>
        /// <param name="expected">The expected token.</param>
        public void ReportUnexpectedToken(TokenKind actual, TokenKind expected)
        {
            ReportError($"Unexpected token: {actual}, expected: {expected}.", actual, expected);
        }

        // Lexing diagnostics
        /// <summary>
        /// Reports that there is a bad character in the input text.
        /// </summary>
        /// <param name="character">The bad character.</param>
        public void ReportBadCharacter(char character)
        {
            ReportError($"Bad character in text: '{character}'.", character);
        }
    }
}