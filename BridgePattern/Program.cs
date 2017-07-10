/*********************************************/
//桥接模式 
/*********************************************/
using System;
using System.Text;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文问题
            Console.OutputEncoding = Encoding.UTF8;
            //小汽车在高速公路上行驶;
            AbstractRoad Road1 = new SpeedWay();
            Road1.Car = new Car();
            Road1.Run();
            Console.WriteLine("=========================");

            //公共汽车在高速公路上行驶;
            AbstractRoad Road2 = new Street();
            Road2.Car = new Bus();
            Road2.Run();
            Console.Read();
        }


        //抽象路
        public abstract class AbstractRoad
        {
            protected AbstractCar car;
            public AbstractCar Car
            {
                set
                {
                    car = value;
                }
            }

            public abstract void Run();
        }

        //高速公路
        public class SpeedWay : AbstractRoad
        {
            public override void Run()
            {
                car.Run();
                Console.WriteLine("高速公路上行驶");
            }
        }

        //市区街道
        public class Street : AbstractRoad
        {
            public override void Run()
            {
                car.Run();
                Console.WriteLine("市区街道上行驶");
            }
        }


        //抽象汽车 
        public abstract class AbstractCar
        {
            public abstract void Run();
        }

        //小汽车;
        public class Car : AbstractCar
        {
            public override void Run()
            {
                Console.Write("小汽车在");
            }
        }

        //公共汽车
        public class Bus : AbstractCar
        {
            public override void Run()
            {
                Console.Write("公共汽车在");
            }
        }
    }
}
