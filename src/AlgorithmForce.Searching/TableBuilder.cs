using System;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    class TableBuilder
    {
        internal static IReadOnlyList<int> BuildTable<T>(IReadOnlyList<T> t, IEqualityComparer<T> comparer)
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
    }
}