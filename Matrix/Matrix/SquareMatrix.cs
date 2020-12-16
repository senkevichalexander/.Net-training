using System;
using System.Text;

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
        public int Size { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="matrixSize">size</param>
        public SquareMatrix(int matrixSize, Type type)
        {
            if (matrixSize <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Size = matrixSize;

            if (typeof(SquareMatrix<T>) == type)
            {
                Array = new T[Size * Size];
            }
        }
        /// <summary>
        /// Constructor is changed
        /// </summary>
        /// <param name="matrixSize">size</param>
        public SquareMatrix(int matrixSize) : this(matrixSize, typeof(SquareMatrix<T>))
        {
        }


        /// <summary>
        /// Represents martix in string format
        /// </summary>
        /// <returns>matrix in string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(16);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append(this[i, j]);
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Check data is valid
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>check</returns>
        protected bool IsSizeNotValid(int i, int j)
        {
            return ((i < 0 || i >= Size) && (j < 0 || j >= Size));
        }

        /// <summary>
        /// Get and set matrix indexes
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>values of the matrix</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (IsSizeNotValid(i, j))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return Array[Size * i + j];
            }
            set
            {
                if (IsSizeNotValid(i, j))
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (!Array[Size * i + j].Equals(value))
                {
                    Array[Size * i + j] = value;
                    OnChangeIndex(new IndexChangerEventArgs<T>(i, j));
                }
            }
        }

        /// <summary>
        /// Create event
        /// </summary>
        public event EventHandler<IndexChangerEventArgs<T>> IndexChanger;

        /// <summary>
        /// Method for set matrix
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeIndex(IndexChangerEventArgs<T> e) => IndexChanger?.Invoke(this, e);
    }
}
