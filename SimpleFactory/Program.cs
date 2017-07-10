/*********************************************/
//简单工厂模式 
/*********************************************/

using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("dog call what?");
                //叫的是狗狗            
                Animal animal = AnimalFactory.call("dog");
                animal.call();
                Console.WriteLine("cat call what?");
                //叫的是猫咪
                Animal animal2 = AnimalFactory.call("cat");
                animal2.call();
                Console.ReadKey();
            }
            catch (Exception ex)
            {

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

        //工厂类角色 
        public class AnimalFactory
        {
            //工厂方法.注意 返回类型为抽象产品角色  
            public static Animal call(String s)
            {
                //判断逻辑，返回具体的产品角色给 Client   
                if (s.Equals("dog"))
                    return new Dog();
                else if (s.Equals("cat"))
                    return new Cat();
                else throw new Exception();
            }
        }
    }
}