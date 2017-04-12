﻿using System;

namespace Melanchall.DryMidi
{
    public sealed class CuePointMessage : MetaMessage
    {
        #region Constructor

        public CuePointMessage()
        {
        }

        public CuePointMessage(string text)
            : this()
        {
            Text = text;
        }

        #endregion

        #region Properties

        public string Text { get; set; }

        #endregion

        #region Methods

        public bool Equals(CuePointMessage cuePointMessage)
        {
            if (ReferenceEquals(null, cuePointMessage))
                return false;

            if (ReferenceEquals(this, cuePointMessage))
                return true;

            return base.Equals(cuePointMessage) && Text == cuePointMessage.Text;
        }

        #endregion

        #region Overrides

        internal override void ReadContent(MidiReader reader, ReadingSettings settings, int size = -1)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(size),
                    size,
                    "Non-negative size have to be specified in order to read Cue Point message.");

            Text = reader.ReadString(size);
        }

        internal override void WriteContent(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteString(Text);
        }

        internal override int GetContentSize()
        {
            return Text?.Length ?? 0;
        }

        protected override Message CloneMessage()
        {
            return new CuePointMessage(Text);
        }

        public override string ToString()
        {
            return $"Cue Point (text = {Text})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CuePointMessage);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (Text?.GetHashCode() ?? 0);
        }

        #endregion
    }
}
