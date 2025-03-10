using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTest
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
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

    }
}
