using System;

namespace CSharpEssentials.Events
{
    /// <summary>
    /// Represents the event data for property changed events
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PropertyChangedEventArgs<T> : EventArgs
    {
        #region Properties
        /// <summary>
        /// Represents the old value of changed property
        /// </summary>
        public T OldValue => _oldValue;
        /// <summary>
        /// Represents the new value of changed property
        /// </summary>
        public T NewValue => _newValue;
        #endregion

        #region Fields
        private readonly T _oldValue;
        private readonly T _newValue;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="PropertyChangedEventArgs{T}"/>
        /// </summary>
        /// <param name="oldValue">The old value of changed property</param>
        /// <param name="newValue">The new value of changed property</param>
        public PropertyChangedEventArgs(T oldValue, T newValue) : base()
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }
        #endregion
    }
}
