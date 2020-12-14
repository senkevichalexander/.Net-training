using System;

namespace Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="matrixSize">size of array</param>
        public DiagonalMatrix(int matrixSize) : base(matrixSize)
        {
        }

        /// <summary>
        /// Creator and Reader for index of matrix
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>values of the matrix</returns>
        public override T this[int i, int j]
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

                if(i == j)
                {
                    return Array[i];
                }

                return default(T);
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
                
                if(i == j)
                {
                    if (!Array[i].Equals(value))
                    {
                        var oldValue = Array[i];
                        Array[i] = value;
                        OnChangeIndex(new IndexChangerEventArgs<T>(i, j, oldValue, value));
                    }                    
                }
            }
        }
    }
}
