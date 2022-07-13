using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bag;

        public Person(string name,int money)
        {
            Name=name;
            Money=money;
            bag=new List<Product>();
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

        public int Money
        {
            get { return money; }
            set
            {
                if (value<0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                { 
                    money = value;
                }
               
            }
        }

        public void Buy(Product product)
        {
            if (this.Money-product.Cost<0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                this.Money -= product.Cost;
                bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }
        public List<Product> Bag
        {
            get { return bag; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" - ");
            if (this.bag.Count==0)
            {
                sb.Append("Nothing bought");
            }
            else
            {
                sb.Append(string.Join(", ", bag));
            }
            return sb.ToString();
        }
    }
}