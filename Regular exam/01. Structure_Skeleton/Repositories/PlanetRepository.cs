using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models=new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
        {
            get=>this.models;
        }
        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            IPlanet planetToRemove = models.FirstOrDefault(x => x.Name == name);
            if (planetToRemove != null)
            {
                models.Remove(planetToRemove);
                return true;
            }
            return false;
        }
    }
}