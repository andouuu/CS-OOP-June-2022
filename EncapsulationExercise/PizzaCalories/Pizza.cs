using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name,Dough dough)
        {
            Name=name;
            Dough=dough;
            toppings=new List<Topping>();
        }
        public string Name
        {
            get
            {
                return name;
            } 
            set 
            {
                if (!string.IsNullOrWhiteSpace(value)&&value.Length<=15)
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public void Add(Topping topping)
        {
            if (this.Toppings.Count + 1 > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.Toppings.Add(topping);
            }
        }
        public double CountCalories()
        {
            double sum = Dough.CountCalories();
            foreach (var topping in Toppings)
            {
                sum+=topping.CountCalories();
            }
            return sum;
        }

        public override string ToString()
        {
            return $"{Name} - {this.CountCalories():f2} Calories.";
        }
    }
}