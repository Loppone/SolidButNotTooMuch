namespace PizzeriaBellaNapoli
{
    public class PizzaMarinara : IPizza
    {
        public string Nome { get; set; }

        public decimal CalcolaPrezzo()
        {
            return 4.00M;
        }
    }
}
