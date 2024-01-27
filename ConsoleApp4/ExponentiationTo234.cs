using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class ExponentiationTo234
    {
        // public int number { get; private set; }
        int number { get; set; }
        // private readonly int number;


        public ExponentiationTo234(int number) 
        {
            this.number = number;
        }


        public override string ToString() 
        { 
            return number.ToString();
        }

        public decimal Exp2()
        {
            return this.number*this.number;
        }

        public decimal Exp3()
        {
            return this.number * this.number * this.number;
        }

        public decimal Exp4()
        {
            return this.number * this.number * this.number * this.number;
        }
    }
}
