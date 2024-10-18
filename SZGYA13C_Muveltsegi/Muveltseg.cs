using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA13C_Muveltsegi
{
    internal class Muveltseg
    {
        public string Kerdes { get; set; }
        public int Valasz { get; set; }
        public int Pont { get; set; }
        public string Tananyag { get; set; }

        public Muveltseg(string kerdes, int valasz, int pont, string tanagyag) 
        { 
            Kerdes = kerdes;
            Valasz = valasz;
            Pont = pont;
            Tananyag = tanagyag;
        }

        public static List<Muveltseg> FromFile(string path)
        {
            List<Muveltseg> muveltseg = new List<Muveltseg>();

            string[] line = File.ReadAllLines(path);

            foreach (var l in line)
            {
                string[] s = l.Split(';');

                string Kerdes = s[0];
                int Valasz = int.Parse(s[1]);
                int Pont = int.Parse(s[2]);
                string Tananyag = s[3];

                Muveltseg muveltsegek = new(Kerdes, Valasz, Pont, Tananyag);

                muveltseg.Add(muveltsegek);
            }
            return muveltseg;
        }

        public override string ToString()
        {
            return $"{Kerdes};{Valasz};{Pont};{Tananyag}";
        }
    }
}
