using System;
using System.Collections.Generic;

namespace PizzeriaBellaNapoli
{
    public partial class Stampante : IPrint
    {
        public void Print(List<IPizza> pizze)
        {
            Console.WriteLine($"invio dati alla stampante...");
        }
    }
}
