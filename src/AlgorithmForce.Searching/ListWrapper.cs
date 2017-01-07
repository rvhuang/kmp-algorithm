using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    class ListWrapper<T> : IReadOnlyList<T>
        where T : IEquatable<T>
    {
        #region Fields

        private readonly IList<T> list;

        #endregion

        #region Properties

        public T this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        #endregion

        #region Constructor

        public ListWrapper(IList<T> list)
        {
            this.list = list;
        }

        #endregion

        #region Others

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion
    }
}
