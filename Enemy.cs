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
            //Battle Text
            player.strength = player.strength_default;
            while (this.health > 0 && player.health > 0) {
                Console.WriteLine($"You have {player.health} hp. The enemy has {this.health} hp.");
                Console.WriteLine("What will you do?");
                Console.WriteLine("A. Attack.");
                Console.WriteLine("B. Special Ability.");
                Console.WriteLine("C. Use item.");
                string input = Sselection(3);

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
                        //Jill parry text
                        player.strength /= 2;
                        player.strength *= 5;
                        this.strength /= 2;
                        Console.WriteLine("Jill brandishes her katana, scaring the opponent!");
                        Console.WriteLine("Jill's strength increased massively! (twice as much, actually)");
                        player.DisplayStrength();
                    }
                    else
                    {
                        //Ricky burger text
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
        public static string Sselection(int optionNum)
        {
            string input = "";
            string options = "ABCD";
            while (!options.Substring(0, optionNum).Contains(input) || input.Length == 0 || input.Length != 1)
            {
                input = Console.ReadLine();
                input = input.ToUpper().Trim();
            }
            return input;
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
                //Apollo's Leaf text
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
                    string input = Sselection(3);

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
