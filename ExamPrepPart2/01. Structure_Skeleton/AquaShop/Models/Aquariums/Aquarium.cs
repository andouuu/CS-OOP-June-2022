using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium:IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;

        public Aquarium(string name,int capacity)
        {
            Name=name;
            Capacity=capacity;
            Decorations=new List<IDecoration>();
            Fish = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }

        }

        public int Comfort => Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public void AddFish(IFish fish)
        {
            if (Fish.Count==capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            if (Fish.FirstOrDefault(x=>x==fish)!=null)
            {
                Fish.Remove(fish);
                return true;
            }
            return false;
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb=new StringBuilder();
            string type=this.GetType().Name;
            sb.AppendLine($"{Name} ({type}):");
            if (Fish.Count==0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                List<string> fishNames=Fish.Select(x=>x.Name).ToList();
                sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString();
        }
    }
}