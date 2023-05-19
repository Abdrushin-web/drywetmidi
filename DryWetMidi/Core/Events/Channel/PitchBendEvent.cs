using Melanchall.DryWetMidi.Common;
using System;

namespace Melanchall.DryWetMidi.Core
{
    /// <summary>
    /// Represents a Pitch Bend Change message.
    /// </summary>
    /// <remarks>
    /// This message is sent to indicate a change in the pitch bender (wheel or lever, typically).
    /// The pitch bender is measured by a fourteen bit value. Center (no pitch change) is 0x2000.
    /// </remarks>
    public sealed class PitchBendEvent : ChannelEvent
    {
        #region Constants

        /// <summary>
        /// Represents the smallest possible negative pitch value.
        /// </summary>
        public const ushort MinPitchValue = PitchBend.MinValue;

        /// <summary>
        /// Represents the largest possible positive pitch value.
        /// </summary>
        public const ushort MaxPitchValue = PitchBend.MaxValue;

        /// <summary>
        /// Represents zero pitch value
        /// </summary>
        public const ushort DefaultPitchValue = PitchBend.ZeroValue;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PitchBendEvent"/>.
        /// </summary>
        public PitchBendEvent()
            : this(DefaultPitchValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PitchBendEvent"/> with the specified
        /// pitch value.
        /// </summary>
        /// <param name="pitchValue">Pitch value.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pitchValue"/> is out of
        /// [<see cref="MinPitchValue"/>; <see cref="MaxPitchValue"/>] range.</exception>
        public PitchBendEvent(ushort pitchValue)
            : base(MidiEventType.PitchBend)
        {
            PitchValue = pitchValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets pitch value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is out of
        /// [<see cref="MinPitchValue"/>; <see cref="MaxPitchValue"/>] range.</exception>
        public ushort PitchValue
        {
            get { return Pitch; }
            set { Pitch = new PitchBend(value); }
        }

        /// <summary>
        /// <see cref="PitchBend"/>
        /// </summary>
        public PitchBend Pitch
        {
            get { return new PitchBend(_dataByte2, _dataByte1); }
            set
            {
                _dataByte1 = value.Byte1;
                _dataByte2 = value.Byte2;
            }
        }

        #endregion

        #region Overrides

        internal override void Read(MidiReader reader, ReadingSettings settings, int size)
        {
            _dataByte1 = ReadDataByte(reader, settings);
            _dataByte2 = ReadDataByte(reader, settings);
        }

        internal override void Write(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteByte(_dataByte1);
            writer.WriteByte(_dataByte2);
        }

        internal override int GetSize(WritingSettings settings)
        {
            return 2;
        }

        /// <summary>
        /// Clones event by creating a copy of it.
        /// </summary>
        /// <returns>Copy of the event.</returns>
        protected override MidiEvent CloneEvent()
        {
            return new PitchBendEvent
            {
                _dataByte1 = _dataByte1,
                _dataByte2 = _dataByte2,
                Channel = Channel
            };
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Pitch Bend [{Channel}] ({PitchValue})";
        }

        #endregion
    }
}
