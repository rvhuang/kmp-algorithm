using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmForce.Searching.Deferred
{
    /// <summary>
    /// Provides a set of extensions for searching specified collection in an <see cref="IEnumerable{T}" /> instance.
    /// </summary>
    /// <remarks>
    /// The APIs defined in the class are designed for instance that is produced in deferred execution (for example, yield return).
    /// Although technically the APIs can be applied to all types that implement <see cref="IEnumerable{T}" />,
    /// for those instances that are not produced in deferred execution, 
    /// <see cref="Extensions"/> is still recommended for best performance.
    /// </remarks>    
    public static class EnumerableExtensions
    {
        #region IReadOnlyList(T) (IndexOf)

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        public static int IndexOf<T>(this IEnumerable<T> s, IReadOnlyList<T> t)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, 0, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance
        /// and uses the specified <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <param name="comparer">The specified <see cref="IEqualityComparer{T}"/> instance.</param>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        public static int IndexOf<T>(this IEnumerable<T> s, IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, 0, comparer);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance.
        /// The search starts at a specified position.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is less than zero.
        /// </exception>
        public static int IndexOf<T>(this IEnumerable<T> s, IReadOnlyList<T> t, int startIndex)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, startIndex, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance
        /// and uses the specified <see cref="IEqualityComparer{T}"/>.
        /// The search starts at a specified position.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparer">The specified <see cref="IEqualityComparer{T}"/> instance.</param>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is less than zero.
        /// </exception>
        public static int IndexOf<T>(this IEnumerable<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            Validate(s, t, startIndex);

            // Follow the behavior of string.IndexOf(string) method. 
            if (t.Count == 0) return 0;
            if (comparer == null) comparer = EqualityComparer<T>.Default;
            if (t.Count == 1) return s.IndexOf(t[0], startIndex, comparer);

            var table = TableBuilder.BuildTable(t, comparer);
            var i = 0;
            var offset = startIndex + 1;

            using (var enumerator = s.GetEnumerator())
            {
                while (Skip(enumerator, offset) != null)
                {
                    if (comparer.Equals(t[i], enumerator.Current))
                    {
                        if (i == t.Count - 1)
                            return startIndex;
                        i++;
                    }
                    else
                    {
                        // We will extract this as a method GetOffset() in future version
                        // for upcoming APIs:
                        // 1. IndexOfAny(IReadOnlyList{T}, IEnumerable{IReadOnlyList{T}})
                        // 2. IndexesOfAll(IReadOnlyList{T}, IEnumerable{IReadOnlyList{T}}).
                        if (table[i] > -1)
                        {
                            startIndex += i;
                            offset = i;
                            i = table[i];
                        }
                        else
                        {
                            startIndex++;
                            offset = 1;
                            i = 0;
                        }
                    }
                }
            }
            return -1;
        }

        #endregion

        #region string (IndexOf)

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        public static int IndexOf(this IEnumerable<char> s, string t)
        {
            return s.IndexOf(t, 0, EqualityComparer<char>.Default);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance
        /// and uses the specified <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <param name="comparer">The specified <see cref="IEqualityComparer{T}"/> instance.</param>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        public static int IndexOf(this IEnumerable<char> s, string t, IEqualityComparer<char> comparer)
        {
            return s.IndexOf(t, 0, comparer);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified collection in this instance.
        /// The search starts at a specified position.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The collection to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is less than zero.
        /// </exception>
        public static int IndexOf(this IEnumerable<char> s, string t, int startIndex)
        {
            return s.IndexOf(t, startIndex, EqualityComparer<char>.Default);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance
        /// and uses the specified <see cref="IEqualityComparer{T}"/>.
        /// The search starts at a specified position.
        /// </summary>
        /// <param name="s">The current collection.</param>
        /// <param name="t">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparer">The specified <see cref="IEqualityComparer{T}"/> instance.</param>
        /// <returns>
        /// The zero-based index position of value if <paramref name="t"/> is found, or -1 if it is not. 
        /// If <paramref name="t"/> is empty, the return value is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> or <paramref name="t"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is less than zero.
        /// </exception>
        public static int IndexOf(this IEnumerable<char> s, string t, int startIndex, IEqualityComparer<char> comparer)
        {
            Validate(s, t, startIndex);
            
            return s.IndexOf(t.AsReadOnlyList(), startIndex, comparer);
        }

        #endregion

        #region Others

        internal static int IndexOf<T>(this IEnumerable<T> s, T t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var offset = startIndex + 1;

            using (var enumerator = s.GetEnumerator())
            {
                while (Skip(enumerator, offset) != null)
                {
                    if (comparer.Equals(t, enumerator.Current)) return startIndex;

                    startIndex++;
                    offset = 1;
                }
            }
            return -1;
        }

        internal static IEnumerator<T> Skip<T>(IEnumerator<T> enumerator, int count)
        {
            var i = 0;

            do
            {
                if (enumerator.MoveNext())
                    i++;
                else
                    return null;
            }
            while (i < count);
            return enumerator;
        }

        internal static void Validate<T>(IEnumerable<T> s, IEnumerable<T> t, int startIndex)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (t == null) throw new ArgumentNullException(nameof(t));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value is less than zero.");
        }

        #endregion
    }
}