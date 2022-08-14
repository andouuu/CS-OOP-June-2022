using System;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit:IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            Cost=cost;
            enduranceLevel = 1;
        }
        public double Cost
        {
            get=>this.cost;
            private set=>this.cost = value;
        }

        public int EnduranceLevel
        {
            get=>this.enduranceLevel;
            private set
            {
                if (value>20)
                {
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduranceLevel = value;
            }
        }
        public void IncreaseEndurance()
        {
            EnduranceLevel++;
        }
    }
}