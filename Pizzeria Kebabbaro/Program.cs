using System;
using System.Collections.Generic;

namespace PizzeriaKebabbaro
{


    class Program
    {
        static void Main_(string[] args)
        {
            Pizza margherita = new Pizza();
            margherita.Nome = "Margherita";
            var prezzo = margherita.CalcolaPrezzo();
            Console.WriteLine($"Prezzo pizza {margherita.Nome}: {prezzo}");

            Pizza quattroFormaggi = new Pizza();
            quattroFormaggi.Nome = "4 formaggi";
            quattroFormaggi.Ingredienti.AddRange(new List<string>(){ "Tofu", "Segatura", "Humor" });
            var prezzoQF = quattroFormaggi.CalcolaPrezzo();
            Console.WriteLine($"Prezzo pizza {quattroFormaggi.Nome}: {prezzoQF}");

            Console.WriteLine();
            
            var cassa = new Cassa();
            cassa.Pizze.AddRange(new List<Pizza>() { margherita, quattroFormaggi });
            
            var prezzoScontrino = cassa.Vendi();
            Console.WriteLine($"Prezzo scontrino: {prezzoScontrino} Euro.");

            Console.ReadKey();
        }
    }
}
