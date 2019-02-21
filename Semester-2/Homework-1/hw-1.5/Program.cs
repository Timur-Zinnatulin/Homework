using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_1._5
{
    class Program
    {
        static void SwapColumns(int[,] matrix, int column1, int column2)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int temp = matrix[i, column1];
                matrix[i, column1] = matrix[i, column2];
                matrix[i, column2] = temp;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimensions of a matrix: ");
            var dimensions = (Console.ReadLine().Split(' '));
            var matrix = new int[Convert.ToInt32(dimensions[0]), Convert.ToInt32(dimensions[1])];
            Console.WriteLine("Enter the contents of a matrix.");
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                var values = (Console.ReadLine().Split(' '));
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }
            Console.WriteLine("__________________");
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                int minColumn = j;
                int minHead = matrix[0, j];
                for (int k = j + 1; k < matrix.GetLength(1); ++k)
                {
                    if (matrix[0, k] < minHead)
                    {
                        minHead = matrix[0, k];
                        minColumn = k;
                    }
                }
                if (minColumn != j)
                {
                    SwapColumns(matrix, j, minColumn);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}