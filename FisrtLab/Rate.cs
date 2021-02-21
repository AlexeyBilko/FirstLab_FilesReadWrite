using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisrtLab
{
    class Rate
    {
        public List<int> list;

        public Rate(List<int> list)
        {
            this.list = list;
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
