using Melanchall.DryWetMidi.Common;
using System;

namespace Melanchall.DryWetMidi.MusicTheory
{
    /// <summary>
    /// Tone with specific frequency
    /// </summary>
    /// <remarks>Expects tuning with <see cref="ConcertA"/></remarks>
    public sealed class Tone
    {
        #region Init

        static Tone()
        {
            MinNoteNumber = SevenBitNumber.MinValue;
            MaxNoteNumber = SevenBitNumber.MaxValue;
            ConcertA = new Tone(440, 69);
            MinFrequency = NoteNumberToFrequency(MinNoteNumber);
            MaxFrequency = NoteNumberToFrequency(MaxNoteNumber);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="frequency"><see cref="Frequency"/></param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="frequency"/> is not from range [<see cref="MinFrequency"/>, <see cref="MaxFrequency"/>]</exception>
        public Tone(double frequency) :
            this(frequency, FrequencyToNoteNumber(frequency))
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="note">Note</param>
        /// <exception cref="ArgumentNullException"><paramref name="note"/> is null</exception>
        public Tone(Note note) :
            this(NoteToFrequency(note), note.RealNoteNumber, note)
        { }

        private Tone(double frequency, double noteNumber, Note note = null)
        {
            Frequency = frequency;
            NoteNumber = noteNumber;
            Note = note ?? Note.Get(noteNumber);
        }

        /// <summary>
        /// Concert A tone with frequency 440 Hz
        /// </summary>
        public static readonly Tone ConcertA;

        /// <summary>
        /// Converts <paramref name="note"/> to <see cref="Tone"/>
        /// </summary>
        /// <param name="note">MIDI note</param>
        /// <exception cref="ArgumentNullException"><paramref name="note"/> is null</exception>
        public static implicit operator Tone(Note note) => new Tone(note);

        /// <summary>
        /// Converts <see cref="Tone"/> to <paramref name="tone"/>
        /// </summary>
        /// <param name="tone">MIDI note</param>
        /// <exception cref="ArgumentNullException"><paramref name="tone"/> is null</exception>
        public static implicit operator Note(Tone tone)
        {
            if (tone == null)
                throw new ArgumentNullException(nameof(tone));
            return Note.Get(tone.NoteNumber);
        }

        #endregion

        #region Frequency

        /// <summary>
        /// Minimum MIDI representable frequency [Hz]
        /// </summary>
        public static readonly double MinFrequency;
        /// <summary>
        /// Maximum MIDI representable frequency [Hz]
        /// </summary>
        public static readonly double MaxFrequency;

        /// <summary>
        /// Tone frequency [Hz]
        /// </summary>
        public double Frequency { get; }

        /// <summary>
        /// Validates <paramref name="frequency"/>
        /// </summary>
        /// <param name="frequency">Tone frequency [Hz]</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="frequency"/> is not from range [<see cref="MinFrequency"/>, <see cref="MaxFrequency"/>]</exception>
        public static void ValidateFrequency(double frequency) => ThrowIfArgument.IsOutOfRange(nameof(frequency), frequency, MinFrequency, MaxFrequency);

        /// <summary>
        /// Compares this tone to <paramref name="other"/> using <see cref="Frequency"/>
        /// </summary>
        /// <param name="other">Another tone</param>
        /// <returns>-1 if this <see cref="Frequency"/> is &lt; other <see cref="Frequency"/>, 0 for equality, 1 when this <see cref="Frequency"/> is &gt; other <see cref="Frequency"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null</exception>
        public int CompareTo(Tone other)
        {
            ThrowIfArgument.IsNull(nameof(other), other);
            return Frequency.CompareTo(other.Frequency);
        }

        /// <summary>
        /// Text
        /// </summary>
        /// <returns><see cref="Frequency"/> Hz</returns>
        public override string ToString() => $"{Frequency} Hz";

        #endregion

        #region NoteNumber

        /// <summary>
        /// Minimum real MIDI note number
        /// </summary>
        public static readonly double MinNoteNumber;
        /// <summary>
        /// Maximum real MIDI note number
        /// </summary>
        public static readonly double MaxNoteNumber;

        /// <summary>
        /// Real MIDI note number
        /// </summary>
        public double NoteNumber { get; }
        /// <summary>
        /// MIDI note
        /// </summary>
        public Note Note { get; }

        /// <summary>
        /// Validates <paramref name="noteNumber"/>
        /// </summary>
        /// <param name="noteNumber">Real MIDI note number</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="noteNumber"/> is not from range [<see cref="MinNoteNumber"/>, <see cref="MaxNoteNumber"/>]</exception>
        public static void ValidateNoteNumber(double noteNumber) => ThrowIfArgument.IsOutOfRange(nameof(noteNumber), noteNumber, MinNoteNumber, MaxNoteNumber);

        #endregion

        #region NoteNumber <-> Frequency

        static readonly double OctaveSemitoneCount = Interval.Twelve;

        /// <summary>
        /// Gets MIDI note number from <paramref name="frequency"/>
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/MIDI_tuning_standard</remarks>
        /// <param name="frequency">Tone frequency [Hz]</param>
        /// <returns>Note number</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="frequency"/> is not from range [<see cref="MinFrequency"/>, <see cref="MaxFrequency"/>]</exception>
        public static double FrequencyToNoteNumber(double frequency)
        {
            ValidateFrequency(frequency);
            return ConcertA.NoteNumber + OctaveSemitoneCount * Math.Log(frequency / ConcertA.Frequency, 2);
        }

        /// <summary>
        /// Gets tone frequency from <paramref name="noteNumber"/>
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/MIDI_tuning_standard</remarks>
        /// <param name="noteNumber">MIDI note number</param>
        /// <returns>Tone frequency [Hz]</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="noteNumber"/> is not from range [<see cref="MinNoteNumber"/>, <see cref="MaxNoteNumber"/>]</exception>
        public static double NoteNumberToFrequency(double noteNumber)
        {
            ValidateNoteNumber(noteNumber);
            return Math.Pow(2, (noteNumber - ConcertA.NoteNumber) / OctaveSemitoneCount) * ConcertA.Frequency;
        }

        /// <summary>
        /// Gets tone frequency from <paramref name="note"/>
        /// </summary>
        /// <param name="note">MIDI note</param>
        /// <returns>Tone frequency [Hz]</returns>
        /// <exception cref="ArgumentNullException"><paramref name="note"/> is null</exception>
        public static double NoteToFrequency(Note note)
        {
            ThrowIfArgument.IsNull(nameof(note), note);
            return NoteNumberToFrequency(note.RealNoteNumber);
        }

        #endregion
    }
}
