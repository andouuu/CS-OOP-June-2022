using System;

namespace WildFarm.Animal
{
    public class Cat:Feline
    {
        public Cat(string name, double weight,string livingRegion,string breed)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            LivingRegion = livingRegion;
            Breed = breed;
        }
        public override string AskForFood()
        {
            return $"Meow";
        }
        public override void Feed(string type, int quantity)
        {
            if (type != "Meat"&&type!="Vegetable")
            {
                throw new ArgumentException($"Cat does not eat {type}!");
            }
            else
            {
                Weight += 0.30 * quantity;
                FoodEaten += quantity;
            }

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}