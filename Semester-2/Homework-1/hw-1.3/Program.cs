using System;

namespace hw_1._3
{
    class Program
    {
        private static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        int swap = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = swap;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            int[] array = { 18, 124, 13, 2, -15, 88, 69, 332, 84 };
            BubbleSort(array);
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
