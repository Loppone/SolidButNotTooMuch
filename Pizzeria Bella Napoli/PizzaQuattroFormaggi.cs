using System.Collections.Generic;

namespace PizzeriaBellaNapoli
{
    public class PizzaQuattroFormaggi : IPizza
    {
        public string Nome { get; set; }
        public List<string> Ingredienti { get; set; } = new List<string>();


        public decimal CalcolaPrezzo()
        {
            return 4.50M + (0.50M * Ingredienti.Count);
        }
    }
}
