using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTest
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            bool victory = false;
            while (currentPlayer.health > 0 && victory == false)
            {
                Start();
                Encounters.FirstEncounter();
                Story();
                Console.ReadKey();
                Console.Clear();
                while (currentPlayer.roomCount <= 5 && currentPlayer.health > 0)
                {
                    Rooms.roomActions();
                    currentPlayer.roomCount += 1;
                }
                if (currentPlayer.roomCount == 6 && currentPlayer.health > 0)
                    victory = true;
            }

            if (victory == true)
            {
                Console.WriteLine("You win");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You died");
                Console.ReadKey();
            }
        }

        static void Start() 
        {
            Console.WriteLine("Welcome to the Dungeon!");
            Console.WriteLine("Name:");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have woken up in the first room of the dungeon.");
            if (currentPlayer.name == "")
                Console.WriteLine("You can't even remeber your name");
            else
                Console.WriteLine("You can only remember that your name is "+currentPlayer.name);
            Console.ReadKey();
            Console.WriteLine("You feel around in the darkness and find a door. You quietly open it and go through.");
            Console.WriteLine("You see your captor in the next room, facing away from you.");
        }

        static void Story()
        {
            Console.Clear();
            Console.WriteLine("With your captor dead on the floor you deside to go through his pockets.");
            Console.WriteLine("There isn't much, but you find a crumpled up peice of paper in his pocket.");
            Console.WriteLine("It looks like... a map! There are 5 rooms till the exit. It's time to start your escape...");
            Console.WriteLine("You go through the next door.");
        }

    }
}
