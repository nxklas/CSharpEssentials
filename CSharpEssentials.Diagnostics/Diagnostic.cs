namespace CSharpEssentials.Diagnostics
{
    public sealed class Diagnostic
    {
        public static Diagnostic Empty = new("", 0);

        public Diagnostic(string message, params object[] diagnosticalObjects) : this(message, DiagnosticKind.Error, diagnosticalObjects)
        {

        }

        public Diagnostic(string message, DiagnosticKind kind, params object[] diagnosticalObjects)
        {
            Message = message;
            Kind = kind;
            DiagnosticalObjects = diagnosticalObjects;
        }

        public string Message { get; }
        public DiagnosticKind Kind { get; }
        public object[] DiagnosticalObjects { get; }
    }
}