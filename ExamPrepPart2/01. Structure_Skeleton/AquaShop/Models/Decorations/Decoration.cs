namespace AquaShop.Models.Decorations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;

    public class Decoration:IDecoration
    {
        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort { get; }
        public decimal Price { get; }
    }
}
