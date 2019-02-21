using System;

namespace hw_1._4
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    Console.Write($"{matrix[i, j],-4}");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var matrix = new int[,] { { 25, 10, 11, 12, 13 }, { 24, 9, 2, 3, 14 }, { 23, 8, 1, 4, 15 },
                                    { 22, 7, 6, 5, 16 }, { 21, 20, 19, 18, 17 } };
            PrintMatrix(matrix);
            Console.WriteLine();
            var vertical = matrix.GetLength(0) / 2;
            var horizontal = matrix.GetLength(0) / 2;
            for (int i = matrix.GetLength(0) / 2 + 1; i > 0; --i)
            {
                while (horizontal < matrix.GetLength(0) - i)
                {
                    Console.Write($"{matrix[vertical, horizontal]} ");
                    ++horizontal;
                }
                while (vertical < matrix.GetLength(0) - i)
                {
                    Console.Write($"{matrix[vertical, horizontal]} ");
                    ++vertical;
                }
                while (horizontal > i - 1)
                {
                    Console.Write($"{matrix[vertical, horizontal]} ");
                    --horizontal;
                }
                while (vertical >= i - 1)
                {
                    Console.Write($"{matrix[vertical, horizontal]} ");
                    --vertical;
                }
                Console.WriteLine($"| Cycle {matrix.GetLength(0) / 2 - i + 1} complete.");
            }
        }
    }
}
