using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository:IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models=new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
        {
            get=>this.models;
        }
        public void AddItem(IWeapon model)
        {
            string weaponToAdd = model.GetType().Name;
            if (models.FirstOrDefault(x => x.GetType().Name == weaponToAdd) == null)
            {
                models.Add(model);
            }
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            IWeapon weaponToRemove=models.FirstOrDefault(x => x.GetType().Name == name);
            if (weaponToRemove!=null)
            {
                models.Remove(weaponToRemove);
                return true;
            }
            return false;
        }
    }
}