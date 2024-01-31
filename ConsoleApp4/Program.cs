using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Text;
using ConsoleApp4.SelfLearningAndTesting;
using ConsoleApp4.SelfLearningAndTesting.Inheritance;
using ConsoleApp4.SelfLearningAndTesting.Polymorphism;

namespace ConsoleApp4
{

    delegate int MyDelegat();
    delegate void MyStringDelegat(string s);
    class Program
    {
        static void Main(string[] args)
        {


            Lection5_1();

            // Calculator();

            // ExtendetCSharpLection1();

            // TypeConvertsion();

            // VirtualMethod();

            #region Polymorphism (Virtual methods, AbstractClass)
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
            //Console.WriteLine(testClass3._index);
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

        static void Lection5_1()
        {
            MyDelegat? myDelegat = SayHello;
            myDelegat += SayBye;
            myDelegat += SayBye;
            Console.WriteLine($"В делегате вот столько методов: {myDelegat.GetInvocationList().Length}");
            Console.WriteLine();

            foreach (MyDelegat item in myDelegat.GetInvocationList())
            {
                Console.WriteLine(item.GetType().Name);
                
                Console.WriteLine(item());
            }

            Console.WriteLine();

            myDelegat();
            Console.WriteLine();
            Console.WriteLine(myDelegat());
            Console.WriteLine("----------------------------");
            MyStringDelegat myDelegat2 = MyName;
            myDelegat2 -= MyName;
            myDelegat2?.Invoke("Denis");
            Console.WriteLine("----------------------------");


            static int SayHello()
            {
                Console.WriteLine("Привет!");
                return 0;
            }

            static int SayBye()
            {
                Console.WriteLine("Пока");
                return 1;
            }

            static void MyName(string name)
            {
                Console.WriteLine($"my name is {name}");
            }
        }

        public static void Calculator()
        {
            Calculator calculator = new Calculator();
            calculator.Result += Calculator_Result;

            calculator.Add(10);
            calculator.Add(20);
            calculator.Div(3);



            static void Calculator_Result(object? sender, CalculatorArgs e)
            {
                Console.WriteLine($"result: {e.answer}");
            }

        }

        public static void ExtendetCSharpLection1()
        {
            Human[] humans = { new Man(), new Woman(), new Man() };
            foreach (var human in humans)
            {
                Woman w = human as Woman;
                w?.MakeUp();

                if (human is Woman woman)
                {
                    if (!woman.IsMakeup())
                        woman.MakeUp();
                    else woman.MakeDown();
                }

                human.Info();
            }
        }

        public static void TypeConvertsion()
        {
            object obj = new MyPoint { X = 3, Y = 5 };
            Console.WriteLine(obj.GetType());
            Console.WriteLine();
            /*
             * obj.Print(); не работает, потому что сделан DownCast. И тип object ничего не знает о MyPoint
             * MyPoint myPoint1 = (MyPoint)obj; // А так сработает.
             * myPoint1.Print();
             * Это UpCast. Мы выполнили явное приведение типов
             * UpCast возможен только полсе DownCast-а
             * но явнове приведение типа таким образом (SomeType)someVar
             * вывалится в исключение InvalidCastExeption если будет передан не тот тип
             * Поэтому придумали as, is
             */

            MyPoint myPoint1 = obj as MyPoint;
            // оператор as присвоит левому операнду значение null
            // если приведение типов не сработает
            // иначе приведение типов сработает

            Console.WriteLine("construction - obj as MyPoint");
            Console.WriteLine("if (myPoint1 != null) {}");

            if (myPoint1 != null)
            {
                myPoint1.Print();
            }

            // и РАНЬШЕ, где то до 7 версии смысла использовать следующую
            // конструкция небыло

            Console.WriteLine();
            Console.WriteLine("construction - obj is MyPoint");

            if (obj is MyPoint)
            {
                MyPoint myPoint2 = (MyPoint)obj;
                myPoint2.Print();
            }

            // Но сейчас предпочтительней использовать is

            Console.WriteLine();
            Console.WriteLine("construction - obj is MyPoint point");

            if (obj is MyPoint point)
            {
                point.Print();
            }

            //MyPoint obj2 = new MyPoint { Y = 3, X = 4 };
            //Console.WriteLine(obj2.GetType());
            //obj2.Print();
        }

        public static void VirtualMethod()
        {
            Person person = new Person();

            person.Drive(new Car());
            Console.WriteLine();
            person.Drive(new SportCar());
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
            // First myDelegat always too large, I woder why?
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
