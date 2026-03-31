




//fighter game



//class enemy(enemyDamage, enemyHealth, critChance)



// den här koden kommer att ta en class av enemy som innehåller damage health och critchance,  
// sedan kommer den ta en mängd av enemies och slumpa mellan olika underklasser av enemies,
// sedan kommer playern gå igenom leveln och steg för steg döda enemies tills leveln är slut,

//function level(class enemy, mängd enemies, random slump mellan olika enemies)
//{
// 
// enemy.enemyDamage = random.shared.next(minDamage, maxDamage)
//  
//
//}



// Charaktär som du kör som en class
// charcter(damage, health, critchance, mera?)


//funktion för fights och damage du tar
//function fight(charcter, enemy, mängd enemies)


//

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
            name: "Nopassing",
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
List<Enemy> enemyNumbers = [wolf, wolf, wolf];

void Fight(string enemyName, int enemyHealth, List<Attack> enemyAttacks, List<Enemy> enemyNumbers, 
           string playerName, int playerHealth, List<Attack> playerAttacks)
{
    while(enemyHealth >= 0 && playerHealth >= 0)
    {

        Console.WriteLine($"name: {enemyName}: health: ({enemyHealth}) amount: ({enemyNumbers.Count})");

        string attackChoice = "0";
        int attackChoiceInt;
        while(!int.TryParse(attackChoice, out attackChoiceInt) || attackChoiceInt< 1 || attackChoiceInt > playerAttacks.Count)
        {
            print("What attack do u use?");
            int i = 1;
            foreach(Attack A in playerAttacks)
            {
                Console.WriteLine($"{i}: {A.Name} ({A.MinDamage} --- {A.MaxDamage}) (Hitchance = {0 + A.HitChance})");
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
                print($"{enemyName} now has {enemyHealth} health left");

            }
            else
            {
                print($"{playerName} missed");
            }

            if(enemyHealth <= 0 && enemyNumbers.Count > 0)
            {
                print($"{enemyName} is dead");
                enemyNumbers.Remove(enemyNumbers.ElementAt(enemyNumbers.Count-1));
            }
            
            else if (enemyHealth <=0 && enemyNumbers.Count == 0)
            {
                print($"You won there are {enemyNumbers.Count} enemies left");
                break;
            }

            int i = 0;
            foreach (Enemy e in enemyNumbers)
            {

                int number = Random.Shared.Next(0, enemyAttacks.Count);
                Attack enemyAttack = enemyAttacks.ElementAt(number);
                int damage = Random.Shared.Next(enemyAttack.MinDamage, enemyAttack.MaxDamage);
                playerHealth -= damage;
                print($"{e.Enemyname} {i+1}: uses {enemyAttack.Name}");
                print($"{e.Enemyname} deals {damage} to {playerName}");
                print($"{playerName}s health is now {playerHealth}");
                Thread.Sleep(200);







                i++;
            }
        }
        Console.ReadLine();
        
        
    }
}
Fight(wolf.Enemyname, wolf.EnemyHealth, wolf.Attacks, enemyNumbers, 
      Gandalf.PlayerName, Gandalf.PlayerHealth, Gandalf.Playerattacks);








