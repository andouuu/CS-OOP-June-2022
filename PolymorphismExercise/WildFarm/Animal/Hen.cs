using System;

namespace WildFarm.Animal
{
    public class Hen:Bird
    {
        public Hen(string name, double weight,  double wingSize)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            WingSize = wingSize;
        }
        public override string AskForFood()
        {
            return $"Cluck";
        }
        public override void Feed(string type, int quantity)
        {
            Weight += 0.35 * quantity;
            FoodEaten += quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}