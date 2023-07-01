using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharpEssentials.Helpers
{
    /// <summary>
    /// Represents an <see cref="IEqualityComparer{T}"/> implementation to approximately determine "equality" of two <typeparamref name="T"/> instances using an offset.
    /// </summary>
    public abstract class ApproximateComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApproximateComparer{T}"/> class with a default offset of 1.
        /// </summary>
        protected ApproximateComparer() : this(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproximateComparer{T}"/> class with a custom offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        protected ApproximateComparer(float offset) : this(offset, offset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproximateComparer{T}"/> class with offsets that may be unequal.
        /// </summary>
        /// <param name="posOffset">The offset in the positive direction.</param>
        /// <param name="negOffset">The offset in the negative direction.</param>
        protected ApproximateComparer(float posOffset, float negOffset)
        {
            PosOffset = posOffset;
            NegOffset = negOffset;
        }

        /// <summary>
        /// Represents the offset in the positive direction; that is, a value indicating how large a difference between to <see cref="{T}"/> instances can be in each component.
        /// </summary>
        public float PosOffset { get; }
        /// <summary>
        /// Represents the offset in the negative direction; that is, a value indicating how large a difference between to <see cref="{T}"/> instances can be in each component.
        /// </summary>
        public float NegOffset { get; }
        /// <summary>
        /// Represents a value indicating whether both offsets are equal.
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="PosOffset"/> has the same value as <see cref="NegOffset"/>; otherwise, <see langword="false"/>.</returns>
        public bool IsSymmetric => PosOffset == NegOffset;

        public abstract bool Equals(T? x, T? y);

        public int GetHashCode([DisallowNull] T obj) => obj.GetHashCode();

        protected virtual bool Equals(float x, float y) => x >= y - NegOffset && x <= y + PosOffset;
    }
}