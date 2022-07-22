namespace Raiding
{
    public class Druid:BaseHero
    {
        public Druid(string name)
        {
            Name=name;
            Power = 80;
        }
        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}