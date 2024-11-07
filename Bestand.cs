using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___Bestellung_JOIN
{
    internal class Bestand
    {
        public List<Artikel> AlleArtikel { get; set; }
    }
    public class Artikel
    {
            public int Artikelnummer { get; set; }
            public string Name { get; set; }
            public int Preis { get; set; }
   
    }
}
