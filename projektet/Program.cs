






int Sleep = 25;
string print(string printer)
{
    for (int i = 0; i < printer.Length; i++)
    {
        Console.Write(printer.ElementAt(i));
        Thread.Sleep(Sleep);
        if (Console.KeyAvailable)
        {
            if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Sleep = 0;
            }
        }
    }
    Console.WriteLine("");
    Sleep = 25;
    return printer;
}

Enemy wolf= new Enemy(
    enemyName: "wolf", 
    enemyHealth: 25, 
    [
        new Attack(
            name: "Bite",
            minDamage: 15,
            maxDamage: 20,
            hitChance: 50
        ),
        new Attack(
            name: "tailwhack",
            minDamage: 5,
            maxDamage: 10,
            hitChance: 25     
        )        
    ]);
Character Gandalf = new Character(
    playerName: "Gandalf",
    playerHealth: 250,
    playerattacks:
    [
        new Attack(
            name: "Fireball",
            minDamage: 15,
            maxDamage: 25,
            hitChance: 50
        ),
        new Attack(
            name: "YOU SHALL NOT PASS!!!",
            minDamage: 30,
            maxDamage: 50,
            hitChance: 25
        ),
        new Attack(
            name: "Magic missile",
            minDamage: 5,
            maxDamage: 10,
            hitChance: 100
        )

    ]
);
Character Aragorn = new Character(
    playerName: "Aragorn",
    playerHealth: 150,
    playerattacks: 
    [
        new Attack(
            name: "Isildurs slash",
            minDamage: 15,
            maxDamage: 30,
            hitChance: 55
        ),
        new Attack(
            name: "Slash",
            minDamage: 10,
            maxDamage: 20,
            hitChance: 75
        ),
        new Attack(
            name: "Bane of swords",
            minDamage: 30,
            maxDamage: 65,
            hitChance: 10

        )

    ]
);
List<Character> startCharacters = [Gandalf, Aragorn];
List<Enemy> enemyNumbers = [wolf, wolf, wolf];
string characterChoice = "";
Dictionary<string, int> backpack = []; 
while (!int.TryParse(characterChoice, out int characterChoiceIntFail) || characterChoiceIntFail > startCharacters.Count && characterChoiceIntFail < 1)
{
    print("Which character do you want to choose");
    int e = 1;
    foreach (Character C in startCharacters)
    {

        print($"Charcter {e}");
        print($"Name: ({C.PlayerName})");
        print($"Health: ({C.PlayerHealth})");
        int i = 1;
        foreach ( Attack AA in C.Playerattacks)
        {
            print($"Attack {i}");
            print($"Name: ({AA.Name})");
            print($"damage: ({AA.MinDamage} - {AA.MaxDamage})");
            print($"Hitchance: ({AA.HitChance})");
            i++;
        }
        Console.WriteLine("");
        e++;
    }
    characterChoice = Console.ReadLine();
}
if (int.TryParse(characterChoice, out int characterChoiceInt) || characterChoiceInt < startCharacters.Count && characterChoiceInt > 0)
{
    print("Do you want to go on a quest?");
    print("1. Yes");
    print("2. No");
    string questChoice = Console.ReadLine();
    choiceParse(questChoice);
    if (int.TryParse(questChoice, out int questChoiceInt) && questChoiceInt == 1)
    {
        print("You walk a bit travelling over a hill and see some wolves");
        print("Do you want to fight them?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        string wolfFightChoice = Console.ReadLine();
        choiceParse(wolfFightChoice);
        if (int.TryParse(wolfFightChoice, out int wolfFightChoiceInt) && wolfFightChoiceInt == 1)
        {
            Fight(wolf.EnemyName, wolf.EnemyHealth, wolf.Attacks, enemyNumbers, 
                startCharacters.ElementAt(characterChoiceInt -1).PlayerName, startCharacters.ElementAt(characterChoiceInt-1).PlayerHealth, startCharacters.ElementAt(characterChoiceInt-1).Playerattacks);
            if (startCharacters.ElementAt(characterChoiceInt -1).PlayerHealth > 0)
            {
                backpack.Add("Meat", 6);
                backpack.Add("Wolf fur", 3);
                print("You start skining the wolves");
                print("The meat and pelt are stored in your backpack");
                

            }
        }
       
    }
}


void Fight(string enemyName, int enemyHealth, List<Attack> enemyAttacks, List<Enemy> enemyNumbers, 
           string playerName, int playerHealth, List<Attack> playerAttacks)
{
    while(enemyHealth >= 0 && playerHealth >= 0 || enemyNumbers.Count > 0)
    {
        int basehealth = enemyHealth;
        Console.WriteLine($"name: {enemyName}: health: ({enemyHealth}) amount: ({enemyNumbers.Count})");

        string attackChoice = "0";
        int attackChoiceInt;
        while(!int.TryParse(attackChoice, out attackChoiceInt) || attackChoiceInt< 1 || attackChoiceInt > playerAttacks.Count)
        {
            print("What attack do u use?");
            int i = 1;
            foreach(Attack A in playerAttacks)
            {
                Console.WriteLine($"{i}: {A.Name} ({A.MinDamage} --- {A.MaxDamage}) (Hitchance = {0 + A.HitChance}%)");
                i++;
            }
            attackChoice = Console.ReadLine();
        }

        Attack attack = playerAttacks[attackChoiceInt-1];
        if(attack is not null)
        {
            print($"{playerName} uses {attack.Name}");
            int Hitchance = Random.Shared.Next(10001 / 100);
            if (Hitchance <= attack.HitChance)
            {
                int damage = Random.Shared.Next(attack.MinDamage, attack.MaxDamage);
                enemyHealth -= damage;
                print($"{playerName} deals {damage} to {enemyName}");
                print($"{enemyName} now has {enemyHealth} health left");

            }
            else
            {
                print($"{playerName} missed");
            }

            if (enemyNumbers.Count == 0)
            {
                print($"You won there are {enemyNumbers.Count} enemies left");
                break;
            }
            else if(enemyHealth <= 0 && enemyNumbers.Count > 0)
            {
                print($"{enemyName} {enemyNumbers.Count} is dead");
                enemyNumbers.Remove(enemyNumbers.ElementAt(enemyNumbers.Count-1));
                
                enemyHealth = basehealth;
            }
            
           

            int i = 0;
            foreach (Enemy e in enemyNumbers)
            {

                int number = Random.Shared.Next(0, enemyAttacks.Count);
                Attack enemyAttack = enemyAttacks.ElementAt(number);
                int damage = Random.Shared.Next(enemyAttack.MinDamage, enemyAttack.MaxDamage);
                playerHealth -= damage;
                print($"{e.EnemyName} {i+1}: uses {enemyAttack.Name}");
                print($"{e.EnemyName} deals {damage} to {playerName}");
                print($"{playerName}s health is now {playerHealth}");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(200);
                i++;

            }
            if(playerHealth <= 0)
            {
                break;
            }
        }    
    }
    return;
}

void choiceParse(string choice)
{
    int choiceIntFail;
    while (!int.TryParse(choice, out choiceIntFail))
    {
        choice = Console.ReadLine();
    }

    return;
}







