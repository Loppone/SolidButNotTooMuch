using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidButNotTooMuch_Z1
{
    public class BusinessClass_Accoppiato
    {
        private readonly string _p1;
        private readonly string _p2;

        public BusinessClass_Accoppiato(string p1, string p2)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public void Do()
        {
            Console.WriteLine(_p1);
            Console.WriteLine(_p2);
        }
    }

    public interface IModel
    {
        string P1 { get; set; }
        string P2 { get; set; }
        string P3 { get; set; }
    }

    public class Model : IModel
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
    }

    public interface IBusiness
    {
        void Do();
    }


    public class BusinessClass : IBusiness
    {
        private readonly IModel _model;

        public BusinessClass(IModel model)
        {
            _model = model;
        }

        public void Do()
        {
            Console.WriteLine(_model.P1);
            Console.WriteLine(_model.P2);
            Console.WriteLine(_model.P3);
        }
    }

    public interface ISuperModel : IModel
    {
        string P4 { get; set; }
        string P5 { get; set; }

    }

    public class SuperModel : ISuperModel
    {
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
    }

    public class SuperBusinessClass : IBusiness
    {
        private readonly ISuperModel _model;

        public SuperBusinessClass(ISuperModel model)
        {
            _model = model;
        }

        public void Do()
        {
            Console.WriteLine(_model.P1);
            Console.WriteLine(_model.P2);
            Console.WriteLine(_model.P3);
            Console.WriteLine(_model.P4);
            Console.WriteLine(_model.P5);
        }
    }


    public class HighLevelModule
    {
        private readonly IBusiness _business;

        public HighLevelModule(IBusiness business)
        {
            _business = business;
        }

        public void CallBusinessMethod()
        {
            _business.Do();
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var bc = new BusinessClass_Accoppiato("par1", "par2");
            bc.Do();

            Console.WriteLine();


            var hlm = new HighLevelModule(new BusinessClass(new Model() { P1 = "P1", P2 = "P2", P3 = "P3" }));
            hlm.CallBusinessMethod();

            Console.WriteLine();

            var superHlm = new HighLevelModule(new SuperBusinessClass(new SuperModel() { P1 = "P1", P2 = "P2", P3 = "P3", P4 = "P4", P5 = "P5" }));
            superHlm.CallBusinessMethod();

            Console.ReadKey();
        }
    }
}
