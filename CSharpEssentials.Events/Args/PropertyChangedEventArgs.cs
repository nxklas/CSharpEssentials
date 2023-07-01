using System;

namespace CSharpEssentials
{
    /// <summary>
    /// Represents the event data for property changed events
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PropertyChangedEventArgs<T> : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="PropertyChangedEventArgs{T}"/>
        /// </summary>
        /// <param name="oldValue">The old value of changed property</param>
        /// <param name="newValue">The new value of changed property</param>
        public PropertyChangedEventArgs(T? oldValue, T newValue) : base()
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents the old value of changed property
        /// </summary>
        public T? OldValue { get; }
        /// <summary>
        /// Represents the new value of changed property
        /// </summary>
        public T NewValue { get; }
        #endregion
    }
}