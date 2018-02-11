using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmForce.Searching.Deferred
{
    /// <summary>
    /// Provides a set of extension methods that wrap <see cref="TextReader" /> or <see cref="BinaryReader" />
    /// as <see cref="IEnumerable{T}" /> instance.
    /// </summary>
    public static class ReaderExtensions
    {
        /// <summary>
        /// Wraps <see cref="TextReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="TextReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="char"/> from the source.</returns>
        public static IEnumerable<char> AsCharEnumerable(this TextReader reader)
        {
            return EnumerateChars(reader.Read);
        }

        /// <summary>
        /// Wraps <see cref="TextReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="TextReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="string" /> from the source.</returns>
        public static IEnumerable<string> AsStringEnumerable(this TextReader reader)
        {
            return Enumerate(reader.ReadLine);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="char"/> from the source.</returns>
        public static IEnumerable<char> AsCharEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadChar);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="byte"/> from the source.</returns>
        public static IEnumerable<byte> AsByteEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadByte);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="short"/> from the source.</returns>
        public static IEnumerable<short> AsInt16Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt16);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="int"/> from the source.</returns>
        public static IEnumerable<int> AsInt32Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt32);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="long"/> from the source.</returns>        
        public static IEnumerable<long> AsInt64Enumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadInt64);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="float"/> from the source.</returns>
        public static IEnumerable<float> AsSingleEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadSingle);
        }

        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="double"/> from the source.</returns>
        public static IEnumerable<double> AsDoubleEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadDouble);
        }
        
        /// <summary>
        /// Wraps <see cref="BinaryReader" /> as <see cref="IEnumerable{T}" /> instance.  
        /// </summary>
        /// <param name="reader">The instance of <see cref="BinaryReader" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> instance that enumerates <see cref="decimal"/> from the source.</returns>
        public static IEnumerable<decimal> AsDecimalEnumerable(this BinaryReader reader)
        {
            return Enumerate(reader.ReadDecimal);
        }

        internal static IEnumerable<T> Enumerate<T>(Func<T> method) // We may need to customize this for different cases. 
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