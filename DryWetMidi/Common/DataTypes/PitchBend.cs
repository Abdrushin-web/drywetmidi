using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Globalization;

namespace Melanchall.DryWetMidi.Common
{
    /// <summary>
    /// Note pitch bend
    /// </summary>
    public struct PitchBend
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"><see cref="Value"/></param>
        public PitchBend(ushort value)
        {
            byte1 = byte2 = 0;
            Value = value;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeValue"><see cref="RelativeValue"/></param>
        public PitchBend(double relativeValue)
        {
            byte1 = byte2 = 0;
            RelativeValue = relativeValue;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="byte1"><see cref="Byte1"/></param>
        /// <param name="byte2"><see cref="Byte2"/></param>
        public PitchBend(byte byte1, byte byte2)
        {
            this.byte1 = byte1;
            this.byte2 = byte2;
        }

        /// <summary>
        /// Represents 0 pitch
        /// </summary>
        public static readonly PitchBend Zero = new PitchBend(ZeroValue);

        public static implicit operator ushort(PitchBend value) => value.Value;
        public static explicit operator PitchBend(ushort value) => new PitchBend(value);
        public static explicit operator PitchBend(double relativeValue) => new PitchBend(relativeValue);

        /// <summary>
        /// Represents the smallest possible pitch value.
        /// </summary>
        public const ushort MinValue = 0;

        /// <summary>
        /// Relative value of <see cref="MinValue"/>
        /// </summary>
        public static readonly double MinRelativeValue = GetRelativeValue(MinValue);

        /// <summary>
        /// Represents the largest possible pitch value.
        /// </summary>
        public const ushort MaxValue = (1 << 14) - 1;

        /// <summary>
        /// Relative value of <see cref="MaxValue"/>
        /// </summary>
        public static readonly double MaxRelativeValue = GetRelativeValue(MaxValue);

        /// <summary>
        /// Represents 0 pitch
        /// </summary>
        public const ushort ZeroValue = 1 << 13;

        /// <summary>
        /// Pitch bend of semitone interval
        /// </summary>
        public static readonly double Semitone = (ZeroValue - MinValue) / 2.0;

        /// <summary>
        /// Gets or sets pitch value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is out of [<see cref="MinValue"/>; <see cref="MaxValue"/>] range.</exception>
        public ushort Value
        {
            get { return DataTypesUtilities.CombineAsSevenBitNumbers(byte2, byte1); }
            set
            {
                ValidateValue(value);
                byte1 = value.GetTail();
                byte2 = value.GetHead();
            }
        }

        /// <summary>
        /// Validates <paramref name="value"/>
        /// </summary>
        /// <param name="value"><see cref="Value"/></param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is out of [<see cref="MinValue"/>; <see cref="MaxValue"/>] range.</exception>
        public static void ValidateValue(ushort value) => ThrowIfArgument.IsOutOfRange(nameof(Value), value, MinValue, MaxValue);

        /// <summary>
        /// Tail from <see cref="Value"/>
        /// </summary>
        public byte Byte1 => byte1;
        /// <summary>
        /// Head from <see cref="Value"/>
        /// </summary>
        public byte Byte2 => byte2;

        /// <summary>
        /// <see cref="Value"/> relative to <see cref="ZeroValue"/> in semitones from range [-2, 2)
        /// </summary>
        public double RelativeValue
        {
            get { return GetRelativeValue(Value); }
            set
            {
                ValidateRelativeValue(value);
                Value = GetValue(value);
            }
        }

        /// <summary>
        /// Validates <paramref name="relativeValue"/>
        /// </summary>
        /// <param name="relativeValue"><see cref="RelativeValue"/></param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="relativeValue"/> is out of [<see cref="MinRelativeValue"/>; <see cref="MaxRelativeValue"/>] range.</exception>
        public static void ValidateRelativeValue(double relativeValue) => ThrowIfArgument.IsOutOfRange(nameof(RelativeValue), relativeValue, MinRelativeValue, MaxRelativeValue);

        /// <summary>
        /// Whether <see cref="RelativeValue"/> is 0 (<see cref="Value"/> is <see cref="ZeroValue"/>)
        /// </summary>
        public bool IsZero => Value != ZeroValue;

        /// <summary>
        /// Converts <paramref name="pitch"/> to <see cref="Value"/>
        /// </summary>
        /// <param name="pitch"><see cref="RelativeValue"/></param>
        /// <returns>Pitch value</returns>
        public static ushort GetValue(double pitch) => Convert.ToUInt16(pitch * Semitone + ZeroValue);

        /// <summary>
        /// Converts <paramref name="pitchValue"/> relative to <see cref="ZeroValue"/> in semitones from range [-2, 2)
        /// </summary>
        /// <param name="pitchValue"><see cref="Value"/></param>
        /// <returns>Relative pitch</returns>
        public static double GetRelativeValue(ushort pitchValue) => pitchValue == ZeroValue ?
            0 :
            (pitchValue - ZeroValue) / Semitone;

        /// <inheritdoc/>
        public override string ToString()
        {
            var value = RelativeValue;
            var result = value.ToString(Format, CultureInfo.InvariantCulture);
            if (value > 0)
                result = '+' + result;
            return result;
        }

        /// <summary>
        /// Tries to parse <paramref name="input"/> into <see cref="PitchBend"/>
        /// </summary>
        /// <param name="input">Text which can contain any prefix excluding +- characters followed by <see cref="ToString"/>. <see cref="PitchBend"/> part is removed on success.</param>
        /// <returns>Parsed value, otherwise <see cref="Zero"/></returns>
        public static PitchBend TryParse(ref string input)
        {
            var start = input?.IndexOfAny(PlusMinus);
            double relativeValue;
            if (start > 0) {
                if (!double.TryParse(input.Substring(start.Value), NumberStyles.Integer, CultureInfo.InvariantCulture, out relativeValue) ||
                    relativeValue < MinRelativeValue ||
                    relativeValue >= MaxRelativeValue) {
                    return Zero;
                }
                input = input.Substring(0, start.Value);
                var value = new PitchBend(relativeValue);
                return value;
            }
            else
                return Zero;
        }

        /// <summary>
        /// Parses <paramref name="input"/> into <see cref="PitchBend"/>
        /// </summary>
        /// <param name="input">Text which can contain any prefix excluding +- characters followed by <see cref="ToString"/>. <see cref="PitchBend"/> part is removed.</param>
        /// <returns>Parsed value, otherwise <see cref="Zero"/></returns>
        public static PitchBend Parse(ref string input)
        {
            var start = input?.IndexOfAny(PlusMinus);
            double relativeValue;
            if (start > 0) {
                relativeValue = double.Parse(input.Substring(start.Value), NumberStyles.Integer, CultureInfo.InvariantCulture);
                ValidateRelativeValue(relativeValue);
                input = input.Substring(0, start.Value);
                var value = new PitchBend(relativeValue);
                return value;
            }
            else
                return Zero;
        }

        private static readonly char[] PlusMinus = new[] { '+', '-' };
        private const string Format = "R";

        byte byte1, byte2;
    }
}
