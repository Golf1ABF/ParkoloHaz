using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkolo
{
    internal class Emelet
    {
        public List<int> Szektorok { get; set; }
        public string SzintNeve { get; set; }
        public int SzintSzama { get; set; }

        public Emelet(string sor) 
        {
            this.Szektorok = new List<int>();
            string[] data = sor.Split("; ");
            this.SzintNeve = data[0];
            this.SzintSzama = 0;

            for (int i = 1; i < data.Length; i++) 
            {
                this.Szektorok.Add(int.Parse(data[i]));
                this.SzintSzama++;
            }
        }

        public override string ToString() 
        {
            string result = $"{SzintNeve, -12}";
            foreach (var letszam in Szektorok)
            {
                result += $"{letszam, -4}";
            }
            return result;
        }
    }
}
