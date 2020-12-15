using System;

namespace Matrix
{
    public class IndexChangerEventArgs<T> : EventArgs
    {
        /// <summary>
        ///Properties of each matrix element
        /// </summary>
        public int IndexI { get; }

        public int IndexJ { get; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="indexI">row index</param>
        /// <param name="indexJ">column index</param>
        public IndexChangerEventArgs(int indexI, int indexJ)
        {
            IndexI = indexI;
            IndexJ = indexJ;
        }
    }
}
