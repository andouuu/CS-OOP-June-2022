using System;
using System.Collections.Generic;
using System.Threading.Channels;
using WildFarm.Animal;

namespace WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal.Animal> animals = new List<Animal.Animal>();
            while (true)
            {
                string[] cmd = Console.ReadLine().Split();
                
                Animal.Animal animal = null;
                if (cmd[0]=="End")
                {
                    break;
                }
                string[] food = Console.ReadLine().Split();
                try
                {
                    if (cmd[0] == "Owl")
                    {
                        animal= new Owl(cmd[1], double.Parse(cmd[2]), double.Parse(cmd[3]));
                        Console.WriteLine(animal.AskForFood());
                        
                        animal.Feed(food[0], int.Parse(food[1]));
                        
                    }
                    else if (cmd[0] == "Hen")
                    {
                        animal = new Hen(cmd[1], double.Parse(cmd[2]), double.Parse(cmd[3]));
                        Console.WriteLine(animal.AskForFood());

                        animal.Feed(food[0], int.Parse(food[1]));
                    }
                    else if (cmd[0] == "Dog")
                    {
                         animal = new Dog(cmd[1], double.Parse(cmd[2]), cmd[3]);
                        Console.WriteLine(animal.AskForFood());
                        
                        animal.Feed(food[0], int.Parse(food[1]));
                        
                    }
                    else if (cmd[0] == "Mouse")
                    {
                        animal = new Mouse(cmd[1], double.Parse(cmd[2]), cmd[3]);
                        Console.WriteLine(animal.AskForFood());
                        
                        animal.Feed(food[0], int.Parse(food[1]));
                        
                    }
                    else if (cmd[0] == "Cat")
                    {
                        animal = new Cat(cmd[1], double.Parse(cmd[2]), cmd[3], cmd[4]);
                        Console.WriteLine(animal.AskForFood());
                        
                        animal.Feed(food[0], int.Parse(food[1]));
                        
                    }
                    else if (cmd[0] == "Tiger")
                    {
                         animal = new Tiger(cmd[1], double.Parse(cmd[2]), cmd[3], cmd[4]);
                        Console.WriteLine(animal.AskForFood());
                        
                        animal.Feed(food[0], int.Parse(food[1]));
                        
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                animals.Add(animal);
            }

            animals.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
