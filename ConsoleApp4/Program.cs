using System;
using System.Collections;

namespace ConsoleApp4
{
    class Programm
    {
        static void Main(string[] args)
        {
            // SecondSeminarDZ();
            var array = new int[] {1, 3, 5, 10, 60, 100, 1000, 2000};
            Console.WriteLine(binarySearch(5, array));


        }

        public static void SecondSeminarDZ()
        {
            ArrayList temp = new();
            DateTime dateTime = DateTime.Now;
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            foreach (int i in a)
                temp.Add(i);
            temp.Sort();

            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i, j] = (int)temp[count];
                    Console.Write(result[i, j]);
                    count++;
                }
                Console.WriteLine();
            }
        }

        private static int binarySearch(int value, int[] array) {
            int lowIndex = 0;
            int highIndex = array.Length - 1;

            while (lowIndex <= highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;

                if (array[middleIndex] == value)
                {
                    return middleIndex;
                }
                if (array[middleIndex] > value)
                {
                    highIndex = middleIndex - 1;
                }
                if (array[middleIndex] < value)
                {
                    lowIndex = middleIndex + 1;
                }
            }

            return -1;
        }

        private static int factorial(int value)
        {
            int result = 0;
            if ((value == 0) || (value == 1))
            {
                return 1;
            }
            if (value > 1)
            {
                result = value * factorial(value - 1);
                return result;
            }
        }
    }
}
