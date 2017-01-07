using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmForce.Searching
{
    public static class Extensions
    {
        #region IReadOnlyList(T) and IReadOnlyList(T)

        public static int IndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, 0, EqualityComparer<T>.Default);
        }

        public static int IndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, 0, comparer);
        }

        public static int IndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex)
            where T : IEquatable<T>
        {
            return s.IndexOf(t, startIndex, EqualityComparer<T>.Default);
        }

        public static int IndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (t == null) throw new ArgumentNullException(nameof(t));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(s), "Value is less than zero.");

            if (startIndex >= s.Count)
                throw new ArgumentOutOfRangeException(nameof(s), "Value is greater than the length of s.");

            // Follow the behavior of string.IndexOf(string) method. 
            if (t.Count == 0) return 0;
            if (s.Count == 0 || s.Count < t.Count) return -1;

            if (comparer == null) comparer = EqualityComparer<T>.Default;
            if (t.Count == 1) return s.IndexOfSingle(t[0], comparer);

            var table = BuildTable(t, comparer);
            var i = 0;

            while (startIndex + i < s.Count)
            {
                if (comparer.Equals(t[i], s[startIndex + i]))
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
                        i = table[i];
                    }
                    else
                    {
                        startIndex++;
                        i = 0;
                    }
                }
            }
            return -1;
        }
        
        #endregion

        #region String

        public static int IndexOf(this string s, IReadOnlyList<char> t)
        {
            return s.AsReadOnlyList().IndexOf(t, 0, EqualityComparer<char>.Default);
        }

        public static int IndexOf(this string s, IReadOnlyList<char> t, EqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().IndexOf(t, 0, comparer);
        }

        public static int IndexOf(this string s, IReadOnlyList<char> t, int startIndex)
        {
            return s.AsReadOnlyList().IndexOf(t, startIndex, EqualityComparer<char>.Default);
        }

        public static int IndexOf(this string s, IReadOnlyList<char> t, int startIndex, EqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().IndexOf(t, startIndex, comparer);
        }

        #endregion

        #region Wrapper

        public static IReadOnlyList<T> AsReadOnlyList<T>(this IList<T> list)
            where T : IEquatable<T>
        {
            return list == null ? default(IReadOnlyList<T>) : new ListWrapper<T>(list);
        }

        public static IReadOnlyList<char> AsReadOnlyList(this string str)
        {
            return str == null ? default(IReadOnlyList<char>) : new StringWrapper(str);
        }

        #endregion

        #region Others

        internal static int[] BuildTable<T>(IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T: IEquatable<T>
        {
            var table = new int[t.Count];
            var i = 2;
            var j = 0;

            table[0] = -1;
            table[1] = 0;

            while (i < t.Count)
            {
                if (comparer.Equals(t[i - 1], t[j]))
                {
                    table[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = table[j];
                }
                else
                {
                    table[i] = 0;
                    i++;
                }
            }
            return table;
        }

        internal static int IndexOfSingle<T>(this IReadOnlyList<T> s, T t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var i = 0;

            for (i = 0; i < s.Count; i++)
            {
                if (comparer.Equals(s[i], t))
                    return i;
            }
            return -1;
        }

        internal static void Validate()
        {

        }

        #endregion
    }
}
