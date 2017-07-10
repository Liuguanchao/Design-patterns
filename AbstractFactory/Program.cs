/*********************************************/
//抽象工厂模式 
/*********************************************/

using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WhiteAnimal Call What?");

            Animalcalls animalcall = new WhiteAnimalcalls();
            Dog dog = animalcall.Dogcall();
            dog.call();
            Cat cat = animalcall.Catcall();
            cat.call();

            Console.WriteLine("YellowAnimal Call What?");

            Animalcalls animalcall2 = new YellowAnimalcalls();
            Dog dog2 = animalcall2.Dogcall();
            dog2.call();

            Cat cat2 = animalcall2.Catcall();
            cat2.call();
            Console.ReadKey();

        }

        //抽象产品
        abstract class Dog
        {
            private String name;

            public abstract void call();

            public String getName()
            {
                return name;
            }
            public void setName(String name)
            {
                this.name = name;
            }
        }
        abstract class Cat
        {
            private String name;

            public abstract void call();

            public String getName()
            {
                return name;
            }
            public void setName(String name)
            {
                this.name = name;
            }
        }

        //具体产品
        class WhiteDog : Dog
        {
            public override void call()
            {
                Console.WriteLine(this.getName() + "----WhiteDog call wo wo ---------");
            }
        }
        class YellowDog : Dog
        {
            public override void call()
            {
                Console.WriteLine(this.getName() + "----YellowDog call wo wo --------");
            }
        }
        class WhiteCat : Cat
        {
            public override void call()
            {
                Console.WriteLine(this.getName() + "----WhiteCat call miao ----------");
            }
        }
        class YellowCat : Cat
        {
            public override void call()
            {
                Console.WriteLine(this.getName() + "----YellowCat call miao ---------");
            }
        }
        //抽象工厂  
        abstract class Animalcalls
        {
            public abstract Dog Dogcall();

            public abstract Cat Catcall();
        }

        //具体工厂  
        class WhiteAnimalcalls : Animalcalls
        {
            public override Dog Dogcall()
            {
                return new WhiteDog();
            }
            public override Cat Catcall()
            {
                return new WhiteCat();
            }
        }
        class YellowAnimalcalls : Animalcalls
        {
            public override Dog Dogcall()
            {
                return new YellowDog();
            }
            public override Cat Catcall()
            {
                return new YellowCat();
            }

        }
    }
}