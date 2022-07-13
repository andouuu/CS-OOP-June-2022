using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {
                string[] pizzaData = Console.ReadLine().Split(" ");
                string[] doughData = Console.ReadLine().Split(" ");
                Dough dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));
                Pizza pizza = new Pizza(pizzaData[1], dough);
                try
                {
                    string toppingData;
                    while ((toppingData = Console.ReadLine()) != "END")
                    {
                        string[] dataTopping = toppingData.Split(" ");
                        Topping topping = new Topping(dataTopping[1], double.Parse(dataTopping[2]));
                        pizza.Add(topping);

                    }

                    Console.WriteLine($"{pizza.Name} - {pizza.CountCalories():f2} Calories.");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
