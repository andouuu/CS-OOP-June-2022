using System;

namespace WildFarm.Animal
{
    public class Tiger:Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            LivingRegion = livingRegion;
            Breed = breed;
        }
        public override string AskForFood()
        {
            return $"ROAR!!!";
        }
        public override void Feed(string type, int quantity)
        {
            if (type != "Meat")
            {
                throw new ArgumentException($"Tiger does not eat {type}!");
            }
            else
            {
                Weight += 1.00 * quantity;
                FoodEaten+=quantity;
            }

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}