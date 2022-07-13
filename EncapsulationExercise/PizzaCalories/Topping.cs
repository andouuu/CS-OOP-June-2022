using System;

namespace PizzaCalories
{
    public class Topping
    {
        private double grams;
        private string type;

        public Topping(string type,double grams)
        {
            Type=type;
            Grams=grams;
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (ValidateTopping(value))
                {
                    type=value;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private bool ValidateTopping(string type)
        {
            type=type.ToLower();
            if (type == "meat" || type == "veggies" || type == "cheese"||type=="sauce")
            {
                return true;
            }
            return false;
        }
        public double Grams
        {
            get
            {
                return grams;
            }
            set
            {
                if (value>=1&&value<=50)
                {
                    grams=value;
                }
                else
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
            }
        }

        public double CountCalories()
        {
            double sum = 2 * Grams;
            switch (Type.ToLower())
            {
                case "meat":
                    sum *= 1.2;
                    break;
                case "veggies":
                    sum *= 0.8;
                    break;
                case "cheese":
                    sum *= 1.1;
                    break;
                case "sauce":
                    sum *= 0.9;
                    break;
            }

            return sum;
        }
    }
}