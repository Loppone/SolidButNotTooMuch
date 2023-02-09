using System.Collections.Generic;

namespace PizzeriaKebabbaro
{
    public class Pizza
    {
        public string Nome { get; set; }
        public List<string> Ingredienti { get; set; } = new List<string>();


        public decimal CalcolaPrezzo()
        {
            if (Nome.ToLowerInvariant() == "marinara")
                return 4.00M;
            else if (Nome.ToLowerInvariant() == "margherita")
                return 5.00M;
            else
                return 4.50M + (0.50M * Ingredienti.Count);
        }
    }
}
