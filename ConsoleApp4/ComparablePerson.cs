using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class ComparablePerson : IComparable
    {
        public ComparablePerson() { }
        public ComparablePerson(int age, double height, double weight) 
        {
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public int age;
        public double height;
        public double weight;

        public int CompareTo(object? obj)
        {
            ComparablePerson p = obj as ComparablePerson;

            if (p != null)
            {
                if (this.age > p.age) 
                { 
                    return -1; 
                }
                else if (this.age < p.age)
                { 
                    return 1; 
                }
                else 
                { 
                    return 0; 
                }
            }
            else 
            { 
                throw new Exception("Параметр должен быть типа ComparablePerson"); 
            }
        }
    }
}
