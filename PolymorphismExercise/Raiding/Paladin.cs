using System.Runtime.CompilerServices;

namespace Raiding
{
    public class Paladin:BaseHero
    {
        public Paladin(string name)
        {
            Name = name;
            Power = 100;
        }
        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}