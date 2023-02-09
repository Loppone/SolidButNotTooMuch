using System;
using System.Collections.Generic;

namespace PizzeriaBellaNapoli
{


    class Program
    {
        static void Main(string[] args)
        {
            var margherita = new PizzaMargherita();
            margherita.Nome = "Margherita";
            var prezzo = margherita.CalcolaPrezzo();
            Console.WriteLine($"Prezzo pizza {margherita.Nome}: {prezzo}");

            var marinara = new PizzaMarinara();
            marinara.Nome = "Marinara";
            var prezzoM = marinara.CalcolaPrezzo();
            Console.WriteLine($"Prezzo pizza {marinara.Nome}: {prezzo}");


            var quattroFormaggi = new PizzaQuattroFormaggi();
            quattroFormaggi.Nome = "4 formaggi";
            quattroFormaggi.Ingredienti.AddRange(new List<string>(){ "Tofu", "Segatura", "Humor" });
            var prezzoQF = quattroFormaggi.CalcolaPrezzo();
            Console.WriteLine($"Prezzo pizza {quattroFormaggi.Nome}: {prezzoQF}");

            Console.WriteLine();

            var weLogger = new WeekendLoggerRefactored();
            weLogger.WhatDayIsNow = 6;
            var cassa = new Cassa(new StampaPdf(), weLogger);
            cassa.Pizze.AddRange(new List<IPizza>() { margherita, quattroFormaggi, marinara });
            
            var prezzoScontrino = cassa.Vendi();
            Console.WriteLine($"Prezzo scontrino: {prezzoScontrino} Euro.");

            Console.ReadKey();
        }
    }
}
