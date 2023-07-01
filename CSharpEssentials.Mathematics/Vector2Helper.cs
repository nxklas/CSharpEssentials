using CSharpEssentials.Diagnostics;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Numerics;
using static CSharpEssentials.Mathematics.MathHelper;

namespace CSharpEssentials.Mathematics
{
    /// <summary>
    /// Provides functionalities to simplify manipulating <see cref="Vector2"/> structs
    /// </summary>
    public static class Vector2Helper
    {
        private static readonly Random _rand = new();

        /// <summary>
        /// Creates a random-generated <see cref="Vector2"/> instance
        /// </summary>
        /// <returns>The random-generated <see cref="Vector2"/> instance</returns>
        public static Vector2 Random2D()
        {
            var length = 1f;
            var angle = _rand.NextDouble() * (2 * Math.PI);

            return new Vector2(length * (float)Math.Cos(angle), length * (float)Math.Sin(angle));
        }

        /// <summary>
        /// Gets the angle of rotation form a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to get the angle from</param>
        /// <param name="inDegrees">Indicates whether to get the angle as degrees (otherwise, radians)</param>
        /// <returns>The anlge of rotation</returns>
        public static double GetHeading(this Vector2 vector, bool inDegrees = true) =>
            inDegrees ? RadianToDegrees(Math.Atan2(vector.Y, vector.X)) : Math.Atan2(vector.Y, vector.X);

        /// <summary>
        /// Gets the magnitude (or length) from a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to get the magnitude from</param>
        /// <returns>The magnitude of the vector</returns>
        public static double GetMag(this Vector2 vector) => Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

        /// <summary>
        /// Sets the magnitude (or length) of a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to set the magnitude from</param>
        /// <param name="mag">The magnitude value</param>
        /// <returns>The vector with the new magnitude</returns>
        public static Vector2 SetMag(this Vector2 vector, double mag) => new((float)(vector.X * mag / vector.GetMag()), (float)(vector.Y * mag / vector.GetMag()));

        /// <summary>
        /// Creates a <see cref="Vector2"/> instance from the specified text.
        /// </summary>
        /// <remarks>The parser handles outputs from <see cref="Vector2.ToString"/>.</remarks>
        /// <param name="text">The text where to construct the vector from.</param>
        /// <param name="diagnostics">An array, containing possibly occured errors while parsing.</param>
        /// <returns>The constructed vector.</returns>
        public static Vector2 FromString(string text, out ImmutableArray<Diagnostic> diagnostics)
        {
            var parser = new Vector2Parser(text);
            var syntax = parser.Parse();
            var diagnosticBag = new Vector2DiagnosticBag(parser.Diagnostics);

            if (!float.TryParse(syntax.NumX.Text, out var x))
                diagnosticBag.ReportInvalidComponent(nameof(x), syntax.NumX.Text);

            if (!float.TryParse(syntax.NumY.Text, out var y))
                diagnosticBag.ReportInvalidComponent(nameof(y), syntax.NumY.Text);

            diagnostics = diagnosticBag.Diagnostics;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Represents a parser for <see cref="Vector2"/> instances.
        /// </summary>
        /// <remarks>The parser handles outputs from <see cref="Vector2.ToString"/>.</remarks>
        private sealed class Vector2Parser
        {
            /// <summary>
            /// A list for storing error messages while parsing, including those that occured while lexing.
            /// </summary>
            private readonly Vector2DiagnosticBag _diagnostics;
            /// <summary>
            /// The tokens to parse.
            /// </summary>
            private readonly ImmutableArray<Token> _tokens;
            /// <summary>
            /// The current position of the parser.
            /// </summary>
            private int _position;

            /// <summary>
            /// Initializes a new instance of the <see cref="Vector2"/> class.
            /// </summary>
            /// <param name="text">The text where to construct the vector from.</param>
            public Vector2Parser(string text)
            {
                var tokens = ImmutableArray.CreateBuilder<Token>();
                var lexer = new Vector2Lexer(text);
                Token token;

                do
                {
                    token = lexer.Lex();

                    if (token.Kind != TokenKind.WhitespaceToken &&
                        token.Kind != TokenKind.BadToken)
                        tokens.Add(token);
                } while (token.Kind != TokenKind.EndOfFileToken);

                _diagnostics = lexer.Diagnostics;
                _tokens = tokens.ToImmutable();
                _position = 0;
            }

            /// <summary>
            /// Represents an array, containing error messages occured while lexing and parsing.
            /// </summary>
            public ImmutableArray<Diagnostic> Diagnostics => _diagnostics.Diagnostics;
            /// <summary>
            /// Represents the current token.
            /// </summary>
            private Token Current => Peek(0);

            /// <summary>
            /// Gets a token from <see cref="_tokens"/> at the current position, considering the specified offset.
            /// </summary>
            /// <param name="offset">The offset, indicating how many tokens to look ahead.</param>
            /// <returns>The token on the current position, considering <paramref name="offset"/>.</returns>
            private Token Peek(int offset)
            {
                if (_position + offset >= _tokens.Length)
                    return _tokens[^1];
                return _tokens[_position + offset];
            }

            /// <summary>
            /// Gets the current token and increments the position.
            /// </summary>
            /// <returns>The current token.</returns>
            private Token Next()
            {
                var current = Current;
                _position++;
                return current;
            }

            /// <summary>
            /// Checks if the current token kind matches the specified token kind.
            /// </summary>
            /// <param name="kind">The requested token kind to match.</param>
            /// <returns>The current token if <paramref name="kind"/> matches; otherwise, a manufactured token, considering the current data.</returns>
            private Token Match(TokenKind kind)
            {
                if (Current.Kind == kind)
                    return Next();

                _diagnostics.ReportUnexpectedToken(Current.Kind, kind);
                return new Token(kind, Current.Start, Current.Text);
            }

            /// <summary>
            /// Parses the text specified on initialization, and creates a syntax from it.
            /// </summary>
            /// <returns>A syntax object, containing the parsed informations.</returns>
            public Vector2Syntax Parse()
            {
                var openChevron = Match(TokenKind.OpenChevronToken);
                var numX = Match(TokenKind.NumberToken);
                var separator = Match(TokenKind.SeparatorToken);
                var numY = Match(TokenKind.NumberToken);
                var closeChevron = Match(TokenKind.CloseChevronToken);
                return new Vector2Syntax(openChevron, numX, separator, numY, closeChevron);
            }

            /// <summary>
            /// Represents a lexer for <see cref="Vector2"/> instances.
            /// </summary>
            /// <remarks>The lexer handles outputs from <see cref="Vector2.ToString"/>.</remarks>
            private sealed class Vector2Lexer
            {
                /// <summary>
                /// Informations about the number format of the current culture.
                /// </summary>
                private static readonly NumberFormatInfo CurrentNumberFormat = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
                /// <summary>
                /// The character used for separating the x component from the y component.
                /// </summary>
                private static readonly char NumberGroupSeparator = CurrentNumberFormat.NumberGroupSeparator[0];
                /// <summary>
                /// The character used for separating the decimal part in a numeric <see cref="float"/> value.
                /// </summary>
                private static readonly char NumberDecimalSeparator = CurrentNumberFormat.NumberDecimalSeparator[0];
                /// <summary>
                /// A list for storing error messages while lexing.
                /// </summary>
                private readonly Vector2DiagnosticBag _diagnostics;
                /// <summary>
                /// The text to lex.
                /// </summary>
                private readonly string _text;
                /// <summary>
                /// The current position of the lexer.
                /// </summary>
                private int _position;
                /// <summary>
                /// The currently lexed token kind.
                /// </summary>
                private TokenKind _token; // Lazily initialized

                /// <summary>
                /// Initializes a new instance of the <see cref="Vector2Lexer"/> class.
                /// </summary>
                /// <param name="text">The text where to construct the vector from.</param>
                public Vector2Lexer(string text)
                {
                    _diagnostics = new();
                    _text = text;
                    _position = 0;
                }

                /// <summary>
                /// Represents an array, containing error messages occured while lexing.
                /// </summary>
                public Vector2DiagnosticBag Diagnostics => _diagnostics;
                /// <summary>
                /// Represents the current character.
                /// </summary>
                private char Current => Peek(0);

                /// <summary>
                /// Gets a character from <see cref="_text"/> at the current position, considering the specified offset.
                /// </summary>
                /// <param name="offset">The offset, indicating how many chars to look ahead.</param>
                /// <returns>The character on the current position, considering <paramref name="offset"/>.</returns>
                private char Peek(int offset)
                {
                    if (_position + offset >= _text.Length)
                        return '\0';
                    return _text[_position + offset];
                }

                /// <summary>
                /// Lexes the current token.
                /// </summary>
                /// <returns>A token instance, containing lexical informations of the current text sequence.</returns>
                public Token Lex()
                {
                    var start = _position;
                    _token = TokenKind.BadToken;

                    switch (Current)
                    {
                        case '\0':
                            _token = TokenKind.EndOfFileToken;
                            break;
                        case ' ':
                        case '\n':
                        case '\r':
                            ReadWhitespaceToken();
                            break;
                        case '<':
                            ReadOpenChevronToken();
                            break;
                        case '>':
                            ReadCloseChevronToken();
                            break;
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            ReadNumberToken();
                            break;
                        default:
                            if (Current == NumberGroupSeparator)
                                ReadSeparatorToken();
                            else if (char.IsWhiteSpace(Current))
                                ReadWhitespaceToken();
                            else
                                ReadBadToken();
                            break;
                    }

                    return new Token(_token, start, _text[start.._position]);
                }

                /// <summary>
                /// Reads a whitespace token.
                /// </summary>
                private void ReadWhitespaceToken()
                {
                    while (char.IsWhiteSpace(Current))
                        _position++;
                    _token = TokenKind.WhitespaceToken;
                }

                /// <summary>
                /// Reads a open chevron token.
                /// </summary>
                private void ReadOpenChevronToken()
                {
                    _position++;
                    _token = TokenKind.OpenChevronToken;
                }

                /// <summary>
                /// Reads a close chevron token.
                /// </summary>
                private void ReadCloseChevronToken()
                {
                    _position++;
                    _token = TokenKind.CloseChevronToken;
                }

                /// <summary>
                /// Reads a number token.
                /// </summary>
                private void ReadNumberToken()
                {
                    while (char.IsDigit(Current) || Current == NumberDecimalSeparator)
                        _position++;
                    _token = TokenKind.NumberToken;
                }

                /// <summary>
                /// Reads a separator token.
                /// </summary>
                private void ReadSeparatorToken()
                {
                    _position++;
                    _token = TokenKind.SeparatorToken;
                }

                /// <summary>
                /// Reads a bad token.
                /// </summary>
                private void ReadBadToken()
                {
                    _diagnostics.ReportBadCharacter(Current);
                    _position++;
                }
            }
        }

        /// <summary>
        /// Represents a syntax for <see cref="Vector2"/> instances.
        /// </summary>
        private readonly struct Vector2Syntax
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Vector2Syntax"/> structure.
            /// </summary>
            /// <param name="openChevron">The opening chevron.</param>
            /// <param name="numX">The x component for a <see cref="Vector2"/> instance.</param>
            /// <param name="separator">The separator, separating the x component from the y component.</param>
            /// <param name="numY">The y component for a <see cref="Vector2"/> instance.</param>
            /// <param name="closeChevron">The closing chevron.</param>
            public Vector2Syntax(Token openChevron, Token numX, Token separator, Token numY, Token closeChevron)
            {
                OpenChevron = openChevron;
                NumX = numX;
                Separator = separator;
                NumY = numY;
                CloseChevron = closeChevron;
            }

            /// <summary>
            /// Represents the opening chevron.
            /// </summary>
            public Token OpenChevron { get; }
            /// <summary>
            /// Represents the x component for a <see cref="Vector2"/> instance.
            /// </summary>
            public Token NumX { get; }
            /// <summary>
            /// Represents the separator, separating the x component from the y component.
            /// </summary>
            public Token Separator { get; }
            /// <summary>
            /// Represents the x component for a <see cref="Vector2"/> instance.
            /// </summary>
            public Token NumY { get; }
            /// <summary>
            /// Represents the closing chevron.
            /// </summary>
            public Token CloseChevron { get; }
        }

        /// <summary>
        /// Represents a token, containing lexical information about a specific text squence.
        /// </summary>
        private readonly struct Token
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Token"/> structure.
            /// </summary>
            /// <param name="kind">The kind of the token.</param>
            /// <param name="start">The start position in the text.</param>
            /// <param name="text">The text squence.</param>
            public Token(TokenKind kind, int start, string text)
            {
                Kind = kind;
                Start = start;
                Text = text;
            }

            /// <summary>
            /// Represents the kind of the token.
            /// </summary>
            public TokenKind Kind { get; }
            /// <summary>
            /// Represents the position in the text.
            /// </summary>
            public int Start { get; }
            /// <summary>
            /// Represents the text squence.
            /// </summary>
            public string Text { get; }
        }

        /// <summary>
        /// Represents a set of tokens.
        /// </summary>
        internal enum TokenKind
        {
            /// <summary>
            /// Represents the open chevron token.
            /// </summary>
            OpenChevronToken,
            /// <summary>
            /// Represents the close chevron token.
            /// </summary>
            CloseChevronToken,
            /// <summary>
            /// Represents the number token.
            /// </summary>
            NumberToken,
            /// <summary>
            /// Represents the separator token.
            /// </summary>
            SeparatorToken,
            /// <summary>
            /// Represents the bad token (used for illegal characters in a text).
            /// </summary>
            BadToken,
            /// <summary>
            /// Represents the whitespace token.
            /// </summary>
            WhitespaceToken,
            /// <summary>
            /// Represents the end of file token.
            /// </summary>
            EndOfFileToken
        }
    }
}