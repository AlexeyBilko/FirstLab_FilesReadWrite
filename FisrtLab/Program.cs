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
            List<Country> list = new List<Country>();
            int tmp = 1;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (StreamReader cr = new StreamReader(fs))
            {
                while (!cr.EndOfStream)
                {
                    if (tmp == 1)
                    {

                    }
                    else
                    {
                        string str1 = cr.ReadLine();

                        string CountryName = str1.Substring(0, str1.IndexOf(","));

                        string buf = str1.Substring(str1.IndexOf(",") + 1);
                        string[] listTmp = buf.Split(',');

                        int[] listTmp1 = new int[10];
                        for (int i = 0; i < 10; i++)
                        {
                            listTmp1[i] = Convert.ToInt32(listTmp[i]);
                        }

                        Rate rate = new Rate(listTmp1.ToList());

                        Country country = new Country(CountryName, rate);

                        list.Add(country);


                    }
                    tmp++;
                }
            }

            foreach (var item in list)
            {
                item.Print();
            }
        }
    }
}
