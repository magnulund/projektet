public class Attack(string name, int minDamage, int maxDamage, int hitChance)
{
    public string Name { get; set;} = name;
    public int MinDamage { get; set;} = minDamage;
    public int MaxDamage { get; set;} = maxDamage;
    public int HitChance { get; set;} = hitChance;
}