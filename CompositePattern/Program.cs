/*********************************************/
//组合模式 
/*********************************************/
using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);
            Console.ReadLine();
        }
        //抽象类
        public abstract class Component
        {
            protected string _name;

            public Component(string name)
            {
                this._name = name;
            }

            public abstract void Add(Component c);

            public abstract void Remove(Component c);

            public abstract void Display(int depth);
        }
        public class Leaf : Component
        {
            public Leaf(string name)
                : base(name)
            {
            }

            public override void Add(Component c)
            {
                Console.WriteLine("Cannot add to a leaf");
            }

            public override void Remove(Component c)
            {
                Console.WriteLine("Cannot remove from a leaf");
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + _name);
            }
        }
        public class Composite : Component
        {
            private List<Component> _children = new List<Component>();

            public Composite(string name)
                : base(name)
            {
            }

            public override void Add(Component component)
            {
                _children.Add(component);
            }

            public override void Remove(Component component)
            {
                _children.Remove(component);
            }
            //显示方法
            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + _name);

                foreach (Component component in _children)
                {
                    component.Display(depth + 2);
                }
            }
        }
    }
}