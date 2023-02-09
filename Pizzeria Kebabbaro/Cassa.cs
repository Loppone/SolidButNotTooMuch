using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaKebabbaro
{
    public class Cassa
    {
        public List<Pizza> Pizze { get; set; } = new List<Pizza>();
        public TipologiaStampa TipoStampa { get; set; }

        public decimal Vendi()
        {
            var prezzoTotale = CalcolaPrezzoTotale();
            StampaScontrino();
            RegistraVendita(prezzoTotale);

            return prezzoTotale;
        }

        private void RegistraVendita(decimal incasso)
        {
            Console.WriteLine($"Salvataggio ricevuta in archivio: Vendita pizze per {incasso} Euro.");
        }

        private void StampaScontrino()
        {
            if (TipoStampa == TipologiaStampa.Stampante)
                Console.WriteLine($"invio dati alla stampante...");
            else if (TipoStampa == TipologiaStampa.Pdf)
                Console.WriteLine($"invio dati a file PDF...");
        }

        private decimal CalcolaPrezzoTotale()
        {
            return Pizze.Sum(x => x.CalcolaPrezzo());
        }
    }

    public enum TipologiaStampa
    {
        Stampante,
        Pdf
    }
}
