using System.Collections;

namespace ConsoleApp4
{
    internal class DZ
    {
        /// <summary>
        /// A console calculator application that accepts values like a + b, a - b, a / b, a * b, where integers are used.
        /// To use it you need to run ConsoleApp4.exe <parameters where the delimiter is a space>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static void FirstSeminarDZ(string[] args)
        {
            // Console.WriteLine("Введите чисто типа a+b,a-b,a*b,a/b");
            int firstNum = 0;
            int secondNum = 0;
            string operation = string.Empty;
            int result = 0;


            bool first = false;
            bool second = false;
            bool o = false;
            foreach (var item in args)
            {
                if (!first && int.TryParse(item, out int res1))
                {
                    firstNum = res1;
                    first = true;
                }
                else
                if (!second && int.TryParse(item, out int res2))
                {
                    secondNum = res2;
                    second = true;
                }
                else
                if (!o)
                {
                    if (item == "+") { operation = "+"; o = true; }
                    else if (item == "-") { operation = "-"; o = true; }
                    else if (item == "*") { operation = "*"; o = true; }
                    else if (item == "/") { operation = "/"; o = true; }
                }
            }

            switch (operation)
            {
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "/":
                    result = firstNum / secondNum;
                    break;
            }

            Console.WriteLine($"a {operation} b = {result}");
        }

        /// <summary>
        /// Дан двумерный массив.
        /// 732
        /// 496
        /// 185
        /// Отсортировать данные в нем по возрастанию.
        /// 123
        /// 456
        /// 789
        /// </summary>
        public static void SecondSeminarDZ()
        {
            ArrayList temp = new();
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
                    result[i,j] = (int)temp[count];
                    Console.Write(result[i, j]);
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}