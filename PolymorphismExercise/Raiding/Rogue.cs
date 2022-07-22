namespace Raiding
{
    public class Rogue:BaseHero
    {
        public Rogue(string name)
        {
            Name=name;
            Power = 80;
        }
        public override string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power} damage";
        }
    }
}