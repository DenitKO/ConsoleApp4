namespace ConsoleApp4.SelfLearningAndTesting.Polymorphism
{
    /*
     * Полиморфизм
     * 
     * Виртуальные методы
     * 
     * virtual
     * Чтобы была возможность переопределить метод базавого класса, 
     * нужно добавить ему модификатор virtual.
     * Если метод private то мы не можем сделать его virtual,
     * в этом просто нет смысла, потому что мы не можем получить
     * к нему доступ в классе наследнике.
     * 
     * override
     * Переопределять можно только абстактные или виртуальные методы
     */
    internal class VirtualMethod
    {
    }

    class Car
    {
        protected virtual void StartEngien()
        {
            Console.WriteLine("Запуск двигаетля");
        }
        public virtual void Drive()
        {
            StartEngien();
            Console.WriteLine($"{GetType().Name}: Я машина, я еду!");
        }
    }

    class SportCar : Car
    {
        protected override void StartEngien()
        {
            Console.WriteLine("Рон дон дон!");
        }
        public override void Drive()
        {
            // base.Drive();
            // Можно вызвать метод базового класса при помощи ключевого слова base
            StartEngien();
            Console.WriteLine($"{GetType().Name}: Я спорткар, я быстро еду");
        }
    }

    class Person
    {
        public void Drive(Car car)
        {
            car.Drive();
        }
    }
}
