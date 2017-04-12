﻿using System.Linq;

namespace Melanchall.DryMidi
{
    internal static class ArrayUtilities
    {
        internal static bool Equals<T>(T[] array1, T[] array2)
        {
            if (ReferenceEquals(array1, array2))
                return true;

            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            return array1.SequenceEqual(array2);
        }
    }
}
