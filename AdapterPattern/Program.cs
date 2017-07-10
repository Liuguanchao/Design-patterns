/*********************************************/
//适配器模式 
/*********************************************/
using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文问题
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("类的适配器模式");
            ITarget t = new Adapter();
            t.Request();
            Console.WriteLine("......................");
            Console.WriteLine("对象的适配器模式");
            ITarget t2 = new Adapter2();
            t2.Request();
            Console.WriteLine("......................");

        }
        //目标角色:内有客户期待的方法
        interface ITarget
        {
            // Methods  
            void Request();
        }

        // 源角色：需要适配的类 
        class Adaptee
        {
            // Methods  
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest()");
            }
        }

        /// <summary>
        /// 适配器角色:把源接口转换成目标接口。
        /// 类的适配器模式
        /// </summary>
        class Adapter : Adaptee, ITarget
        {
            // Implements ITarget interface  
            public void Request()
            {
                // Possibly do some data manipulation  
                // and then call SpecificRequest  
                this.SpecificRequest();
            }
        }

        /// <summary>
        /// 适配器角色:把源接口转换成目标接口。
        /// 对象的适配器模式
        /// </summary>
        class Adapter2 : ITarget
        {
            // Fields  
            private Adaptee adaptee = new Adaptee();

            // Methods  
            public void Request()
            {
                //可能做一些数据处理，然后调用特定要求
                adaptee.SpecificRequest();
            }
        }
    }
}