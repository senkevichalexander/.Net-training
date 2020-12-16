using System;

namespace Matrix
{
    public class Program
    {
        private const int _size = 10;
        private const int _newValue = 7;
        private const int _number = 8;

        static void Main()
        {   
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(_size);

            SetMatrix(squareMatrix, _size, _number);

            Console.WriteLine(squareMatrix.ToString());

            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_size);

            SetMatrix(diagonalMatrix, _size, _number);

            Console.WriteLine(diagonalMatrix.ToString());

            squareMatrix.IndexChanger += Reaction;
            squareMatrix.IndexChanger += delegate (object sender, IndexChangerEventArgs<int> e)
            {
                Console.WriteLine(" Value [{0},{1}] is changed from anonymous method", e.IndexI, e.IndexJ);

            };

            squareMatrix.IndexChanger += (object sender, IndexChangerEventArgs<int> e) =>
            {
                Console.WriteLine(" Value [{0},{1}] is changed from lambda", e.IndexI, e.IndexJ);

            };

            squareMatrix[0, 1] = _newValue;

            Console.WriteLine(squareMatrix.ToString()); 
        }

        private static void SetMatrix(SquareMatrix<int> squareMatrix, int size, int number)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    squareMatrix[i, j] = number;
                }
            }
        }

        private static void Reaction(object sender, IndexChangerEventArgs<int> e)
        {
            Console.WriteLine(" Value [{0},{1}] is changed", e.IndexI, e.IndexJ);
        }
    }
}
