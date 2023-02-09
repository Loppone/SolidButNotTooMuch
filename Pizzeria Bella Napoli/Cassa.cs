using System.Collections.Generic;
using System.Linq;

namespace PizzeriaBellaNapoli
{
    public class Cassa
    {
        public List<IPizza> Pizze { get; set; } = new List<IPizza>();
        
        private readonly IPrint _stampa;
        private readonly ILogger _logger;

        public Cassa(IPrint stampa, ILogger logger)
        {
            _stampa = stampa;
            _logger = logger;
        }

        public decimal Vendi()
        {
            var prezzoTotale = CalcolaPrezzoTotale();
            _stampa.Print(Pizze);
            _logger.Log($"Vendita pizze per {prezzoTotale} Euro.");

            return prezzoTotale;
        }

        private decimal CalcolaPrezzoTotale()
        {
            return Pizze.Sum(x => x.CalcolaPrezzo());
        }
    }
}
