using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmForce.Searching.Deferred
{
    public static class ReaderExtensions
    {
        public static IEnumerable<char> AsCharEnumerable(this TextReader reader)
        {
            return EnumerateChars(reader.Read);
        }

        public static IEnumerable<char> AsCharEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadChar);
        }

        public static IEnumerable<byte> AsByteEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadByte);
        }

        public static IEnumerable<short> AsInt16Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt16);
        }

        public static IEnumerable<int> AsInt32Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt32);
        }

        public static IEnumerable<long> AsInt64Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt64);
        }

        public static IEnumerable<float> AsSingleEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadSingle);
        }

        public static IEnumerable<double> AsDoubleEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadDouble);
        }
        
        public static IEnumerable<decimal> AsDecimalEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadDecimal);
        }

        internal static IEnumerable<T> Enumerate<T>(Func<T> method)
        {
            var c = default(T);

            while (true)
            {
                try
                {
                    c = method();
                }
                catch (EndOfStreamException)
                {
                    yield break;
                }
                yield return c;
            }
        }

        internal static IEnumerable<char> EnumerateChars(Func<int> method)
        {
            var c = default(int);

            while (c != -1)
            {
                try
                {
                    c = method();
                }
                catch (EndOfStreamException)
                {
                    yield break;
                }
                yield return (char)c;
            }
        }
    }
}