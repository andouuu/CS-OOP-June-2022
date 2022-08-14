using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller:IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets=new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name)!=null)
            {
                return $"Planet {name} is already added!";
            }
            planets.AddItem(new Planet(name,budget));
            return $"Successfully added Planet: {name}";
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
           
            string[] unitsAvailable = new string[]
            {
                "AnonymousImpactUnit",
                "SpaceForces",
                "StormTroopers"
            };
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (string.IsNullOrWhiteSpace(unitTypeName))
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidUnitName);
            }
            if (!unitsAvailable.Contains(unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planets.FindByName(planetName)
                    .Army.FirstOrDefault(x=>x.GetType().Name==unitTypeName)!=null)
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IMilitaryUnit currUnit=null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    currUnit = new AnonymousImpactUnit();
                    break;
                case "StormTroopers":
                    currUnit = new StormTroopers();
                    break;
                case "SpaceForces":
                    currUnit = new SpaceForces();
                    break;
            }
            planets.FindByName(planetName).Spend(currUnit.Cost);
            planets.FindByName(planetName).AddUnit(currUnit);
            
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            string[] weaponsAvailable = new string[]
            {
                "BioChemicalWeapon",
                "NuclearWeapon",
                "SpaceMissiles"
            };
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (string.IsNullOrWhiteSpace(weaponTypeName))
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidWeaponName);
            }
            if (!weaponsAvailable.Contains(weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            if (planets.FindByName(planetName)
                    .Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            IWeapon weapon = null;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
            }
            planets.FindByName(planetName).Spend(weapon.Price);
            planets.FindByName(planetName).AddWeapon(weapon);
            
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string SpecializeForces(string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (planets.FindByName(planetName).Army.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planets.FindByName(planetName).Spend(1.25);
            planets.FindByName(planetName).TrainArmy();
            return $"{planetName} has upgraded its forces!";
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            if (planets.FindByName(planetOne).MilitaryPower == planets.FindByName(planetTwo).MilitaryPower)
            {
                if ((planets.FindByName(planetOne).Weapons.FirstOrDefault(x=>x.Price==15)!=null 
                     && planets.FindByName(planetTwo).Weapons.FirstOrDefault(x => x.Price == 15) != null)
                    ||(planets.FindByName(planetOne).Weapons.FirstOrDefault(x => x.Price == 15) == null
                       &&  planets.FindByName(planetTwo).Weapons.FirstOrDefault(x => x.Price == 15) == null))
                    {
                        planets.FindByName(planetOne).Spend(planets.FindByName(planetOne).Budget/2);
                         planets.FindByName(planetTwo).Spend( planets.FindByName(planetTwo).Budget/2);
                        return $"The only winners from the war are the ones who supply the bullets and the bandages!";
                    }
                if (planets.FindByName(planetOne).Weapons.FirstOrDefault(x => x.Price == 15) != null
                         &&  planets.FindByName(planetTwo).Weapons.FirstOrDefault(x => x.Price == 15) == null)
                    {
                        planets.FindByName(planetOne).Spend(planets.FindByName(planetOne).Budget / 2);
                        planets.FindByName(planetOne).Profit( planets.FindByName(planetTwo).Budget/2);
                        planets.FindByName(planetOne).Profit( planets.FindByName(planetTwo).Army.Select(x=>x.Cost).Sum());
                        planets.FindByName(planetOne).Profit( planets.FindByName(planetTwo).Weapons.Select(x=>x.Price).Sum());
                        planets.RemoveItem(planetTwo);
                        return $"{planetOne} destructed {planetTwo}!";
                    }
                if (planets.FindByName(planetOne).Weapons.FirstOrDefault(x => x.Price == 15) == null
                    && planets.FindByName(planetTwo).Weapons.FirstOrDefault(x => x.Price == 15) != null)
                {
                    planets.FindByName(planetTwo).Spend(planets.FindByName(planetTwo).Budget / 2);
                    planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Budget / 2);
                    planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Army.Select(x => x.Cost).Sum());
                    planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Weapons.Select(x => x.Price).Sum());
                    planets.RemoveItem(planetOne);
                    return $"{planetTwo} destructed {planetOne}!";
                }
            }
            else if (planets.FindByName(planetOne).MilitaryPower>planets.FindByName(planetTwo).MilitaryPower)
            {
                planets.FindByName(planetOne).Spend(planets.FindByName(planetOne).Budget / 2);
                planets.FindByName(planetOne).Profit(planets.FindByName(planetTwo).Budget / 2);
                planets.FindByName(planetOne).Profit(planets.FindByName(planetTwo).Army.Select(x => x.Cost).Sum());
                planets.FindByName(planetOne).Profit(planets.FindByName(planetTwo).Weapons.Select(x => x.Price).Sum());
                planets.RemoveItem(planetTwo);
                return $"{planetOne} destructed {planetTwo}!";
            }
            planets.FindByName(planetTwo).Spend(planets.FindByName(planetTwo).Budget / 2);
            planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Budget / 2);
            planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Army.Select(x => x.Cost).Sum());
            planets.FindByName(planetTwo).Profit(planets.FindByName(planetOne).Weapons.Select(x => x.Price).Sum());
            planets.RemoveItem(planetOne);
            return $"{planetTwo} destructed {planetOne}!";
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(x=>x.MilitaryPower))
            {
                sb.Append(planet.PlanetInfo());
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }
    }
}