public class Character(string playerName, int playerHealth, List<Attack> playerattacks)
{
    public string PlayerName { get; } = playerName;
    public int PlayerHealth { get; } = playerHealth;
    public List<Attack> Playerattacks { get; } = playerattacks;
}