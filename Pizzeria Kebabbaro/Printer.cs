using System;
using System.Collections.Generic;

namespace PizzeriaKebabbaro.Printer
{
    public class Printer
    {
        public TipologiaStampa TipoStampa { get; set; } = TipologiaStampa.Stampante;
        public void Print(List<Pizza> pizze)
        {
            if (TipoStampa == TipologiaStampa.Stampante)
                Console.WriteLine($"invio dati alla stampante...");
            else if (TipoStampa==TipologiaStampa.Pdf)
                Console.WriteLine($"invio dati a file PDF...");
        }
    }

    public enum TipologiaStampa
    {
        Stampante,
        Pdf
    }
}