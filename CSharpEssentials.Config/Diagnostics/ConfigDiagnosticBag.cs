using CSharpEssentials.Diagnostics;
using System.Collections.Generic;

namespace CSharpEssentials.Config
{
    internal sealed class ConfigDiagnosticBag : DiagnosticBag
    {
        public ConfigDiagnosticBag() : base()
        {

        }

        public ConfigDiagnosticBag(IEnumerable<Diagnostic> previous) : base(previous)
        {

        }

        public static string GetMissingValueMessage(string key) => $"No associated value could be found under key '{key}'.";

        /// <summary>
        /// Adds a new diagnostic message which implies that no value could be found under <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key which had no value</param>
        public void ReportMissingValue(string key)
        {
            ReportError(GetMissingValueMessage(key),key);
        }
    }
}