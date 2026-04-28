public class Character(string playerName, int playerHealth, List<Attack> playerattacks)
{
    public string PlayerName { get; set;} = playerName;
    public int PlayerHealth { get; set;} = playerHealth;
    public List<Attack> Playerattacks { get; set;} = playerattacks;
}