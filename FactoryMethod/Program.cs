/*********************************************/
//工厂方法模式 
/*********************************************/

using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //应该和具体产品形成对应关系... 
            try
            {
                Console.WriteLine("Dog call What?");
                Animalcalls animalcall = new Dogcalls();
                Animal dog = animalcall.Animalcalls();
                dog.call();
                Console.WriteLine("Cat call What?");
                Animalcalls animalcall2 = new Catcalls();
                Animal cat = animalcall2.Animalcalls();
                cat.call();
                Console.ReadKey();
                //可以看出工厂方法的加入，使得对象的数量成倍增长。
            }
            catch (Exception ex)
            {
            }
        }
    }
    //抽象产品角色 
    public interface Animal
    {
        void call();
    }

    //具体产品角色 
    public class Dog : Animal
    {
        public void call()
        {
            Console.WriteLine("Dogs call wangwang");
        }
    }
    public class Cat : Animal
    {
        public void call()
        {
            Console.WriteLine("Cat call mao~");
        }
    }
    //抽象工厂角色 
    public interface Animalcalls
    {
        Animal Animalcalls();
    }
    //具体工厂角色
    public class Dogcalls : Animalcalls
    {
        public Animal Animalcalls()
        {
            return new Dog();
        }
    }
    public class Catcalls : Animalcalls
    {
        public Animal Animalcalls()
        {
            return new Cat();
        }
    }
}