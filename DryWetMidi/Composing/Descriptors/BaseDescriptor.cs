using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Interaction;
using System;

namespace Melanchall.DryWetMidi.Composing
{
    /// <summary>
    /// Represents an object that describes a note/chord/tone.
    /// </summary>
    public abstract class BaseDescriptor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChordDescriptor"/> with the specified notes,
        /// velocity and length.
        /// </summary>
        /// <param name="velocity">Velocity of the chord's notes.</param>
        /// <param name="length">Length of the chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="length"/> is <c>null</c></exception>
        protected BaseDescriptor(SevenBitNumber velocity, ITimeSpan length)
        {
            ThrowIfArgument.IsNull(nameof(length), length);
            Velocity = velocity;
            Length = length;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the velocity of the chord.
        /// </summary>
        public SevenBitNumber Velocity { get; }

        /// <summary>
        /// Gets the length of the chord.
        /// </summary>
        public ITimeSpan Length { get; }

        #endregion

        #region Operators

        /// <summary>
        /// Determines if two <see cref="BaseDescriptor"/> objects are equal.
        /// </summary>
        /// <param name="descriptor1">The first <see cref="BaseDescriptor"/> to compare.</param>
        /// <param name="descriptor2">The second <see cref="BaseDescriptor"/> to compare.</param>
        /// <returns><c>true</c> if the descriptors are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(BaseDescriptor descriptor1, BaseDescriptor descriptor2)
        {
            if (ReferenceEquals(descriptor1, descriptor2))
                return true;

            if (ReferenceEquals(null, descriptor1) || ReferenceEquals(null, descriptor2))
                return false;

            return descriptor1.Velocity == descriptor2.Velocity &&
                   descriptor1.Length.Equals(descriptor2.Length);
        }

        /// <summary>
        /// Determines if two <see cref="ChordDescriptor"/> objects are not equal.
        /// </summary>
        /// <param name="descriptor1">The first <see cref="BaseDescriptor"/> to compare.</param>
        /// <param name="descriptor2">The second <see cref="BaseDescriptor"/> to compare.</param>
        /// <returns><c>false</c> if the descriptors are equal, <c>true</c> otherwise.</returns>
        public static bool operator !=(BaseDescriptor descriptor1, BaseDescriptor descriptor2) => !(descriptor1 == descriptor2);

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"[{Velocity}]: {Length}";

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this == (obj as BaseDescriptor);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 17;
                result = result * 23 + Velocity.GetHashCode();
                result = result * 23 + Length.GetHashCode();
                return result;
            }
        }

        #endregion
    }
}
