﻿namespace Raiding
{
    public class Warrior:BaseHero
    {
        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }
        public override string CastAbility()
        {
            return $"Warrior - {Name} hit for {Power} damage";
        }
    }
}