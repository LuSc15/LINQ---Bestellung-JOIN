using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___Bestellung_JOIN
{
    public class Bestellung
    {
        public List<Position> AllePositionen { get; set; }
    }
        public class Position
        {
            public int Id { get; set; }
            public int Artikelnummer { get; set; }
            public int Anzahl { get; set; }
        }

}
