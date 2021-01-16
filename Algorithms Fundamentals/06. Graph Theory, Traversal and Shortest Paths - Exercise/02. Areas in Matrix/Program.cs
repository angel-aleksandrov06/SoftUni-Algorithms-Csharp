namespace _02._Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    public class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];

            var areas = new SortedDictionary<char, int>();
            var totalAreas = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (visited[r,c])
                    {
                        continue;
                    }

                    DFS(r, c);

                    totalAreas++;

                    if (!areas.ContainsKey(matrix[r,c]))
                    {
                        areas.Add(matrix[r, c], 1);
                    }
                    else
                    {
                        areas[matrix[r, c]]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {totalAreas}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            visited[row, col] = true;

            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();

            if (IsInside(row - 1, col) && IsChild(row, col, row-1, col) && !IsVisited(row -1, col))
            {
                children.Add(new Node { Row = row - 1, Col = col});
            }

            if (IsInside(row + 1, col) && IsChild(row, col, row + 1, col) && !IsVisited(row + 1, col))
            {
                children.Add(new Node { Row = row + 1, Col = col });
            }

            if (IsInside(row, col -1) && IsChild(row, col, row, col - 1) && !IsVisited(row, col - 1))
            {
                children.Add(new Node { Row = row, Col = col - 1 });
            }

            if (IsInside(row, col + 1) && IsChild(row, col, row, col + 1) && !IsVisited(row, col + 1))
            {
                children.Add(new Node { Row = row, Col = col + 1 });
            }

            return children;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol)
        {
            return matrix[parentRow, parentCol] == matrix[childRow, childCol];
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 &&
                   row < matrix.GetLength(0) &&
                   col >= 0 &&
                   col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}
