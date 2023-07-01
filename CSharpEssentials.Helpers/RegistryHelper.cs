using Microsoft.Win32;
using System;
using Reg = Microsoft.Win32.Registry;

namespace CSharpEssentials.Helpers
{
    /// <summary>
    /// Provides simplified methods for Registry manipulations
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
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
        public static void SetValue(string subKey, string name, object value, RegistryValueKind valueKind = RegistryValueKind.ExpandString, Hkey hKey = Hkey.CurrentUser)
        {
            switch (hKey)
            {
                case Hkey.ClassesRoot:
                    using (var key = Reg.ClassesRoot.OpenSubKey(subKey, true))
                        key?.SetValue(name, value, valueKind);
                    break;
                case Hkey.CurrentUser:
                    using (var key = Reg.CurrentUser.OpenSubKey(subKey, true))
                        key?.SetValue(name, value, valueKind);
                    break;
                case Hkey.LocalMachine:
                    using (var key = Reg.LocalMachine.OpenSubKey(subKey, true))
                        key?.SetValue(name, value, valueKind);
                    break;
                case Hkey.Users:
                    using (var key = Reg.Users.OpenSubKey(subKey, true))
                        key?.SetValue(name, value, valueKind);
                    break;
                case Hkey.CurrentConfig:
                    using (var key = Reg.CurrentConfig.OpenSubKey(subKey, true))
                        key?.SetValue(name, value, valueKind);
                    break;
                default:
                    throw new ArgumentException($"HKEY '{hKey}' could not be found in enum '{nameof(Hkey)}'", nameof(hKey));
            }
        }

        /// <summary>
        /// Gets the value associated with the specified name
        /// </summary>
        /// <param name="subKey">The name or path of the subkey to open as read-only</param>
        /// <param name="name">The name of the value to get</param>
        /// <param name="hKey">The root of the Registry path</param>
        /// <returns>The value associated with name, or <see langword="null"/> if name is not found</returns>
        public static object? GetValue(string subKey, string name, Hkey hKey = Hkey.CurrentUser)
        {
            switch (hKey)
            {
                case Hkey.ClassesRoot:
                    using (var key = Reg.ClassesRoot.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case Hkey.CurrentUser:
                    using (var key = Reg.CurrentUser.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case Hkey.LocalMachine:
                    using (var key = Reg.LocalMachine.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case Hkey.Users:
                    using (var key = Reg.Users.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                case Hkey.CurrentConfig:
                    using (var key = Reg.CurrentConfig.OpenSubKey(subKey))
                        return key?.GetValue(name, null);
                default:
                    throw new ArgumentException($"HKEY '{hKey}' could not be found in enum '{nameof(Hkey)}'", nameof(hKey));
            }
        }

        public static bool RemoveValue(string subKey, string name, Hkey hKey = Hkey.CurrentUser)
        {
            try
            {
                switch (hKey)
                {
                    case Hkey.ClassesRoot:
                        using (var key = Reg.ClassesRoot.OpenSubKey(subKey))
                            key!.DeleteValue(name);
                        break;
                    case Hkey.CurrentUser:
                        using (var key = Reg.CurrentUser.OpenSubKey(subKey))
                            key!.DeleteValue(name);
                        break;
                    case Hkey.LocalMachine:
                        using (var key = Reg.LocalMachine.OpenSubKey(subKey))
                            key!.DeleteValue(name);
                        break;
                    case Hkey.Users:
                        using (var key = Reg.Users.OpenSubKey(subKey))
                            key!.DeleteValue(name);
                        break;
                    case Hkey.CurrentConfig:
                        using (var key = Reg.CurrentConfig.OpenSubKey(subKey))
                            key!.DeleteValue(name);
                        break;
                    default:
                        throw new ArgumentException($"HKEY '{hKey}' could not be found in enum '{nameof(Hkey)}'", nameof(hKey));
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Represents a set of HKEYs (the root of the Registry path)
    /// </summary>
    /// <remarks>NOTE: Specific HKEYs require administrative rights</remarks>
    public enum Hkey
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