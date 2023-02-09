using System;

namespace PizzeriaKebabbaro
{
    public class Logger
    {
        public void Log(string messaggio)
        {
            Console.WriteLine($"Salvataggio ricevuta in archivio: {messaggio}");
        }
    }
}