using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Emelet> list = new List<Emelet>();

            StreamReader sr = new StreamReader("../../../src/parkolohaz.txt");

            while (!sr.EndOfStream)
            {
                list.Add(new Emelet(sr.ReadLine()));
            }
            Console.WriteLine("Szint neve| 1.szektor| 2.szektor| 3.szektor| 4.szektor| 5.szektor| 6.szektor");

            for (int i = 0; i < list.Count; i++) { Console.WriteLine($"{i+1} szint {list[i]}"); }

            Console.WriteLine($"8.Feladat {list.MinBy(e => e.Szektorok.Sum()).SzintNeve}");

            Console.WriteLine($"9.Feladat {list.FirstOrDefault(e => e.Szektorok.Contains(0)).SzintSzama}");


            var atlag = list.Average(e => e.Szektorok.Average());
            Console.WriteLine($"10.Feladat Átlag: {list.Sum(e => e.Szektorok.Count(i => i == atlag))} Átlag alatti: {list.Sum(e => e.Szektorok.Count(i => i < atlag))} Átlag feletti: {list.Sum(e => e.Szektorok.Count(i => i > atlag))}");

            StreamWriter sw = new StreamWriter("../../../src/11feladat.txt");
            sw.WriteLine("11. Feladat");
            foreach (var item in list) 
            {
                foreach (var item1 in item.Szektorok)
                {
                    if (item1 == 1)
                    {
                        sw.WriteLine($"Emelet: {list.IndexOf(item) + 1} Szektor:    {item.Szektorok.IndexOf(item1) + 1}");
                    }
                }
            }
            
            Console.WriteLine("12.Feladat");
            var maxauto = list.OrderByDescending(e => e.Szektorok.Sum()).First();
            if (list.IndexOf(maxauto) == list.Count -1)
            {
                Console.WriteLine($"Legfelső emeleten van a legtöbb autó. {maxauto}");
            }
            else Console.WriteLine("Nem igaz hogy a legfelső emeleten van a legtöbb");

            sw.WriteLine("13.Feladat");

            var osszesszabad = 0;
            var emelet = 1;

            foreach(var item in list)
            {
                var szabadhely = 15 * 6 - item.Szektorok.Sum();
                sw.WriteLine($"{emelet}. emelet {szabadhely}");
                emelet++;
                osszesszabad += szabadhely;
            }
            sw.WriteLine($"14.Feladat \n Összesen: {osszesszabad} szabad hely van");

            sw.Close();
        }
    }
}
