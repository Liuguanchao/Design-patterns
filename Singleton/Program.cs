/*********************************************/
//单件模式 
//单件模式是一种用于确保整个应用程序中只有一个类实例且这个实例所占资源在整个应用程序中是共享时的程序设计方法
/*********************************************/

using System;
using System.Collections.Generic;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Singleton sl = Singleton.getInstance();

        }
    }

    public class Singleton
    {
        //和上面有什么不同？ 
        private static Singleton instance = null;

        static readonly object o = new object();
        //设置为私有的构造函数 
        private Singleton() { }
        //静态工厂方法 
        public static Singleton getInstance()
        {
            lock (o)//实现线程安全的单件
            {
                if (instance == null)
                    instance = new Singleton();
            }
            return instance;
        }
    }

}