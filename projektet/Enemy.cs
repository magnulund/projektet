public class Enemy(string enemyName, int enemyHealth, List<Attack> attacks)
{
    public string Enemyname { get; } = enemyName;
    public int EnemyHealth { get; set; } = enemyHealth;
    public List<Attack> Attacks { get; } = attacks;
}