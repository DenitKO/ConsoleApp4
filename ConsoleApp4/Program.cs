using System;
using System.Collections;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp4
{
    class Programm
    {
        static void Main(string[] args)
        {
            // SecondSeminarDZ();
            var array = new int[] {1, 3, 5, 10, 60, 100, 1000, 2000};
            // Console.WriteLine(binarySearch(5, array));
            // Console.WriteLine(factorial(20));


            // var text = MeasurePerformance(10, () => factorial(20));
            var text = MeasurePerformance(10, () => binarySearch(5, array));
            // var text = MeasurePerformance(10, () => SecondSeminarDZ());
            Console.WriteLine($"finish ms: {text}");
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

        private static long MeasurePerformance(int iterations, Action action)
        {
            // First action always too large, I woder why?
            action();
            long result = 0;
            var stopwatch = new Stopwatch();
            for (var i = 0; i < iterations; i++)
            {
                stopwatch.Start();
                action();
                stopwatch.Stop();
                result += stopwatch.ElapsedTicks;
                Console.WriteLine($"Iteration {i+1}. Ticks: {stopwatch.ElapsedTicks}. ms: {stopwatch.ElapsedMilliseconds}");
                stopwatch.Reset();
            }
            Console.WriteLine($"Iterations: {iterations}, TotalTiks: {result}");
            Console.WriteLine($"AVG Ticks: {result/iterations}");
            result /= iterations;
            return result;
            
        }


        private static long factorial(long value)
        {
            if ((value == 0) || (value == 1))
            {
                return 1;
            }

            return value * factorial(value - 1);
        }
    }
}
