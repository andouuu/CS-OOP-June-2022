using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> list = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (list.Count!=n)
            {
                BaseHero currHero;
                string currHeroName=Console.ReadLine();
                string currHeroType=Console.ReadLine();
                switch (currHeroType)
                {
                    case "Druid":
                        currHero = new Druid(currHeroName);
                        list.Add(currHero);
                        break;
                    case "Paladin":
                        currHero=new Paladin(currHeroName);
                        list.Add(currHero);
                        break;
                    case "Rogue":
                        currHero = new Rogue(currHeroName);
                        list.Add(currHero);
                        break;
                    case "Warrior":
                        currHero = new Warrior(currHeroName);
                        list.Add(currHero);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in list)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int sum = list.Sum(x => x.Power);
            if (sum>=bossPower)
            {
                Console.WriteLine($"Victory!");
            }
            else
            {
                Console.WriteLine($"Defeat...");
            }
        }
    }
}