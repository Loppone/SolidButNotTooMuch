namespace PizzeriaBellaNapoli
{
    public class PizzaMargherita : IPizza
    {
        public string Nome { get; set; }

        public decimal CalcolaPrezzo()
        {
            return 5.00M;
        }
    }
}
