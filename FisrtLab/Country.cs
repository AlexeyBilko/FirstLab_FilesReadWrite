using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisrtLab
{
    class Country
    {
        public string Name;
        public Rate rate;

        public Country(string n, Rate rate)
        {
            Name = n;
            this.rate = rate;
        }

        public void Print()
        {
            Console.Write($"Name: {Name} |||  Rate:");
            rate.Print();
            Console.WriteLine();
        }
    }
}
