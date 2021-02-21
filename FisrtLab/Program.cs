using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisrtLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\38098\source\repos\FisrtLab\FisrtLab\obj\Debug\Introduction-To-Programming\labs_spring_2020\examples_2\var1\eurovision1.csv";
            ReadFromFile(path);
        }

        static void ReadFromFile(string path)
        {
            string text = File.ReadAllText(path);
            string[] lines = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<Country> list = new List<Country>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i != 0)
                {
                    string CountryName = lines[i].Substring(0, lines[i].IndexOf(","));

                    string buf = lines[i].Substring(lines[i].IndexOf(",") + 1);
                    string[] listTmp = buf.Split(',');


                    int[] listTmp1 = new int[10];
                    for (int j = 0; j < 10; j++)
                    {
                        listTmp1[j] = Convert.ToInt32(listTmp[j]);
                    }

                    Rate ratetmp = new Rate(listTmp1.ToList());

                    Country country = new Country(CountryName, ratetmp);

                    list.Add(country);
                }
            }

            foreach (var item in list)
            {
                item.Print();
            }
        }
    }
}
