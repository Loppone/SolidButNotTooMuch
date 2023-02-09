using System;

namespace PizzeriaBellaNapoli
{
    // USARE QUESTA CLASSE ROMPE LSP
    public class WeekendLogger : Logger
    {
        public override void Log(string messaggio)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                base.Log(messaggio);

            throw new Exception("Proibito loggare nel weekend!");
        }
    }

    // QUESTA RISOLVE IL PROBLEMA LSP: WEEKENDLOGGER E WEEKENDLOGGERREFACTORED NON SONO PIU' PARENTI
    public class WeekendLoggerRefactored : IWeekendLogger
    {
        public int WhatDayIsNow { get; set; }

        public void Log(string message)
        {

            if (WhatDayIsNow == (int)DayOfWeek.Saturday || WhatDayIsNow == (int)DayOfWeek.Sunday)
                Console.WriteLine($"Salvataggio ricevuta in archivio del fine settimana: {message}");
            else
                throw new Exception("Proibito loggare nel weekend!");
        }
    }

    public interface IWeekendLogger : ILogger
    {
        public int WhatDayIsNow { get; set; }
    }
}