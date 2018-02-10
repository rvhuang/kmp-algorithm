using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmForce.Searching.Deferred
{
    /// <summary>
    /// Provides a set of extensions for searching specified collection in an <see cref="IEnumerable{T}" /> instance.
    /// </summary>    
    public static class EnumerableExtensions
    {
        internal static int IndexOf<T>(this IEnumerable<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            Validate(s, t);

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

        internal static int IndexOf<T>(this IEnumerable<T> s, T t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            foreach(var e in s)
            {
                if (comparer.Equals(e, t)) return startIndex;
                startIndex++;
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

        internal static void Validate<T>(IEnumerable<T> s, IReadOnlyList<T> t)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (t == null) throw new ArgumentNullException(nameof(t));
        }
    }
}