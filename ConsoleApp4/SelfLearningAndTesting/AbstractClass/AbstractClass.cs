namespace ConsoleApp4.SelfLearningAndTesting.AbstractClass
{
    /*
        полиморфизм

        абстрактный класс

        абстрактный метод

        абстрактное свойство

    ----------------------------
    Вопросы:
        1. Почему метод GetType из метода ShowInfo из абстрактного класса Weapon
        Выводит имя класса наследника а не свой родительский класс

        2.
    */

    internal class AbstractClass
    {

    }

    abstract class Weapon
    {
        public abstract int Damage { get; }
        public abstract void Fire();

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }
    }

    class Gun : Weapon
    {
        public override int Damage { get { return 5; } }

        public override void Fire()
        {
            Console.WriteLine("Пыщ!");
        }
    }

    class LaserGun : Weapon
    {
        public override int Damage => 7;

        public override void Fire()
        {
            Console.WriteLine("Пиу!");
        }
    }

    class Bow : Weapon
    {
        public override int Damage => 3;

        public override void Fire()
        {
            Console.WriteLine("Чпуньк!");
        }
    }

    class Player
    {
        public void Fire(Weapon weapon)
        {
            weapon.Fire();
        }

        public void CheckInfo(Weapon weapon)
        {
            weapon.ShowInfo();
        }
    }
}
