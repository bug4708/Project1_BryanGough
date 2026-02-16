using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using TextAdventure1;

/* Text Adventure 1 - Art 287
 * Who needs enemies?
 * by Bryan Gough
 */

class Program() {
    static void Main(string[] args)
    {
        //backstory
        Console.WriteLine("Welcome to 'Who needs enemies?' by Bryan Gough");
        Console.WriteLine();
        Console.WriteLine("(Press enter to continue)");
        Console.ReadLine();

        Console.WriteLine("Choose your character:");
        Console.WriteLine("A: Jill Childers - Assassin, daughter of Mafia Capo Will Childers, betrayed");
        Console.WriteLine("                   by her father as he ascended the ranks of the mafia");
        Console.WriteLine("                  -Special Ablity: Parry Upon low health greatly reduce incoming damage while reflecting the attack. ");
        Console.WriteLine("B: Richy Marsh   - Handy man, husband to the kidnapped Ayame Marsh, searching");
        Console.WriteLine("                   for answers regarding his powers and the disappearance of his wife");
        Console.WriteLine("                  -Special Abilty: Berserk doubles damage for the current fight.");
        Console.WriteLine();
        //character selection

        Console.WriteLine("Please input A or B to select character.");
        string input = Sselection(2);

        string charName;
        if (input.Equals("A")) {
            charName = "Jill";
        } else {
            charName = "Ricky";
        }

        Character player = new Character(charName);
        Console.WriteLine($"You chose {charName}!");
        //introduction based on character
        player.BackStory();
        Console.WriteLine("(Press enter to continue)");
        Console.ReadLine();
        Beginning(player);
    }
    public static void Beginning(Character player)
    {
        //enter the building
        Console.WriteLine("You approach the edge of the mafia headquarters. What would you like to do?");
        Console.WriteLine("A. Choose an entrance.");
        Console.WriteLine("B. Check inventory.");
        Console.WriteLine("C. Check Health.");
        Console.WriteLine();

        string choice = Sselection(3);  //reads line choice from above
        if (choice.Equals("A"))
        {
            //entrance
            Console.WriteLine("Entrances include:");
            Console.WriteLine("A. Front Entrance");
            Console.WriteLine("B. Staff Entrance");
            string entrance = Sselection(2);
            if (entrance.Equals("A"))
            {
                OutFront(player);
            }
            else { OutBack(player); }

        }
        else if (choice.Equals("B"))
        {
            player.DisplayInventory();
            Console.WriteLine("(Press enter to continue)");
            Console.ReadLine();
            Beginning(player);
        }
        else
        {
            player.DisplayHealth();
            Console.WriteLine("(Press enter to continue)");
            Console.ReadLine();
            
            Beginning(player);
        }
    }
    //rooms: { "outFront", "outBack", "foyer", "dormitories", "kitchen", "office" }

    public static void OutFront(Character player) {
        //front entrance
        Console.WriteLine("Well, now you're at the front door. What will you do?");
        Console.WriteLine("A. Kick down the door!");
        Console.WriteLine("B. Explore.");
        //Console.WriteLine("C. Use special character ability."); 
        //stealth elements removed for time sake, but I would like to implement later if we continue to change this project
        string choice = Sselection(2);
        if (choice.Equals("A"))
        {
            Console.WriteLine("A guard appears in the doorway, blocking your entrance. He charges right at you!");
            Enemy guard = new Enemy();
            bool result = guard.Combat(player);
            if (result == true)
            {
                Console.WriteLine("Guard defeated!");
                Console.WriteLine("Moving on to the Foyer...");
                Foyer(player);
            }
            else
            {
                Defeat();
            }
        }
        if (choice.Equals("B"))
            {
                Console.WriteLine("Nothing to see here really, it's just the entrance.");
                Console.WriteLine("Would you like to go another way?");
                Console.WriteLine("A. Yes, I'd like to go in the front.");
                Console.WriteLine("B. No, I'd like to stay.");
                string direction = Sselection(2);
                if (direction.Equals("A")) { OutFront(player); }
                else { OutBack(player); }
            }
    }
    public static void OutBack(Character player)
    {
        //back yard entrance
        Console.WriteLine("From what you could gather, this back door leads into the dormitories. What will you do?");
        Console.WriteLine("A. Kick down the door and teach whoever is there a lesson.");
        Console.WriteLine("B. Find a way in that is more quiet.");
        Console.WriteLine("C. Explore.");
        Console.WriteLine();
        string choice = Sselection(3);
        if (choice.Equals("A"))
        {
            Console.WriteLine("Every guard that was asleep wakes up, you'll have to fight your way through!");
            int health = 50; int strength = 10;
            Enemy guards = new Enemy(health, strength);
            bool result = guards.Combat(player);
            if (result == true)
            {
                Console.WriteLine("Guards defeated!");
                Console.WriteLine("Moving on to the Dorms...");
                Dormitories(player);
            }
            else
            {
                Defeat();
            }
        }
        if (choice.Equals("B")) {
            Console.WriteLine("You try to pick the Lock");
            if (player.charName.Equals("Jill") && player.health == player.HEALTH_MAX)
            {
                Console.WriteLine("Success! You enter the dorms undetected.");
                Dormitories(player);
            }
            else if (player.charName.Equals("Ricky"))
            {
                Console.WriteLine("Do you think Ricky knows how to pick a lock...");
                OutBack(player);
            }
            else
            {
                Console.WriteLine("You have been detected, just kick it down at this point...");
                OutBack(player);
            }
        }
        if (choice.Equals("C"))
        {
            Console.WriteLine("The door is locked, but it can be picked.");
            Console.WriteLine("Would you like to go another way?");
            Console.WriteLine("A. Yes, I'd like to go in the front.");
            Console.WriteLine("B. No, I'd like to stay.");
            string direction = Sselection(2);
            if (direction.Equals("A")) { OutFront(player); }
            else { OutBack(player); }
        }
    }
    public static void Foyer(Character player)
    {
        //foyer scenario
        Console.WriteLine("This is the main Lobby of the building. There is one way forward,");
        Console.WriteLine("but the elevator is guarded. How will you proceed?");
        Console.WriteLine("A. Proceed forward towards the elevator.");
        Console.WriteLine("B. Explore.");
        Console.WriteLine();
        string choice = Sselection(2);
        if (choice.Equals("A"))
        {
            Console.WriteLine("There is a crowd of people in front. They don't look very happy to see you.");
            int health = 50; int strength = 10;
            Enemy guards = new Enemy(health, strength);
            bool result = guards.Combat(player);
            if (result == true)
            {
                Console.WriteLine("Guards defeated!");
                Console.WriteLine("Moving on to the Elevator...");
                Office(player);
            }
            else
            {
                Defeat();
            }
        }
        if (choice.Equals("B")) {
            Console.WriteLine("You find a health pack! + 50% hp :o");
            player.health += player.HEALTH_MAX * 1 / 2;
            Console.WriteLine("You see there is a dormitory through another doorway nearby. Would you like to go there?");
            Console.WriteLine("A. Yes, lets go to the dormitories.");
            Console.WriteLine("B. No, I'd like to stay.");
            string direction = Sselection(2);
            if (direction.Equals("A")) { Dormitories(player); }
            else { Foyer(player); }
        }
    }
    public static void Dormitories(Character player)
    {
        //dorms scenario
        Console.WriteLine("You've made your way into the dormitories. Would you like to proceed or look around?");
        Console.WriteLine("A. Proceed to the Foyer.");
        Console.WriteLine("B. Look around.");
        string choice = Sselection(2);
        if (choice.Equals("A"))
        {
            if(player.health == player.HEALTH_MAX)
            {
                Console.WriteLine("The Guards didn't hear you! proceeding to Foyer.");
                Foyer(player);
            }
            else 
            {
                Console.WriteLine("The Guards catch you trying to leave.");
                int health = 50; int strength = 10;
                Enemy guards = new Enemy(health, strength);
                bool result = guards.Combat(player);
                if (result == true)
                {
                    Console.WriteLine("Guards defeated!");
                    Console.WriteLine("Moving on to the Foyer...");
                    Foyer(player);
                }
                else
                {
                    Defeat();
                }
            }
        }
        if (choice.Equals("B"))
        {
            Console.WriteLine("You go through their things, and stumble upon a memior.");
            Console.WriteLine("It details the affairs of the Don, but one thing doesn't seem right...");
            Console.WriteLine("The Don has a weakness! He is allergic to 'Apollo's Leaf', a rare herb.");
            player.inventory.Add("Memoir");
            Dormitories(player);
        }
    }
    public static void Office(Character player)
    {
        //office scenario
        Console.WriteLine("Standing in front of the office door is the Don's right hand man");
        Console.WriteLine("He is holding what seems to be a crystal ball in one hand, emminating a dark light.");
        Console.WriteLine("The sorcerer becons you to approach...");
        Console.WriteLine("A. Show this arcane bastard why they should have never hurt you.");
        Console.WriteLine("B. Continue Exploring first.");
        string choice = Sselection(2);
        if (choice.Equals("A"))
        {
            Console.WriteLine("He laughs heartily.");
            Console.WriteLine("\"This will be fun\", he utters with a grin.");
            Enemy wizard = new Enemy.Mage();
            bool result = wizard.Combat(player);
            if (result == true)
            {
                Console.WriteLine("The wizard is no more. He crumples to the floor");
                Console.WriteLine("Now time for the Don himself");
                Boss(player);
            }
            else
            {
                Defeat();
            }
        }
        if (choice.Equals("B"))
        {
            if (player.inventory.Count > 1) {
                Console.WriteLine($"Remembering the memoir they found earlier, {player.charName} finds the Apollo's Leaf in the safe");
                Console.WriteLine();
            }
            Console.WriteLine("You can access the Foyer from here, as well as the BOSS's office");
            Console.WriteLine("A. Go to foyer.");
            Console.WriteLine("B. Stay outside the office");
            string direction = Sselection(2);
            if (direction.Equals("A")) { Foyer(player); }
            else { Office(player); }

        }
    }
    public static void Boss(Character player)
    {
        if (player.charName.Equals("Jill"))
        {
            Console.WriteLine("  Don: \"Jill! it's really you!\"");
            Console.WriteLine("       \"How did you survive?\"");
            Console.WriteLine(" Jill: \"Yes father, it is me. Don't worry, soon we'll be asking another important question...\"");
            Console.WriteLine("  Don: \"And what is that?\"");
            Console.WriteLine(" Jill: \"How did you lose your life to your own dauther!\"");

        }
        else
        {
            Console.WriteLine("Ricky: \"Are you the man who took my wife? My dear Ayame!\"");
            Console.WriteLine("  Don: \"Not myself, you see it's not so straight forward.\"");
            Console.WriteLine("Ricky: \"I refuse to put up with you or your goons any longer.\"");
            Console.WriteLine("     : \"Show me where my wife is and I'll let you live.\"");
            Console.WriteLine("  Don: \"How quaint. With everything else I have to deal with, I'll allow you a quick death.\"");
        }
        Enemy don = new Enemy.Boss();
        bool result = don.Combat(player);
        if (result == true)
        {
            Console.WriteLine("The Don is defeated");
            if (player.charName.Equals("Jill"))
            {
                Console.WriteLine("Over the body of her dead father, Jill finally takes her seat as the new Don of the Childers Mafia");
                Console.WriteLine("That evil man will never be able to hurt anyone ever again. She will be able to lead the organization");
                Console.WriteLine("to be something greater and kinder.");
            }
            else
            {
                Console.WriteLine("You rescue your wife from her bonds, and finally escape from the clutches of the Mob");
                Console.WriteLine("Although you still have little information about your powers, this adventure has taught you a lot");
                Console.WriteLine("about who you are, and how to use them");
            }
            Console.WriteLine("");
            Console.WriteLine("Play again? A for yes, B for no");

            string direction = Sselection(2);
            if (direction.Equals("A")) { Main(null); }
            else
            {
                Console.WriteLine("Thank you for playing!!!");
            }
        }
        else
        {
            Defeat();
        }
    }
    public static void Defeat()
    {
        Console.WriteLine("You have been defeated :(");
        Console.WriteLine("It's okay though! There's always next time!");
        Console.WriteLine("Press A. to retry, press B. to close game");
        string cont = Sselection(2);
        if (cont.Equals("A")) { Main(null); }
        else { return; }
    }
    public static string Sselection(int optionNum)
    {
        string input = "";
        string options = "ABCD";
        while (!options.Substring(0,optionNum).Contains(input) || input.Length==0 || input.Length != 1)
        {
            input = Console.ReadLine();
            input = input.ToUpper().Trim();
        }
        return input;
    }
}