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

            ListWithRatingfrom12to1(list);
        }

        static void ListWithRatingfrom12to1(List<Country> list)
        {
            for (int i = 0; i < 10; i++)
            {
                list = list.OrderBy(x => x.rate.list[i]).ToList();

                list[9].rate.list[i] = 12;
                list[8].rate.list[i] = 10;
                list[7].rate.list[i] = 8;
                list[6].rate.list[i] = 7;
                list[5].rate.list[i] = 6;
                list[4].rate.list[i] = 5;
                list[3].rate.list[i] = 4;
                list[2].rate.list[i] = 3;
                list[1].rate.list[i] = 2;
                list[0].rate.list[i] = 1;
            }

            Console.WriteLine();
            foreach (var item in list)
            {
                item.Print();
            }

            Winners(list);
        }

        static void Winners(List<Country> list)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            foreach (var item in list)
            {
                int sum = 0;
                foreach (var item1 in item.rate.list)
                {
                    sum += item1;
                }

                d.Add(item.Name, sum);
            }


            d = d.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            d.Reverse();


            Console.WriteLine();
            foreach (var item in d)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            SaveInFile(d);
        }

        static void SaveInFile(Dictionary<string, int> d)
        {
            List<string> final = new List<string>();
            int i = 10;
            foreach (var item in d)
            {
                final.Add(item.Key + " with total rating: " + item.Value + " | PLACE " + i);
                i--;
            }

            File.WriteAllText("OutPut.txt", "");

            foreach (var item in final)
            {
                File.AppendAllText("OutPut.txt", item + Environment.NewLine);
            }
        }
    }
}
