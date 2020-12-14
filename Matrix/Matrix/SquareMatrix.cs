using System;

namespace Matrix
{
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Array for data storage
        /// </summary>
        protected T[] Array { get; set; }

        /// <summary>
        /// Size of the matrix
        /// </summary>
        protected int Size { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="matrixSize">size</param>
        public SquareMatrix(int matrixSize)
        {
            if (matrixSize < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Size = matrixSize;
            Array = new T[matrixSize * matrixSize];
        }

        /// <summary>
        /// Creator and Reader for index of matrix
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>values of the matrix</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return Array[Size * i + j];
            }
            set
            {
                if (i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (!Array[Size * i + j].Equals(value))
                {
                    var oldValue = Array[Size * i + j];
                    Array[Size * i + j] = value;
                    OnChangeIndex(new IndexChangerEventArgs<T>(i, j, oldValue, value));
                }
            }
        }

        /// <summary>
        /// Create event
        /// </summary>
        public event EventHandler<IndexChangerEventArgs<T>> IndexChanger;

        /// <summary>
        /// Method for set and get matrix
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeIndex(IndexChangerEventArgs<T> e) => IndexChanger?.Invoke(this, e);
    }
}
