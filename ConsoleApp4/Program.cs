using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Text;
using ConsoleApp4.SelfLearningAndTesting;
using ConsoleApp4.SelfLearningAndTesting.AbstractClass;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CleanPolimorphism and AbstractClass
            // AbstractClassAndMethodExample();
            #endregion

            #region Date Type
            //DateTime dateTime = DateTime.Now;
            //DateTime myDate = DateTime.Parse("31-03-1990");
            //Console.WriteLine(dateTime>myDate);
            #endregion

            #region NewClass - Exponentation to 2, 3, 4
            //var num = 4;
            //ExponentiationTo234 exp = new ExponentiationTo234(num);
            //Console.WriteLine(exp);
            //Console.WriteLine($"{exp} в 2 = {exp.Exp2()}\n{exp} в 3 = {exp.Exp3()}\n{exp} в 4 = {exp.Exp4()}");
            #endregion

            // ComparablePerson();

            // FromMinSortDictionary();

            #region Start TestClass1Seminar1_1
            //TestClassSeminar1_1 testClass = new("Денис");
            //TestClassSeminar1_1 testClass2 = new("Оля");
            //TestClassSeminar1_1 testClass3 = new("Абырвалг");
            //Console.WriteLine(testClass.GetReverseName());
            //Console.WriteLine(testClass2.GetReverseName());
            //Console.WriteLine(testClass3.GetReverseName());
            //Console.WriteLine(testClass3.index);
            //testClass.Print("It's work!");
            //Console.WriteLine();
            //var text = MeasurePerformance(10, () => testClass.GetReverseName());
            #endregion

            #region String and StringBuilder Perfomance
            // var text = MeasurePerformance(1, () => LongConcatination(100));
            // Console.WriteLine();
            // var text1 = MeasurePerformance(1, () => ShortConcatination(10000));
            #endregion

            #region SecondSeminarDZ and MeasurePerformance
            // SecondSeminarDZ();
            // var text = MeasurePerformance(10, () => SecondSeminarDZ());
            #endregion

            #region Binary Search and Measure Performance
            //var array = new int[] { 1, 3, 5, 10, 60, 100, 1000, 2000 };

            //Console.WriteLine(binarySearch(5, array));
            //Console.WriteLine();
            //var text = MeasurePerformance(10, () => binarySearch(5, array));
            #endregion

            #region factorial and Measure Performance
            // Console.WriteLine(factorial(20));
            //var text = MeasurePerformance(10, () => factorial(20));
            #endregion

        }

        public static void AbstractClassAndMethodExample() 
        {
            Player player = new Player();

            Weapon[] weapons = [new Gun(), new LaserGun(), new Bow()];

            foreach (Weapon item in weapons)
            {
                player.CheckInfo(item);
                player.Fire(item);
                Console.WriteLine();

            }
        }

        public static void ComparablePerson()
        {
            ComparablePerson[] persons = new ComparablePerson[10];

            Random r = new Random();

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new ComparablePerson(r.Next(1, 95), r.Next(30, 190), r.Next(20, 95));

                Console.WriteLine($"age: {persons[i].age} height: {persons[i].height} weight: {persons[i].age}");
            }

            Array.Sort(persons);

            Console.WriteLine(new string('-', 30));

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine($"age: {persons[i].age} height: {persons[i].height} weight: {persons[i].age}");
            }

            Console.ReadKey();
        }

        public static void FromMinSortDictionary()
        {
            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = new Random().Next(6);
                Console.Write($"{nums[i]}");
            }
            Console.WriteLine();

            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if (map.ContainsKey(i))
                    map[i]++;
                else
                    map[i] = 0;
            }

            Dictionary<int, int> ordered = map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in ordered.Keys)
            {
                Console.WriteLine($"{item}: {map[item]}");
            }
        }

        public static void LongConcatination(int count)
        {
            string str = string.Empty;
            for (int i = 0; i < count; i++)
            {
                str = str + '+';
            }
            Console.WriteLine(str);
        }

        public static void ShortConcatination(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append('+');
            }
            Console.WriteLine(sb.ToString());
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

        private static int binarySearch(int value, int[] array)
        {
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

        private static double MeasurePerformance(int iterations, Action action)
        {
            // First action always too large, I woder why?
            action();
            double elapsedTicks = 0;
            double elapsedMS = 0;
            var stopwatch = new Stopwatch();

            for (var i = 0; i < iterations; i++)
            {
                stopwatch.Start();
                action();
                stopwatch.Stop();

                elapsedTicks += stopwatch.ElapsedTicks;
                elapsedMS += stopwatch.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Iteration {i + 1}; Ticks: {stopwatch.ElapsedTicks}; ms: {stopwatch.Elapsed.TotalNanoseconds}.");
                stopwatch.Reset();
            }
            Console.WriteLine($"Iterations: {iterations}; TotalTiks: {elapsedTicks}; TotalMilliseconds:{elapsedMS}.");
            elapsedTicks /= iterations;
            elapsedMS /= iterations;
            Console.WriteLine($"AVG_Ticks: {elapsedTicks}; AVG_MS: {elapsedMS}.");
            return elapsedTicks;
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

    class A
    {
        public virtual void Foo() => Console.WriteLine("Class A");
    }
    class B : A
    {
        public override void Foo() => Console.WriteLine("Class B");
    }
}
