using System;
using System.Collections.Generic;

namespace PizzeriaBellaNapoli
{
    [Obsolete]
    public class Printer
    {
        public TipoStampa TipoStampa { get; set; } = TipoStampa.Stampante;
        public void Print(List<Pizza> pizze)
        {
            if (TipoStampa == TipoStampa.Stampante)
                Console.WriteLine($"invio dati alla stampante...");
            else if (TipoStampa==TipoStampa.Pdf)
                Console.WriteLine($"invio dati a file PDF...");
        }
    }

    public enum TipoStampa
    {
        Stampante,
        Pdf
    }
}