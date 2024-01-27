using System.ComponentModel.DataAnnotations;

namespace ConsoleApp4.ExtendedCS.Lections.Lection1
{
    internal class Person
    {
        private string _name { get; set; }
        private DateOnly _date { get; set; }
        private Person _fother { get; set; }
        private Person _mother { get; set; }
        private Person[] _childrens { get; set; }

        public Person(string name) 
        {
            this._name = name;
            // _date = DateTime.Now.Date;
        }
    }
}
