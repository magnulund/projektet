public class Attack(string name, int minDamage, int maxDamage, int hitChance)
{
    public string Name { get; } = name;
    public int MinDamage { get; } = minDamage;
    public int MaxDamage { get; } = maxDamage;
    public int HitChance { get; } = hitChance;
}