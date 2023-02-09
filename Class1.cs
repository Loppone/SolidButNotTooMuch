using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidButNotTooMuch
{
    public interface IParent
    {
        string Property1 { get; set; }
        string Property2 { get; set; }

        void HandleProperties();
    }

    public abstract class Parent : IParent
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }

        public virtual void HandleProperties() { }
    }

    public class Child1 : Parent
    {
        public string Property3 { get; set; }

        public override void HandleProperties()
        {
            Console.WriteLine(Property1);
            Console.WriteLine(Property2);
            Console.WriteLine(Property3);
        }
    }

    public class Child2 : Parent
    {
        public string Property4 { get; set; }

        public override void HandleProperties()
        {
            Console.WriteLine(Property1);
            Console.WriteLine(Property2);
            Console.WriteLine(Property4);
        }
    }

    public class ClassThatUsesParent
    {
        private IParent _parent;

        public ClassThatUsesParent(IParent parent)
        {
            _parent = parent;
        }

        public void HandleProperties()
        {
            _parent.HandleProperties();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var child1 = new Child1() { Property1 = "a", Property2 = "b", Property3 = "c" };
            var parent = new ClassThatUsesParent(child1);

            // Chiamata alla classe Child1
            parent.HandleProperties();

            // Chiamata alla classe Child2
            var child2 = new Child2() { Property1 = "a", Property2 = "b", Property4 = "d" };
            parent.HandleProperties();
        }
    }
}