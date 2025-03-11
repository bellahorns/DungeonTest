using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTest
{
    internal class Encounters
    {
        static Random rand = new Random();
        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("This room is lit. You spot a rusty sword and pick it up.");
            Console.WriteLine("Your captor hears you and turns!");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Human Rouge", "Sword", 4);
        }
        public static void BasicEncounter()
        {
            Console.WriteLine("You have been spotted and have no choice but to fight!");
            Combat(true, "", "", 0);
        }


        //Encounter Tools
        public static void Combat(bool random, string name, string weapon, int health)
        {
            string n = "";
            string w = "";
            int p = 0;
            int h = 0;
            
            //Define the name, health, and weapon of a random monster
            if (random)
            {
                n = GetName();
                h = rand.Next(1, 8);
                w = GetWeapon();
            }
            //Define the name, health, and weapon of a pre determined monster
            else
            {
                n = name;
                h = health;
                w = weapon;
            }

            //Define the power of a monster, based on the weapon
            switch (w)
            {
                case "Sword":
                    p=2;
                    break;
                case "Dagger":
                    p=1;
                    break;
                case "Hammer":
                    p = 2;
                    break;
                case "Rapier":
                    p = 3;
                    break;
                default:
                    p = 2;
                    break;

            }


            Console.WriteLine("You are now fighting a " + n + ".");
            Console.WriteLine("They wield a " + w + " that has a weapon value of " + p + ".");
            Console.ReadKey();
            while (h > 0  && Program.currentPlayer.health > 0) 
            {
                Console.Clear();
                Console.WriteLine("Potions: " + Program.currentPlayer.potions);
                Console.WriteLine("Health: " + Program.currentPlayer.health);
                Console.WriteLine(n + ": " + h);
                Console.WriteLine("-------------------------");
                Console.WriteLine("|  (A)ttack    (D)efend  |");
                Console.WriteLine("|  (H)eal                |");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Make your move! Enter A, D, or H:");
                string move = Console.ReadLine();
                if (move.ToLower() == "a")
                {
                    //attack
                    Console.WriteLine("You attack your enemy!");
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue+1) + rand.Next(1,4);
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("The " + n + " loses " + attack + " health, but serves you " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (move.ToLower() == "d")
                {
                    //defend
                    Console.WriteLine("You defend yourself against your enemy!");
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue + 1);
                    int damage = p/4 - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You only lose " + damage + " health, and manage to serve " + damage + " damage to the " + n + ".");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (move.ToLower() == "h")
                {
                    //heal
                    if (Program.currentPlayer.potions==0)
                    {
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You reach for your potions, but find you do not have any left! You are unable to heal yourself.");
                        Program.currentPlayer.health -= damage;
                        Console.WriteLine("While you were distracted, the " + n + "attacks! You lose " + damage + "health.");
                    }
                    else
                    {
                        Console.WriteLine("You grab a potion from your bag, drinking it as fast as you can.");
                        int potionValue = 5;
                        if (potionValue + Program.currentPlayer.health > 10)
                            potionValue = potionValue - (potionValue + Program.currentPlayer.health - 10);
  
                        Program.currentPlayer.health += potionValue;
                        Program.currentPlayer.potions -= 1;
                        Console.WriteLine("You gain " + potionValue + " health.");


                    }
                }
                else
                {
                    //ask again
                    Console.WriteLine("That is not a valid move. The " + n + "looks at you confused.");
                    Console.WriteLine("Please try again.");
                }
                Console.ReadKey();

            }
            Console.Clear();
            if (Program.currentPlayer.health <= 0)
                Console.WriteLine(n + " deals a fatel blow and everything goes dark.");
            else
            {
                Console.WriteLine("You have killed the " + n + ".");
                Console.ReadKey();
            }
        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Vampire";
                case 1:
                    return "Troll";
                case 2:
                    return "Witch";
                case 3:
                    return "Cyclopes";
                default:
                    return "Human Rouge";

            }
        }
        
        public static string GetWeapon()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Sword";
                case 1:
                    return "Dagger";
                case 2:
                    return "Hammer";
                case 3:
                    return "Rapier";
                default:
                    return "Spear";

            }
        }

    }
}
