using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;

        public Product(string name,int cost)
        {
            Name=name;
            Cost=cost;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    name = value;
                }

            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                {
                    cost = value;
                }

            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}