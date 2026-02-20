using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static TextAdventure1.Enemy;

namespace TextAdventure1
{
    internal class Character
    {
        public string charName;
        public int HEALTH_MAX;
        public int health;
        public int strength_default;
        public int strength;
        public int energy;
        public List<string> inventory = new List<string> (0);

        public Character(string charName) { 
            this.charName = charName;

            if(this.charName == "Jill")
            {
                inventory.Add("Katana");
                this.health = 100; //start w 100 hp
                this.HEALTH_MAX = 100;
                this.strength_default = 5;
                this.strength = 5;
            } else
            {
                inventory.Add("Burger");
                this.health = 110; //start w 50 hp
                this.HEALTH_MAX = 110;
                this.strength_default = 20;
                this.strength = 20;
                this.energy = 2;
            }
        }
        public void CombatSpecial(Enemy enemy)
        {
            if (charName.Equals("Jill"))
            {
                Console.WriteLine("Jill is trying to parry!");
                if (this.health <= enemy.strength) {
                    Console.WriteLine("Jill parries the enemy's strike!");
                    Console.WriteLine("The enemy is staggered and takes double damage!");
                    this.health -= 2;
                    enemy.health -= enemy.strength;
                }
                else { 
                    Console.WriteLine("She fails the parry!");
                        }
                
            } else {
                Console.WriteLine("Ricky is powering up!");
                if(this.energy > 0)
                {
                    enemy.health -= 1/2 * enemy.HEALTH_MAX;
                    this.energy--;
                }
            }
        }
        public void DisplayStrength()
        {
            Console.WriteLine(charName + " will do " + this.strength + " damage in combat");
        }
        public void DisplayHealth() {
            Console.WriteLine(charName + " has " + this.health + " hp remaining!");
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory Contains:");

            for(int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(inventory[i]);
            }
            Console.WriteLine();
        }

        public void BackStory()
        {
            if(this.charName == "Jill")
            {
                Console.WriteLine();
                Console.WriteLine("Once under the tutelage of a famed mafioso, Jill was mentored from a");
                Console.WriteLine("young age in the ways of killing. Her father, Will, brought her in as");
                Console.WriteLine("he rapidly ascended the ranks of the organization.Soon, Will was the de");
                Console.WriteLine("facto leader of the entire country, but with such a meteoric rise, there");
                Console.WriteLine("had to be some sacrifices. Jill was shot, apparently dead, in a secret");
                Console.WriteLine("Mafia hideout. Now, at a loss for why her father would do such a thing,");
                Console.WriteLine("and barely hanging onto life by occult powers unknowable to her, ");
                Console.WriteLine("she strives to find her answers and to have her revenge.");

                Console.WriteLine();
            } 
            if(this.charName == "Ricky")
            {
                Console.WriteLine();
                Console.WriteLine("Ricky was once a simple man, living with his wife Ayame in a small town");
                Console.WriteLine(" on the frontier of the civilized world. After 20 years of working the");
                Console.WriteLine("same job, this honest working man was looking for something new to bring");
                Console.WriteLine("the spark to his life. On a warm, windy evening while relaxing on the");
                Console.WriteLine("couch with his wife, he heard a knock on the door. As he opened it,");
                Console.WriteLine("the mafia men didn’t give him a moment to react. He was covered in hands,");
                Console.WriteLine("placed in restraints, and engulfed in total chaos. Suddenly, however, they");
                Console.WriteLine("all stopped. Or more accurately, were stopped by him. After this great");
                Console.WriteLine("awakening, he is seeking answers to what exactly happened to him, and");
                Console.WriteLine("why they took his beloved wife.\r\n");
                Console.WriteLine();
            }
        }
    }
}
