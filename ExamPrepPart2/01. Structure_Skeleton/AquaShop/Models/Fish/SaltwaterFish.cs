namespace AquaShop.Models.Fish
{
    public class SaltwaterFish:Fish
    {
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = 5;
        }
        //Can only live in saltwater aquarium
        public override void Eat()
        {
            Size += 2;
        }
    }
}