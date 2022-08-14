using System;
using System.Collections.Generic;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Repositories
{
    public class UnitRepository:IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models=new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get=>this.models;
        }
        public void AddItem(IMilitaryUnit model)
        {
            string unitToAdd = model.GetType().Name;
            if (models.FirstOrDefault(x => x.GetType().Name == unitToAdd) == null)
            {
                models.Add(model);
            }
        }

        public IMilitaryUnit FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unitToRemove = models.FirstOrDefault(x => x.GetType().Name == name);
            if (unitToRemove != null)
            {
                models.Remove(unitToRemove);
                return true;
            }
            return false;
        }
    }
}