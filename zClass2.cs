using System;

namespace SolidButNotTooMuch_Z2
{

    public abstract class BusinessBase
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }

        public abstract void Do();
    }

    public class BusinessClass : BusinessBase
    {
        public override void Do()
        {
            Console.WriteLine("Sono BusinessClass, figlia di Business");
            Console.WriteLine(P1);
            Console.WriteLine(P2);
            Console.WriteLine(P3);
        }
    }

    public class SuperBusinessClass : BusinessBase
    {
        public string P4 { get; set; }
        public string P5 { get; set; }

        public override void Do()
        {
            Console.WriteLine("Sono SuperBusinessClass, figlia di Business");
            Console.WriteLine(P1);
            Console.WriteLine(P2);
            Console.WriteLine(P3);
            Console.WriteLine(P4);
            Console.WriteLine(P5);
        }
    }

    public class FaiCoseNuove
    {
        private readonly BusinessBase _business;

        public FaiCoseNuove(BusinessBase business)
        {
            _business = business;
        }

        public void Falle()
        {
            Console.WriteLine("Posso gestire 1 o n proprietà");
            if (_business is SuperBusinessClass sbc)
            {
                sbc.P4 = "x";
                sbc.P5 = "y";
                Console.WriteLine(sbc.P4);
                Console.WriteLine(sbc.P5);
            }
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            BusinessBase bb = new BusinessClass() { P1 = "P1", P2 = "P2", P3 = "P3" };
            bb.Do();

            Console.WriteLine();
            
            BusinessBase bb2 = new SuperBusinessClass() { P1 = "P1", P2 = "P2", P3 = "P3", P4 = "P4", P5 = "P5" };
            bb2.Do();

            Console.WriteLine();

            var fcn = new FaiCoseNuove(bb2);
            fcn.Falle();
            Console.ReadKey();
        }
    }
}
