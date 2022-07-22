namespace WildFarm.Animal
{
    public abstract class Animal
    {
        
        public string Name;
        public double Weight;
        public int FoodEaten;
        public abstract void Feed(string type,int quantity);
        public abstract string AskForFood();
    }
}