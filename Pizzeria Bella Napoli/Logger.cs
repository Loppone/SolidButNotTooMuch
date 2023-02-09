using System;

namespace PizzeriaBellaNapoli
{
    public class Logger : ILogger
    {
        public virtual void Log(string messaggio)
        {
            Console.WriteLine($"Salvataggio ricevuta in archivio: {messaggio}");
        }
    }
}