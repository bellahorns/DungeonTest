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
        //Encounter Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("This room is lit. You spot a rusty sword and pick it up.");
            Console.WriteLine("Your captor hears you and turns!");
            Console.WriteLine("You are now fighting a human rouge.");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Human Rouge", 1, 4);
        }


        //Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0) 
            {
                Console.Clear();
                Console.WriteLine("Potions: " + Program.currentPlayer.potions);
                Console.WriteLine("Health: " + Program.currentPlayer.health);
                Console.WriteLine(n + ": " + h);
                Console.WriteLine("-------------------------");
                Console.WriteLine("|  (A)ttack    (D)efend  |");
                Console.WriteLine("|  (R)un       (H)eal    |");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Make your move! Enter A, D, R, or H:");
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
                else if (move.ToLower() == "r")
                {
                    //run
                    Console.WriteLine("You try to escape!");
                    if (rand.Next(0, 2) == 0)
                    {
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("As you sprint away from the " + n + ", it grabs your arm and stops your escape!");
                        Console.WriteLine("You lose " + damage + " health, and are unable to escape.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You run from the " + n + " and you successfully escape!");
                        Console.WriteLine("You enter the next room.");
                        //allow player to enter next room
                        Console.ReadKey();
                    }

                }
                else if (move.ToLower() == "h")
                {
                    //heal
                    Console.WriteLine("You try to escape!");
                    if (Program.currentPlayer.potions==0)
                    {
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You reach for your potions, but find you do not have any left! You are unable to heal yourself.");
                        Console.WriteLine("While you were distracted, the " + n + "attacks! You lose " + damage + "health.");
                    }
                    else
                    {
                        Console.WriteLine("You grab a potion from your bag, drinking it as fast as you can.");
                        int potionValue = 5;
                        if (potionValue + Program.currentPlayer.health > 10)
                            potionValue = 5 - (potionValue + Program.currentPlayer.health - 10);
                        else
                            potionValue = 5;
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
        }
    }
}
