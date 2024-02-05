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
        }
    }
}
