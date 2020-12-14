using System;

namespace Matrix
{
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Array for data storage
        /// </summary>
        private readonly T[] array;
        
        /// <summary>
        /// Size of the matrix
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="matrixSize">size</param>
        public SquareMatrix(int matrixSize)
        {
            if(matrixSize < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Size = matrixSize;
            array = new T[matrixSize * matrixSize];
        }

        /// <summary>
        /// Creator and Reader for index of matrix
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>values of the matrix</returns>
        public virtual T this [int i, int j]
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

                return array[Size * i + j];
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

                if(!array[Size * i + j].Equals(value))
                {
                    var oldValue = array[Size * i + j];
                    array[Size * i + j] = value;
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
