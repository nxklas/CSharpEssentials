using CSharpEssentials.Diagnostics;
using CSharpEssentials.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace CSharpEssentials.Config
{
    /// <summary>
    /// Represents a config that writes to / reads from the AppData folder
    /// </summary>
    /// <remarks>NOTE: Untested</remarks>
    public sealed class AppDataConfiguration : DirectoryConfiguration
    {
        #region Properties
        /// <summary>
        /// Represents the path to the config file in AppData
        /// </summary>
        protected override string Path => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppName + FileName;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="AppDataConfiguration"/> class
        /// </summary>
        public AppDataConfiguration(string appName) : base(appName)
        {

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads the whole AppData config
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="keys">The keys where to get their associated values from</param>
        /// <returns>An <see cref="IImmutableList{T}"/> of all read values and it's keys</returns>
        public override IImmutableList<KeyValuePair<ConfigKey, string>> Read(out IImmutableList<string> diagnostics, params ConfigKey[] keys)
        {
            if (!File.Exists(Path))
                File.Create(Path);

            IList<KeyValuePair<ConfigKey, string>> values = new List<KeyValuePair<ConfigKey, string>>();
            DiagnosticBag diagnosticBag = DiagnosticBag.Builder.Build();
            string text = File.ReadAllText(Path);
            string[] splittedText = text.Split(Environment.NewLine);

            foreach (ConfigKey key in keys)
            {
                bool found = false;

                foreach (string currentLine in splittedText)
                {
                    string[] splittedCurrentLine = currentLine.Split('=');

                    if (splittedCurrentLine[0].Trim().ToLower() == key.ToString().ToLower())
                    {
                        found = true;
                        values.Add(new KeyValuePair<ConfigKey, string>(key, splittedCurrentLine[1].Trim()));
                        break;
                    }
                }

                if (!found)
                    diagnosticBag.Add_MissingValue(key.ToString());
            }

            diagnostics = diagnosticBag.Diagnostics;
            return values.ToImmutableList();
        }

        /// <summary>
        /// Reads the AppData config at the specific config key
        /// </summary>
        /// <param name="diagnostics">An <see cref="IImmutableList{T}"/> which contains all possibly occured error messages</param>
        /// <param name="key">The key where to get it's associated values from</param>
        /// <returns>The value of <paramref name="key"/></returns>
        public override string Read(out IImmutableList<string> diagnostics, ConfigKey key)
        {
            if (!File.Exists(Path))
                File.Create(Path);

            string value = null;
            DiagnosticBag diagnosticBag = DiagnosticBag.Builder.Build();
            string text = File.ReadAllText(Path);
            string[] splittedText = text.Split(Environment.NewLine);
            bool found = false;

            foreach (string currentLine in splittedText)
            {
                string[] splittedCurrentLine = currentLine.Split('=');

                if (splittedCurrentLine[0].Trim().ToLower() == key.ToString().ToLower())
                {
                    found = true;
                    value = splittedCurrentLine[1].Trim();
                    break;
                }
            }

            if (!found)
                diagnosticBag.Add_MissingValue(key.ToString());

            diagnostics = diagnosticBag.Diagnostics;
            return value;
        }

        /// <summary>
        /// Writes the whole AppData config
        /// </summary>
        /// <param name="values">The values to write</param>
        public override void Write(params KeyValuePair<ConfigKey, string>[] values)
        {
            StringBuilder stringBuilder = new();

            foreach (KeyValuePair<ConfigKey, string> current in values)
                stringBuilder.Append($"{current.Key} = {current.Value + Environment.NewLine}");

            if (!File.Exists(Path))
                File.Create(Path);

            File.WriteAllText(Path, stringBuilder.ToString());
        }

        /// <summary>
        /// Writes a specific value to the AppData config
        /// </summary>
        /// <param name="key">The key where to write it's value</param>
        /// <param name="value">The value to write</param>
        public override void Write(ConfigKey key, string value)
        {
            var keys = ReflectiveEnumerator.GetEnumerableOfType<ConfigKey>(null);
            IImmutableList<KeyValuePair<ConfigKey, string>> values = Read(out IImmutableList<string> diagnostics, keys as ConfigKey[]);
            KeyValuePair<ConfigKey, string> keyValuePair = new(key, value);
            bool found = false;

            foreach (KeyValuePair<ConfigKey, string> current in values)
            {
                if (current.Key == null || current.Value == null)
                    continue;

                if (current.Equals(keyValuePair))
                    found = true;
            }

            if (!found)
                values.Add(new KeyValuePair<ConfigKey, string>(key, value));

            Write(values.ToKeyValuePairArray());
        }
        #endregion
    }
}
