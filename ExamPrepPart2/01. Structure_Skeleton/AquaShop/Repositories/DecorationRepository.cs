using System;
using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository:IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models
        {
            get => models;
        }
        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            if (Models.FirstOrDefault(x=>x==model)!=null)
            {
                models.Remove(model);
                return true;
            }
            return false;
        }

        public IDecoration FindByType(string type)
        {
            return Models.FirstOrDefault(x=>x.GetType().Name==type);
        }
    }
}