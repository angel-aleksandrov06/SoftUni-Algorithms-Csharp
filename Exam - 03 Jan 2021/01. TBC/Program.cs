namespace _01._TBC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);
            int tunnels = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 't')
                    {
                        FindTunnels(matrix, r, c);
                        tunnels++;
                    }

                }
            }

            Console.WriteLine(tunnels);
        }

        private static void FindTunnels(char[,] matrix, int row, int col)
        {
            if (!CanMove(matrix, row, col))
            {
                return;
            }

            matrix[row, col] = 'v';

            FindTunnels(matrix, row - 1, col); //up
            FindTunnels(matrix, row + 1, col); //down
            FindTunnels(matrix, row, col - 1); //left
            FindTunnels(matrix, row, col + 1); //right
            FindTunnels(matrix, row - 1, col - 1);//up-left
            FindTunnels(matrix, row - 1, col + 1);//up-right
            FindTunnels(matrix, row + 1, col - 1);//down-left
            FindTunnels(matrix, row + 1, col + 1);//down-right
        }

        private static bool CanMove(char[,] matrix, int r, int c)
        {
            return r >= 0 && r < matrix.GetLength(0) &&
                   c >= 0 && c < matrix.GetLength(1) &&
                   matrix[r, c] == 't';
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < colElements.Length; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            return matrix;
        }
    }
}
