using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        
        public Dough(string flourType,string bakingTechnique,double grams)
        {
            FlourType=flourType;
            BakingTechnique=bakingTechnique;
            Grams=grams;
        }
        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (ValidateFlourType(value))
                {
                    flourType=value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }

        }

        private bool ValidateFlourType(string type)
        {
            type=type.ToLower();
            if (type=="white"||type=="wholegrain")
            {
                return true;
            }
            return false;
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (ValidateDoughTechnique(value))
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        private bool ValidateDoughTechnique(string technique)
        {
            technique = technique.ToLower();
            if (technique == "chewy" || technique == "homemade"||technique=="crispy")
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
                if (value>=1&&value<=200)
                {
                    grams=value;
                }
                else
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double CountCalories()
        {
            double sum = 2 * Grams;
            switch (flourType.ToLower())
            {
                case "white":
                    sum *= 1.5;
                    break;
                case "wholeGrain":
                    sum *= 1.0;
                    break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    sum *= 0.9;
                    break;
                case "chewy":
                    sum *= 1.1;
                    break;
                case "homemade":
                    sum *= 1.0;
                    break;
            }

            return sum;
        }
    }
}