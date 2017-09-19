﻿namespace Melanchall.DryWetMidi.Smf.Interaction
{
    public interface ITimeSpan
    {
        ITimeSpan Add(ITimeSpan timeSpan, MathOperationMode operationMode);

        ITimeSpan Subtract(ITimeSpan timeSpan, MathOperationMode operationMode);

        ITimeSpan Multiply(double multiplier);

        ITimeSpan Divide(double divisor);
    }
}
