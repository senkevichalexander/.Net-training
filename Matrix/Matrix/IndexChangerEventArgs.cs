using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class IndexChangerEventArgs<T> : EventArgs
    {
        /// <summary>
        ///Properties of each matrix element
        /// </summary>
        public int IndexI { get; }

        public int IndexJ { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="indexI">row index</param>
        /// <param name="indexJ">column index</param>
        /// <param name="oldValue">old value of  the element</param>
        /// <param name="newValue">new value of the element</param>
        public IndexChangerEventArgs(int indexI, int indexJ, T oldValue, T newValue)
        {
            IndexI = indexI;
            IndexJ = indexJ;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
