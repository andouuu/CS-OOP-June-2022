using System;

namespace WildFarm.Animal
{
    public class Mouse:Mammal
    {
        public Mouse(string name,double weight,string livingRegion)
        {
            Name=name;
            Weight=weight;
            FoodEaten=0;
            LivingRegion=livingRegion;
        }
        public override string AskForFood()
        {
            return $"Squeak";
        }
        public override void Feed(string type, int quantity)
        {
            if (type != "Fruit"&&type!="Vegetable")
            {
                throw new ArgumentException($"Mouse does not eat {type}!");
            }
            else
            {
                Weight += 0.10 * quantity;
                FoodEaten += quantity;
            }

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}