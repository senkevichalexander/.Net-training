using System;

namespace Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="matrixSize">size of array</param>
        public DiagonalMatrix(int matrixSize) : base(matrixSize, typeof(DiagonalMatrix<T>))
        {
            Array = new T[matrixSize];  
        }

        /// <summary>
        /// Get and set matrix size
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>matrix</returns>
        public override T this[int i, int j]
        {
            get
            {
                if (IsSizeNotValid(i, j))
                {
                    throw new ArgumentOutOfRangeException();
                }

                if(i == j)
                {
                    return Array[i];
                }

                return default(T);
            }
            set
            {
                if (IsSizeNotValid(i, j) && i != j)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                if(i == j)
                {
                    if (!Array[i].Equals(value))
                    {
                        Array[i] = value;
                        OnChangeIndex(new IndexChangerEventArgs<T>(i, j));
                    } 
                }
            }
        }
    }
}
