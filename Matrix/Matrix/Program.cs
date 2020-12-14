using System;

namespace Matrix
{
    public class Program
    {
        static void Main()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(3);

            SetMatrixByOne(squareMatrix, 3);

            GetMatrix(squareMatrix);

            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(3);

            SetMatrixByOne(diagonalMatrix, 3);

            GetMatrix(diagonalMatrix);

            squareMatrix.IndexChanger += Reaction;
            squareMatrix.IndexChanger += delegate (object sender, IndexChangerEventArgs<int> e)
            {
                Console.WriteLine(" Value [{0},{1}] is changed from {2} to {3} from anonymous method", e.IndexI, e.IndexJ, e.OldValue, e.NewValue);

            };

            squareMatrix.IndexChanger += (object sender, IndexChangerEventArgs<int> e) =>
            {
                Console.WriteLine(" Value [{0},{1}] is changed from {2} to {3} from lambda", e.IndexI, e.IndexJ, e.OldValue, e.NewValue);

            };

            squareMatrix[0, 1] = 7;

            GetMatrix(squareMatrix);

            Console.ReadKey();
        }

        private static void SetMatrixByOne(SquareMatrix<int> squareMatrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    squareMatrix[i, j] = 1;
                }
            }
        }

        private static void GetMatrix(SquareMatrix<int> squareMatrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(squareMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Reaction(object sender, IndexChangerEventArgs<int> e)
        {
            Console.WriteLine(" Value [{0},{1}] is changed from {2} to {3} from method", e.IndexI, e.IndexJ, e.OldValue, e.NewValue);
        }
    }
}
