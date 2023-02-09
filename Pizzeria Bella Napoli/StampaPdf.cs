using System;
using System.Collections.Generic;

namespace PizzeriaBellaNapoli
{
    public class StampaPdf : IPrint
    {
        public void Print(List<IPizza> pizze)
        {
            Console.WriteLine($"invio dati a file PDF...");
        }
    }
}
