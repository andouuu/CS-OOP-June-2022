using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet:IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name,double budget)
        {
            Name=name;
            Budget=budget;
            units = new UnitRepository();
            weapons=new WeaponRepository();
            //MilitaryPower = Math.Round(GetMilitaryPower(), 3);
           
        }
        public string Name
        {
            get=>this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double sum = 0;
                sum += units.Models.Select(x => x.EnduranceLevel).Sum() +
                       weapons.Models.Select(x => x.DestructionLevel).Sum();
                if (Army.FirstOrDefault(x => x.GetType().Name == "AnonymousImpactUnit") != null)
                {
                    sum += sum * 0.30;
                }

                if (Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
                {
                    sum += sum * 0.45;
                }

                return Math.Round(sum, 3);
            }
            private set
            {
                militaryPower=value;
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get => units.Models;
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get => weapons.Models;
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var militaryUnit in Army)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget-amount<0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget-=amount;
        }

        public void Profit(double amount)
        {
            Budget+=amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (Army.Count==0)
            {
                sb.AppendLine($"--Forces: No units");
            }
            else
            {
                List<string> armyList = Army.Select(x => x.GetType().Name).ToList();
                sb.AppendLine($"--Forces: {string.Join(", ", armyList)}");
            }
            if (Weapons.Count == 0)
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                List<string> weaponList = Weapons.Select(x => x.GetType().Name).ToList();
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weaponList)}");
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().Trim();
            //Planet: {planetName} 
            //--Budget: { budgetAmount} billion QUID
            //--Forces: { militaryUnitName1}, { militaryUnitName2}, { militaryUnitName3} (…) / No units
            //--Combat equipment: { weaponName1}, { weaponName2}, { weaponName3} (…) / No weapons
            //--Military Power: { militaryPower}
        }

        //private double GetMilitaryPower()
        //{
        //    double sum=0;
        //    sum += units.Models.Select(x => x.EnduranceLevel).Sum() +
        //           weapons.Models.Select(x => x.DestructionLevel).Sum();
        //    if (Army.FirstOrDefault(x=>x.GetType().Name== "AnonymousImpactUnit")!=null)
        //    {
        //        sum += sum * 0.30;
        //    }

        //    if (Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
        //    {
        //        sum += sum * 0.45;
        //    }

        //    return sum;
        //}
    }
}