namespace BorderControl
{
    public interface IBuyer
    {
        public int Food { get; }

        public string Name { get; }
        void BuyFood();
    }
}