using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TextAdventure1
{
    internal class Enemy
    {
        public int HEALTH_MAX;
        public int health;
        public int strength;
        public string affliction;

        public Enemy()
        {
            this.HEALTH_MAX = 10;
            this.health = 10;
            this.strength = 10;
        }
        public Enemy(int health, int strength) {
            this.HEALTH_MAX = health;
            this.health = health;
            this.strength = strength;
        }
        public bool Combat(Character player)
        {
            player.strength = player.strength_default;
            while (this.health > 0 && player.health > 0) {
                Console.WriteLine($"You have {player.health} hp. The enemy has {this.health} hp.");
                Console.WriteLine("What will you do?");
                Console.WriteLine("A. Attack.");
                Console.WriteLine("B. Special Ability.");
                Console.WriteLine("C. Use item.");
                string input = Choices.Number(3);

                if (input.Equals("A"))
                {
                    Console.WriteLine("The mobster attacks!");
                    this.health -= player.strength;
                }
                else if(input.Equals("B")) {   
                    Console.WriteLine(player.charName + " used their special ability!");
                    player.CombatSpecial(this);
                }
                else {
                    Console.WriteLine(player.charName + " used their " + player.inventory[0]);
                    if (player.charName.Equals("Jill"))
                    {
                        player.strength /= 2;
                        player.strength *= 5;
                        this.strength /= 2;
                        Console.WriteLine("Jill brandishes her katana, scaring the opponent!");
                        Console.WriteLine("Jill's strength increased massively! (twice as much, actually)");
                        player.DisplayStrength();
                    }
                    else
                    {
                        if (player.health <= 100) {
                            player.health = player.HEALTH_MAX;
                            Console.WriteLine("Ricky takes a bite of his awesome medium well burger.");
                            Console.WriteLine("Ricky is feeling better than ever! (with overheal)");
                                }
                        else { Console.WriteLine("Ricky is full"); }
                    }
                }
                player.health -= this.strength;
            }
            if (this.health <= 0) { 
                return true;
            } else { return false; }
        }
        internal class Mage : Enemy
        {
            public Mage()
            {
                this.HEALTH_MAX = 50;
                this.health = 50;
                this.strength = 30;
            }
        }
        internal class Boss : Enemy
        {
            public Boss()
            {
                this.HEALTH_MAX = 100;
                this.health = 100;
                this.strength = 25;
            }
            public bool Combat(Character player)
            {
                if(player.inventory.Count > 2){
                    Console.WriteLine("You remember you have the Apollo's Leaf!");
                    Console.WriteLine($"{player.charName}: \"Take this!\"");
                    this.health /= 2;
                }
                while (this.health > 0 && player.health > 0)
                {
                    Console.WriteLine($"You have {player.health} hp. The Don has {this.health} hp.");
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("A. Attack.");
                    Console.WriteLine("B. Special Ability.");
                    Console.WriteLine("C. Use item.");
                    string input = Choices.Number(3);

                    if (input.Equals("A"))
                    {
                        Console.WriteLine("The Don attacks!");
                        this.health -= player.strength;
                        player.health -= this.strength;
                    }
                    else if (input.Equals("B"))
                    {
                        Console.WriteLine(player.charName + " used their special ability!");
                        player.CombatSpecial(this);
                        this.health -= player.strength;
                        player.health -= this.strength;
                    }
                    else
                    {
                        Console.WriteLine(player.charName + " used their " + player.inventory[0]);
                        if (player.charName.Equals("Jill"))
                        {
                            player.strength /= 2;
                            player.strength *= 5;
                            Console.WriteLine("Jill's strength increased massively! (twice as much, actually)");
                            player.DisplayStrength();
                            player.health -= this.strength;
                        }
                        else
                        {
                            if (player.health <= 100)
                            {
                                player.health = player.HEALTH_MAX;
                                Console.WriteLine("Ricky is feeling better than ever! (with overheal)");
                            }
                            else { Console.WriteLine("Ricky is full"); }
                            player.health -= this.strength;
                        }
                    }
                }
                if (this.health <= 0)
                {
                    return true;
                }
                else { return false; }
            }
        }

    }


}
