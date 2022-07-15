using System;

namespace Vehicles
{
    public class Truck:Vehicle
    {
        private const double AirConditionerModifier = 1.6;
        private const double RefuelSuccesfulCoefficient = 0.95;

        public Truck(double fuelQuantity, double litersPerKM, int tankCapacity)
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + AirConditionerModifier;

        public override void Refuel(double liters)
        {
            //base.Refuel(liters * RefuelSuccesfulCoefficient);
            base.Refuel(liters);
        }
    }
}