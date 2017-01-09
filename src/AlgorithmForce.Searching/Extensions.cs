using System;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    public static class Extensions
    {
        #region IReadOnlyList(T) (IndexOf)

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
            Validate(s, t, startIndex);

            // Follow the behavior of string.IndexOf(string) method. 
            if (t.Count == 0) return 0;
            if (s.Count == 0 || s.Count < t.Count) return -1;

            if (comparer == null) comparer = EqualityComparer<T>.Default;
            if (t.Count == 1) return s.IndexOf(t[0], startIndex, comparer);

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

        #region String (IndexOf)

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

        #region IReadOnlyList(T) (LastIndexOf) 

        public static int LastIndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t)
            where T : IEquatable<T>
        {
            return s.LastIndexOf(t, s == null ? -1 : s.Count - 1, EqualityComparer<T>.Default);
        }

        public static int LastIndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            return s.LastIndexOf(t, s == null ? -1 : s.Count - 1, comparer);
        }

        public static int LastIndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex)
            where T : IEquatable<T>
        {
            return s.LastIndexOf(t, startIndex, EqualityComparer<T>.Default);
        }

        public static int LastIndexOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            Validate(s, t, startIndex);

            // Follow the behavior of string.LastIndexOf(string) method. 
            if (t.Count == 0) return 0;
            if (s.Count == 0 || s.Count < t.Count) return -1;

            if (comparer == null) comparer = EqualityComparer<T>.Default;
            if (t.Count == 1) return LastIndexOf(s, t[0], startIndex, comparer);

            var table = BuildTable(t, comparer);
            var i = 0; // there is trouble with this line

            while (startIndex - i >= 0) // there is trouble with this line
            {
                if (comparer.Equals(t[t.Count - i - 1], s[startIndex - i]))
                {
                    if (i == t.Count - 1)
                        return startIndex - t.Count + 1;
                    i++;
                }
                else
                {
                    if (table[i] > -1)
                    {
                        startIndex -= i;
                        i = table[i];
                    }
                    else
                    {
                        startIndex--;
                        i = 0;
                    }
                }
            }
            return -1;
        }

        #endregion

        #region String (LastIndexOf)

        public static int LastIndexOf(this string s, IReadOnlyList<char> t)
        {
            return s.AsReadOnlyList().LastIndexOf(t, s == null ? -1 : s.Length - 1, EqualityComparer<char>.Default);
        }

        public static int LastIndexOf(this string s, IReadOnlyList<char> t, EqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().LastIndexOf(t, s == null ? -1 : s.Length - 1, comparer);
        }

        public static int LastIndexOf(this string s, IReadOnlyList<char> t, int startIndex)
        {
            return s.AsReadOnlyList().LastIndexOf(t, startIndex, EqualityComparer<char>.Default);
        }

        public static int LastIndexOf(this string s, IReadOnlyList<char> t, int startIndex, EqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().LastIndexOf(t, startIndex, comparer);
        }

        #endregion

        #region IReadOnlyList(T) (IndexesOf)

        public static IEnumerable<int> IndexesOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t)
            where T : IEquatable<T>
        {
            return s.IndexesOf(t, 0, EqualityComparer<T>.Default);
        }

        public static IEnumerable<int> IndexesOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            return s.IndexesOf(t, 0, comparer);
        }

        public static IEnumerable<int> IndexesOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex)
            where T : IEquatable<T>
        {
            return s.IndexesOf(t, startIndex, EqualityComparer<T>.Default);
        }

        public static IEnumerable<int> IndexesOf<T>(this IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            Validate(s, t, startIndex);

            if (comparer == null) comparer = EqualityComparer<T>.Default;
            if (t.Count == 1)
                return IndexesOf(s, t[0], startIndex, comparer);
            else
                return IndexesOfInteral(s, t, startIndex, comparer);
        }

        internal static IEnumerable<int> IndexesOfInteral<T>(IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var table = BuildTable(t, comparer);
            var i = 0;

            while (startIndex + i < s.Count)
            {
                if (comparer.Equals(t[i], s[startIndex + i]))
                {
                    if (i == t.Count - 1)
                    {
                        yield return startIndex;

                        startIndex++;
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
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
        }

        #endregion

        #region String (IndexesOf)

        public static IEnumerable<int> IndexesOf(this string s, IReadOnlyList<char> t)
        {
            return s.AsReadOnlyList().IndexesOf(t, 0, EqualityComparer<char>.Default);
        }

        public static IEnumerable<int> IndexesOf(this string s, IReadOnlyList<char> t, IEqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().IndexesOf(t, 0, comparer);
        }

        public static IEnumerable<int> IndexesOf(this string s, IReadOnlyList<char> t, int startIndex)
        {
            return s.AsReadOnlyList().IndexesOf(t, startIndex, EqualityComparer<char>.Default);
        }

        public static IEnumerable<int> IndexesOf(this string s, IReadOnlyList<char> t, int startIndex, IEqualityComparer<char> comparer)
        {
            return s.AsReadOnlyList().IndexesOf(t, startIndex, comparer);
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

        internal static void Validate<T>(IReadOnlyList<T> s, IReadOnlyList<T> t, int startIndex)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (t == null) throw new ArgumentNullException(nameof(t));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(s), "Value is less than zero.");

            if (startIndex >= s.Count)
                throw new ArgumentOutOfRangeException(nameof(s), "Value is greater than the length of s.");
        }

        internal static int IndexOf<T>(this IReadOnlyList<T> s, T t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var i = default(int);

            for (i = startIndex; i < s.Count; i++)
            {
                if (comparer.Equals(s[i], t))
                    return i;
            }
            return -1;
        }

        internal static int LastIndexOf<T>(IReadOnlyList<T> s, T t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var i = default(int);

            for (i = startIndex; i >= 0; i--)
            {
                if (comparer.Equals(s[i], t))
                    return i;
            }
            return -1;
        }

        internal static IEnumerable<int> IndexesOf<T>(IReadOnlyList<T> s, T t, int startIndex, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
        {
            var i = default(int);

            for (i = startIndex; i < s.Count; i++)
            {
                if (comparer.Equals(s[i], t))
                    yield return i;
            }
        }

        internal static int[] BuildTable<T>(IReadOnlyList<T> t, IEqualityComparer<T> comparer)
            where T : IEquatable<T>
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

        #endregion
    }
}