using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    class ListWrapper<T> : IReadOnlyList<T>
        where T : IEquatable<T>
    {
        #region Fields

        private readonly IList<T> _list;

        #endregion

        #region Properties

        public T this[int index] => _list[index];

        public int Count => _list.Count;

        public bool IsReadOnly => true;

        #endregion

        #region Constructor

        public ListWrapper(IList<T> list)
        {
            _list = list;
        }

        #endregion

        #region Others

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
