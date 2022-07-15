namespace Vehicles
{
    public class Bus:Vehicle
    {
        private const double AirConditionerModifier = 1.4;

        public Bus(double fuelQuantity, double litersPerKM, int tankCapacity)
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.HasPeople = true;
        }

        public bool HasPeople { get; set; }

        public override double FuelConsumption
            => base.FuelConsumption + (this.HasPeople ? AirConditionerModifier : 0);
    }
}