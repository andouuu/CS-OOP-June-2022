using System;

namespace WildFarm.Animal
{
    public class Dog:Mammal
    {
        public Dog(string name, double weight,  string livingRegion)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            LivingRegion = livingRegion;
        }
        public override string AskForFood()
        {
            return $"Woof!";
        }
        public override void Feed(string type, int quantity)
        {
            if (type != "Meat")
            {
                throw new ArgumentException($"Dog does not eat {type}!");
            }
            else
            {
                Weight += 0.40 * quantity;
                FoodEaten += quantity;
            }

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}