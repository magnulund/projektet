







string print(string printer)
{
    int Sleep = 25;
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
    return printer;
}
// en class för mina enemies så jag kan göra nya vart som helst och när som helst i koden.
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
// listan baseattacks och karaktären baseCharacter är så man kan skapa egna karaktärer. 
List<Attack> baseAttacks = [];
Character baseCharacter = new Character(
    playerName: "",
    playerHealth: 0,
    playerattacks: baseAttacks

);

// jag använder listorna för jag vill kunna ändra innehållet i listorna.
List<Character> startCharacters = [Gandalf, Aragorn];
List<Enemy> enemyNumbers = [wolf, wolf, wolf];

print("Do you want to create a character?");
print("1. Yes");
print("2. No");
string  charcterCreateChoice = Console.ReadLine();
int charcterCreateChoiceInt;
while (!int.TryParse(charcterCreateChoice, out charcterCreateChoiceInt) || charcterCreateChoiceInt >= 3 && charcterCreateChoiceInt <= 0)
{
    Console.Clear();
    print("Do you want to create a character?");
    print("1. Yes");
    print("2. No");
    charcterCreateChoice = Console.ReadLine();
}
if(int.TryParse(charcterCreateChoice, out charcterCreateChoiceInt) && charcterCreateChoiceInt == 1)
{
    startCharacters.Add(CharcterCreator(baseCharacter, baseAttacks));
}

string characterChoice = "";
// en dictionary eftersom jag vill kunna hålla strings med värden kopplade till sig som exempel en string med en mängd av den stringen.
Dictionary<string, int> backpack = []; 

// en while loop som printar ut alla olika karaktärer och deras stats och attacker
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
        bool Win = false;
        if (int.TryParse(wolfFightChoice, out int wolfFightChoiceInt) && wolfFightChoiceInt == 1)
        {
            Win = Fight(wolf.EnemyName, wolf.EnemyHealth, wolf.Attacks, enemyNumbers, wolf,
                startCharacters.ElementAt(characterChoiceInt -1).PlayerName, startCharacters.ElementAt(characterChoiceInt-1).PlayerHealth, startCharacters.ElementAt(characterChoiceInt-1).Playerattacks,
                Win);
            if (Win == true)
            {
                backpack.Add("Meat", 6);
                backpack.Add("Wolf fur", 3);
                print("You start skining the wolves");
                print("The meat and pelt are stored in your backpack");
                

            }
            else if (Win == false)
            {
                print("You lost the quest...");
                print("if you want to play again restart");
            }
        }
       
    }
}

// en funktion som utför en fight där om man vinner får man en bool som ger true och om man förlorar blir boolen false.
bool Fight(string enemyName, int enemyHealth, List<Attack> enemyAttacks, List<Enemy> enemyNumbers, Enemy enemyType,
           string playerName, int playerHealth, List<Attack> playerAttacks, bool didYouWin)
{
    while(enemyHealth >= 0 && playerHealth >= 0 || enemyNumbers.Count > 0)
    {
        int basehealth = enemyType.EnemyHealth;
        Console.WriteLine($"name: {enemyName}: health: ({enemyHealth}) amount: ({enemyNumbers.Count})");

        //kollar vilken attack som man vill använda. Kan göra det till en funktion kanske och spara utrymme.
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
        // Kollar om attacken man valt träffar eller inte.
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
            if(enemyHealth <= 0 && enemyNumbers.Count > 0)
            {
                print($"{enemyName} {enemyNumbers.Count} is dead");
                enemyNumbers.Remove(enemyNumbers.ElementAt(enemyNumbers.Count-1));
                
                enemyHealth = basehealth;
            }
            if (enemyNumbers.Count <= 0)
            {
                print($"You won there are {enemyNumbers.Count} enemies left");
                didYouWin = true;
                break;
            }

            
           
            // Hör gör alla enemies som är kvar damage på spelaren.
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
                didYouWin = false;
                break;
            }
        }    
    };
    return didYouWin;
}


//en funktion för att göra kortare kod på vissa ställen för int.tryparse
int choiceParse(string choice)
{
    int choiceIntFail;
    while (!int.TryParse(choice, out choiceIntFail))
    {
        choice = Console.ReadLine();
    }
    if(int.TryParse(choice, out int choiceInt))
    {
        return choiceInt;    
    }
    else
    {
        return -1;
    } 
    
}
//en funktion som gör att man kan skapa en karaktär.
Character CharcterCreator(Character e, List<Attack> a)
{
    //här väljer man namnet
    Console.WriteLine("What is the name of your character?");
    e.PlayerName = Console.ReadLine();
    //här väljer man hur mycket hälsa man ska ha.
    Console.WriteLine("How much health does your charcter have");
    string healthChoice = Console.ReadLine();
    while(!int.TryParse(healthChoice, out int healthChoiceIntFail))
    {
        healthChoice = Console.ReadLine();
    }
    if(int.TryParse(healthChoice, out int healthChoiceInt))
    {
        e.PlayerHealth = healthChoiceInt;
    }
    e.Playerattacks = 
    [
    ];
    //kollar hur många attacker man vill ha
    Console.WriteLine("How many attacks you want?");
    string attackamount = Console.ReadLine();
    while(choiceParse(attackamount) >= 5 && choiceParse(attackamount) <=0)
    {
        Console.Clear();
        Console.WriteLine("How many attacks you want?");
        attackamount = Console.ReadLine();
    }
    int val = choiceParse(attackamount);
    //här väljer man stats för den mängd attcker man valde.
    for (int i = 0; i < val; i++)
    {
        //namnet på attacken
        Console.WriteLine($"What should be the name of attack number {i + 1}");
        string characterName = Console.ReadLine();
        //min damage på attacken
        Console.WriteLine($"What should be the minimum damage of attack number {i + 1}");
        string minDamageChoice = Console.ReadLine();
        int minDamageChoiceInt;
        while(!int.TryParse(minDamageChoice, out minDamageChoiceInt))
        {
            minDamageChoice = Console.ReadLine();
        }
        //max damage på attacken
        Console.WriteLine($"What should be the maximum damage of attack number {i + 1}");
        string maxDamageChoice = Console.ReadLine();
        int maxDamageChoiceInt;
        while(!int.TryParse(maxDamageChoice, out maxDamageChoiceInt))
        {
            maxDamageChoice = Console.ReadLine();
        }
        //hitchancen på attacken
        Console.WriteLine($"What should be the hitchance of attack number {i + 1}");
        string hitChanceDamageChoice = Console.ReadLine();
        int hitChanceDamageChoiceInt;
        while(!int.TryParse(hitChanceDamageChoice, out hitChanceDamageChoiceInt))
        {
            hitChanceDamageChoice = Console.ReadLine();
        }
        // här lägger jag in alla attacker i listan av attacker.
        a.Add (new Attack (
            name: characterName,
            minDamage: minDamageChoiceInt,
            maxDamage:maxDamageChoiceInt,
            hitChance:hitChanceDamageChoiceInt
        ));
        
    }

    for (int i = 1; i < val; i++)
    {
        //Här lägger vi in listan som karaktärens attacklista
        e.Playerattacks = a;
    };
    return e;
    
}





