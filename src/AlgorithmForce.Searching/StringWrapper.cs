using System.Collections;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    class StringWrapper : IReadOnlyList<char>
    {
        #region Fields

        private readonly string _str;

        #endregion

        #region Properties

        char IReadOnlyList<char>.this[int index] => _str[index];

        int IReadOnlyCollection<char>.Count => _str.Length;

        #endregion

        #region Constructor

        public StringWrapper(string str)
        {
            _str = str;
        }

        #endregion

        #region Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_str as IEnumerable<char>).GetEnumerator();
        }

        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return (_str as IEnumerable<char>).GetEnumerator();
        }

        #endregion

        #region Others

        public override string ToString()
        {
            return _str;
        }

        public override bool Equals(object obj)
        {
            if (obj is StringWrapper wrapper)
                return string.Equals(_str, wrapper._str);
            return false;
        }

        public override int GetHashCode()
        {
            return _str.GetHashCode();
        }

        #endregion
    }
}
