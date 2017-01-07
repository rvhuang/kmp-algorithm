using System.Collections;
using System.Collections.Generic;

namespace AlgorithmForce.Searching
{
    class StringWrapper : IReadOnlyList<char>
    {
        #region Fields

        private readonly string str;

        #endregion

        #region Properties

        char IReadOnlyList<char>.this[int index]
        {
            get { return this.str[index]; }
        }

        int IReadOnlyCollection<char>.Count
        {
            get { return this.str.Length; }
        }

        #endregion

        #region Constructor

        public StringWrapper(string str)
        {
            this.str = str;
        }

        #endregion

        #region Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this.str as IEnumerable<char>).GetEnumerator();
        }

        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return (this.str as IEnumerable<char>).GetEnumerator();
        }

        #endregion

        #region Others

        public override string ToString()
        {
            return this.str;
        }

        public override bool Equals(object obj)
        {
            if (obj is StringWrapper)
                return string.Equals(this.str, (obj as StringWrapper).str);
            else
                return false; 
        }

        public override int GetHashCode()
        {
            return this.str.GetHashCode();
        }

        #endregion
    }
}
