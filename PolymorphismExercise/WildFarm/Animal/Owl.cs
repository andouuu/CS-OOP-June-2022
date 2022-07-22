using System;
using System.Threading;

namespace WildFarm.Animal
{
    public class Owl:Bird
    {
        public Owl(string name,double weight,double wingSize)
        {
            Name=name;
            Weight=weight;
            FoodEaten=0;
            WingSize=wingSize;
        }

        public override string AskForFood()
        {
            return $"Hoot Hoot";
        }

        public override void Feed(string type, int quantity)
        {
            if (type!="Meat")
            {
                throw new ArgumentException($"Owl does not eat {type}!");
            }
            else
            {
                Weight += 0.25 * quantity;
                FoodEaten += quantity;
            }
            
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}