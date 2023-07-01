using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CSharpEssentials.Diagnostics
{
    /// <summary>
    /// Represents a collection of diagnostic messages
    /// </summary>
    public abstract class DiagnosticBag : IEnumerable<Diagnostic>
    {
        #region Fields
        protected ImmutableArray<Diagnostic>.Builder _diagnostics;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="DiagnosticBag"/> class
        /// </summary>
        protected DiagnosticBag()
        {
            _diagnostics = ImmutableArray.CreateBuilder<Diagnostic>();
        }

        protected DiagnosticBag(IEnumerable<Diagnostic> previous):this()
        {
            AddRange(previous);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the diagnostic messages
        /// </summary>
        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics.ToImmutable();
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new diagnostic message
        /// </summary>
        /// <param name="message"></param>
        protected void Report(string message, DiagnosticKind kind, params object[] diagnosticalObjects)
        {
            _diagnostics.Add(new(message, kind,diagnosticalObjects));
        }

        protected void ReportError(string message, params object[] diagnosticalObjects)
        {
            Report(message, DiagnosticKind.Error, diagnosticalObjects);
        }

        protected void ReportWarning(string message, params object[] diagnosticalObjects)
        {
            Report(message, DiagnosticKind.Warning, diagnosticalObjects);
        }

        public void AddRange(ImmutableArray<Diagnostic> previous)
        {
            AddRange((IEnumerable<Diagnostic>)previous);
        }

        public void AddRange(IEnumerable<Diagnostic> range)
        {
            _diagnostics.AddRange(range);
        }

        public IEnumerator<Diagnostic> GetEnumerator()=>_diagnostics.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
        #endregion
    }
}
