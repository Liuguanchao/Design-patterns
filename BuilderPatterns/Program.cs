using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //解决中文问题
            Console.OutputEncoding = Encoding.UTF8;
            //食客
            Diners diners = new Diners();
            //中餐厨师
            Chef chinesechef = new ChineseChef();
            //西餐厨师
            Chef westernchef = new WesternChef();
            
            //食客要中餐厨师做饭
            diners.Eat(chinesechef);
            //食物是中餐
            Food food1 = chinesechef.GetFood();
            food1.Show();

            //食客要西餐厨师做饭
            diners.Eat(westernchef);
            //食物是西餐
            Food food2 = westernchef.GetFood();
            food2.Show(); 
            Console.ReadLine();
        }
        //产品角色 食物
        public class Food
        {
            public string FoodName = string.Empty;
            public string ChefType = string.Empty;
            public void Show()
            {
                Console.WriteLine("{0}做的食物是:{1}", ChefType, FoodName);
            }
        }

        //抽象建造者角色 厨师
        public abstract class Chef
        {
            public abstract void GetFoodName();
            public abstract void GetChefType();
            public abstract Food GetFood();
        }
        //具体建造角色 中餐厨师
        public class ChineseChef : Chef
        {
            Food food = new Food();
            public override void GetFoodName()
            {
                food.FoodName = "ChineseFood";
            }
            public override void GetChefType()
            {
                food.ChefType = "ChineseChef";
            }

            public override Food GetFood()
            {
                return food;
            }
        }
        //西餐厨师
        public class WesternChef : Chef
        {
            Food food = new Food();
            public override void GetFoodName()
            {
                food.FoodName = "WesternFood";
            }
            public override void GetChefType()
            {
                food.ChefType = "WesternChef";
            } 
            public override Food GetFood()
            {
                return food;
            }
        }
        //食客
        public class Diners
        {
            //食客吃什么需要不同的厨师去做
            public void Eat(Chef chef)
            {
                chef.GetChefType();
                chef.GetFoodName();
            }
        }

    }

}