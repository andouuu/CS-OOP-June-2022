namespace AquaShop.Models.Fish
{
    public class FreshwaterFish:Fish
    {
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = 3;
        }
        //Can only live in freshwater aquarium
        public override void Eat()
        {
            Size += 3;
        }
    }
}