using System.Runtime.CompilerServices;

namespace Vehicles
{
    public class Car:Vehicle
    {
        private const double AirConditionerModifier = 0.9;

        public Car(double fuelQuantity, double litersPerKM, int tankCapacity)
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + AirConditionerModifier;
    }
}