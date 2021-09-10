using System;
using System.Runtime.Versioning;
using Microsoft.Win32;

namespace CSharpEssentials.Registry.Helpers
{
    /// <summary>
    /// Provides simplified methods for Registry manipulations
    /// </summary>
    [SupportedOSPlatform("windows")]
    public static class RegistryHelper
    {
        /// <summary>
        /// Sets the value of a name/value pair in the Registry key
        /// </summary>
        /// <param name="subKey">The name or path of the subkey to open as read-only</param>
        /// <param name="name">The name of the value to store</param>
        /// <param name="value">The data to be stored</param>
        /// <param name="valueKind">The registry data type to use when storing the data</param>
        /// <param name="hKey">The root of the Registry path</param>
        public static void SetValue(string subKey, string name, object value, RegistryValueKind valueKind = RegistryValueKind.ExpandString, HKey hKey = HKey.CurrentUser)
        {
            switch (hKey)
            {
                case HKey.ClassesRoot:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        key.SetValue(name, value, valueKind);
                    break;
                case HKey.CurrentUser:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey))
                        key.SetValue(name, value, valueKind);
                    break;
                case HKey.LocalMachine:
                    using (RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(subKey))
                        key.SetValue(name, value, valueKind);
                    break;
                case HKey.Users:
                    using (RegistryKey key = Microsoft.Win32.Registry.Users.OpenSubKey(subKey))
                        key.SetValue(name, value, valueKind);
                    break;
                case HKey.CurrentConfig:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        key.SetValue(name, value, valueKind);
                    break;
                default:
                    throw new ArgumentException($"HKEY '{hKey}' could not be found in enum '{nameof(HKey)}'", nameof(hKey));
            }
        }

        /// <summary>
        /// Gets the value associated with the specified name
        /// </summary>
        /// <param name="subKey">The name or path of the subkey to open as read-only</param>
        /// <param name="name">The name of the value to get</param>
        /// <param name="hKey">The root of the Registry path</param>
        /// <returns>The value associated with name, or <see langword="null"/> if name is not found</returns>
        public static object GetValue(string subKey, string name, HKey hKey = HKey.CurrentUser)
        {
            switch (hKey)
            {
                case HKey.ClassesRoot:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case HKey.CurrentUser:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case HKey.LocalMachine:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case HKey.Users:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case HKey.CurrentConfig:
                    using (RegistryKey key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                default:
                    throw new ArgumentException($"HKEY '{hKey}' could not be found in enum '{nameof(HKey)}'", nameof(hKey));
            }
        }

        /// <summary>
        /// Represents a set of HKEYs (the root of the Registry path)
        /// </summary>
        /// <remarks>NOTE: Specific HKEYs require administrative rights</remarks>
        public enum HKey
        {
            /// <summary>
            /// Represents HKEY_CLASSES_ROOT in Registry
            /// </summary>
            ClassesRoot,
            /// <summary>
            /// Represents HKEY_CURRENT_USER in Registry
            /// </summary>
            CurrentUser,
            /// <summary>
            /// Represents HKEY_LOCAL_MACHINE in Registry
            /// </summary>
            LocalMachine,
            /// <summary>
            /// Represents HKEY_USERS in Registry
            /// </summary>
            Users,
            /// <summary>
            /// Represents HKEY_CURRENT_CONFIG in Registry
            /// </summary>
            CurrentConfig
        }
    }
}
