using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller:IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations=new DecorationRepository();
            aquariums=new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Aquarium currAquarium;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    currAquarium = new FreshwaterAquarium(aquariumName);
                    aquariums.Add(currAquarium);
                    return $"Successfully added {aquariumType}.";
                case "SaltwaterAquarium":
                    currAquarium = new SaltwaterAquarium(aquariumName);
                    aquariums.Add(currAquarium);
                    return $"Successfully added {aquariumType}.";
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            Decoration currDecoration;
            switch (decorationType)
            {
                case "Ornament":
                    currDecoration = new Ornament();
                    decorations.Add(currDecoration);
                    return $"Successfully added {decorationType}.";
                case "Plant":
                    currDecoration = new Plant();
                    decorations.Add(currDecoration);
                    return $"Successfully added {decorationType}.";
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.Models.FirstOrDefault(x=>x.GetType().Name==decorationType)==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            if (aquariums.FirstOrDefault(x => x.Name == aquariumName) == null)
            {
                throw new InvalidOperationException($"There isn't a aquarium with name {aquariumName}.");
            }

            IDecoration decorationToAdd = decorations.Models.First(x => x.GetType().Name == decorationType);
            aquariums.First(x=>x.Name==aquariumName)
                .AddDecoration(decorationToAdd);
            decorations.Remove(decorationToAdd);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName
            , string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish currFish;
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (aquarium == null)
            {
                throw new InvalidOperationException($"There isn't a aquarium with name {aquariumName}.");
            }
            switch (fishType)
            {
                case "FreshwaterFish":
                    currFish = new FreshwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType().Name!="FreshwaterAquarium")
                    {
                        return $"Water not suitable.";
                    }
                    break;
                case "SaltwaterFish":
                    currFish = new SaltwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType().Name != "SaltwaterAquarium")
                    {
                        return $"Water not suitable.";
                    }
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            aquariums.First(x => x.Name == aquariumName).AddFish(currFish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (aquarium == null)
            {
                throw new InvalidOperationException($"There isn't a aquarium with name {aquariumName}.");
            }
            aquariums.First(x => x.Name == aquariumName).Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (aquarium == null)
            {
                throw new InvalidOperationException($"There isn't a aquarium with name {aquariumName}.");
            }

            decimal aquariumValue = 
                aquarium.Fish.Sum(x=>x.Price)+aquarium.Decorations.Sum(x=>x.Price);
            return $"The value of Aquarium {aquariumName} is {aquariumValue:f2}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}