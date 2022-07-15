using System;

namespace Vehicles
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int c = 0; c < n; c++)
            {
                string[] command = Console.ReadLine().Split();
                double parsed = double.Parse(command[2]);

                try
                {
                    DriveOrRefuelVehicles(car, truck, bus, command, parsed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void DriveOrRefuelVehicles(Car car, Truck truck, Bus bus, string[] command, double parsed)
        {
            if (command[0] == "Drive")
            {
                if (command[1] == "Car")
                {
                    car.Drive(parsed);
                }
                else if (command[1] == "Truck")
                {
                    truck.Drive(parsed);
                }
                else if (command[1] == "Bus")
                {
                    bus.Drive(parsed);
                }
            }
            else if (command[0] == "Refuel")
            {
                if (command[1] == "Car")
                {
                    car.Refuel(parsed);
                }
                else if (command[1] == "Truck")
                {
                    truck.Refuel(parsed);
                }
                else if (command[1] == "Bus")
                {
                    bus.Refuel(parsed);
                }
            }
            else if (command[0] == "DriveEmpty")
            {
                if (command[1] == "Bus")
                {
                    bus.HasPeople = false;
                    bus.Drive(parsed);
                }
            }
        }
    }
}