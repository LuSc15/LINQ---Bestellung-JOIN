using System.Text.Json;
using System.Linq;

namespace LINQ___Bestellung_JOIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bestellung bestellteArtikel = new Bestellung();
            bestellteArtikel = JsonSerializer.Deserialize<Bestellung>(File.Open(@"JSON\bestellung.json", FileMode.Open));
           // string alleArtikelJson = File.ReadAllText(@"JSON\alleArtikel.json");
           
            Bestand bestand = new Bestand();
             bestand.AlleArtikel = JsonSerializer.Deserialize<List<Artikel>>(File.Open(@"JSON\alleArtikel.json", FileMode.Open));

            //Console.WriteLine("Bestellung:");
            //foreach(var item in bestellteArtikel.AllePositionen)
            //{
            //    Console.WriteLine($"{item.Id} {item.Artikelnummer} {item.Anzahl}");
            //}

            //Console.WriteLine("Bestand:");
            //foreach (var item in bestand.AlleArtikel)
            //{
            //    Console.WriteLine($"{item.Artikelnummer} {item.Name}  {item.Preis}");
            //}
            // Console.ReadLine();

            var LINQ = from Artikel in bestand.AlleArtikel
                       join Position in bestellteArtikel.AllePositionen
                       on Artikel.Artikelnummer equals Position.Artikelnummer
                       select new
                       {
                           preis = Artikel.Preis,
                           artikelname = Artikel.Name,
                           artikelnummer = Artikel.Artikelnummer,
                           anzahl = Position.Anzahl,
                           summe = Position.Anzahl * Artikel.Preis
                           
                       };
            Console.WriteLine("Bestellung verknüpft:");
            
            string ausgabe = "";
            foreach (var item in LINQ)
            {
                
                ausgabe = $"{item.artikelnummer,-4}\t{item.artikelname,-40}\t{item.anzahl,-8}\t{item.preis,5:F2} EUR";
                Console.WriteLine(ausgabe);
            }
            double summe = LINQ.Sum(x => x.summe);
           Console.WriteLine($"Gesamtpreis:{ summe:F2}");
            Console.ReadLine();
        }
    }
}
