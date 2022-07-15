using System;
using System.Threading;

namespace Vehicles
{
    public abstract class Vehicle:IDriveable,IRefuelable
    {
        protected Vehicle(double fuelQuantity, double litersPerKM, int tankCapacity)
        {
            //this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKM;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;

            // ?
            //if (this.FuelQuantity > this.TankCapacity)
            //{
            //    this.FuelQuantity = 0;
            //}
        }


        public int TankCapacity { get; set; }

        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; }

        public void Drive(double distance)
        {
            var litersNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < litersNeeded)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= litersNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}