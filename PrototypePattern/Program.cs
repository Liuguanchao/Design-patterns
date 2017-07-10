/*********************************************/
//原型模式 
/*********************************************/
using System;
using System.Text;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文问题
            Console.OutputEncoding = Encoding.UTF8;

            #region 浅克隆   
            Console.WriteLine("浅克隆开始......");
            //第一份简历
            Resume r1 = new Resume("小明");
            r1.PersonalInfo("男", "22");
            r1.PersonalExprience("2008-2010", "XX公司");
            //第二份简历，重新设置工作经历
            Resume r2 = (Resume)r1.Clone(false);
            r2.PersonalExprience("2010-2012", "YY公司");
            //第三份简历，也重新设置工作简历
            Resume r3 = (Resume)r1.Clone(false);
            r3.PersonalExprience("2012-2014", "ZZ公司");
            //三份简历依次进行打印
            r1.Display();
            r2.Display();
            r3.Display();

            Console.WriteLine("浅克隆结束......");

            #endregion

            #region 深克隆
            Console.WriteLine("深克隆开始......");
            //第一份简历
            Resume deepr1 = new Resume("小明");
            deepr1.PersonalInfo("男", "22");
            deepr1.PersonalExprience("2008-2010", "XX公司");
            //第二份简历，重新设置工作经历
            Resume deepr2 = (Resume)deepr1.Clone(true);
            deepr2.PersonalExprience("2010-2012", "YY公司");
            //第三份简历，也重新设置工作简历
            Resume deepr3 = (Resume)deepr1.Clone(true);
            deepr3.PersonalExprience("2012-2014", "ZZ公司");
            //三份简历依次进行打印
            deepr1.Display();
            deepr2.Display();
            deepr3.Display();
            Console.WriteLine("深克隆结束......");
            #endregion

            Console.ReadKey();

        }

        //工作经历
        class WorkExprience
        {
            private string workData;//设置工作经历的时间
            public string WorkData
            {
                set { workData = value; }
                get { return workData; }
            }
            private string company;//设置工作经历的公司
            public string Company
            {
                set { company = value; }
                get { return company; }
            }
            public object Clone()//“工作经历”类实现克隆方法
            {
                return (object)this.MemberwiseClone();
            }

        }

        //简历
        class Resume
        {
            private string name;//设置姓名
            private string sex;//设置性别
            private string age;//设置年龄
            private WorkExprience work;
            public Resume(string name)
            {
                this.name = name;
                work = new WorkExprience();
            }
            public Resume(WorkExprience work)
            {
                this.work = (WorkExprience)work.Clone();//提供Clone方法调用的私有构造函数，一边克隆“工作经历”的数据
            }
            //设置个人信息
            public void PersonalInfo(string sex, string age)
            {
                this.sex = sex;
                this.age = age;

            }
            //设置工作经历
            public void PersonalExprience(string workData, string company)
            {
                work.WorkData = workData;
                work.Company = company;
            }

            //显示简历
            public void Display()
            {
                Console.WriteLine("个人信息：{0},{1},{2}", name, age, sex);
                Console.WriteLine("工作经历：{0},{1}", work.WorkData, work.Company);
            }

            //定义自己的克隆方法
            public object Clone(bool deep)
            {
                if (deep)
                {

                    Resume obj = new Resume(this.work);//调用私有的构造方法，让“工作经历”克隆完成，然后再给这个简历对象的相关字段赋值，最终返回一个深复制的简历对象
                    obj.name = this.name;
                    obj.sex = this.sex;
                    obj.age = this.age;
                    return obj;

                }
                return (Resume)this.MemberwiseClone();
            }

        }
    }
}