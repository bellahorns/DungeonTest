using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTest
{
    internal class Rooms
    {
        static Random rand = new Random();

        public static string getRoomType()
        {
            switch (rand.Next(0, 5))
            {
                case 0:
                    return "Cells";
                case 1:
                    return "Vampire Nest";
                case 2:
                    return "Armoury";
                case 3:
                    return "Witch's Lair";
                case 4:
                    return "Library";
                default:
                    return "Office";
            }
        }

        public static bool halfChance()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return false;
            }

        }

        public static string getRoomDescription(string roomType)
        {
            switch (roomType)
            {
                case "Cells":
                    return "Looking around you see iron bars lining the edges of the room, and deep scratches up the wall. Oh... these are empty prison cells!";
                case "Vampire Nest":
                    return "Coffins!? Ten coffins are in this room, it's dark and smells of damp. You know what this is, it's a vampire nest!";
                case "Armoury":
                    return "This room is filled with empty armour stands and empty weapon wracks. This was an armoury once!";
                case "Witch's Lair":
                    return "This room reaks! It's filled with dusty jars and books... not books... grimoires! This is a witch's lair!";
                case "Library":
                    return "Shelves and shelves of dusty damages books. You pick one up, but it's in a language you cannot understand. This is a library";
                default:
                    return "A desk stands in the middle of the room, but not much else. Was this an office?";
            }
        }

        public static void roomActions()
        {
            string roomType = getRoomType();
            bool isMonster = halfChance();
            bool isPotion = halfChance();
            Console.WriteLine("You enter next the room and look around.");
            Console.WriteLine(getRoomDescription(roomType));
            if (isMonster == true)
                Console.WriteLine("There is a shadow in the corner of the room.");

            Console.ReadKey();
            Console.Clear();

            if (isPotion == true)
                puckUpPotion();

            if (isMonster == true)
            {
                Console.WriteLine("The shadow in the corner starts to move. You tense.");
                Encounters.BasicEncounter();
            }
            else if (Program.currentPlayer.roomCount < 5)
            {
                Console.WriteLine("You have done everything you can in this room, you go through the next door.");
                Console.ReadKey();
                Console.Clear();
            }
            else
                Console.WriteLine("You open the next door in this room. Sunlight! You have escaped!.");
        }
        public static void puckUpPotion()
        {
            Console.WriteLine("You spot a health potion in the room!");
            Console.WriteLine("Do you pick it up?");
            Console.WriteLine("-------------------------");
            Console.WriteLine("|   (Y)es      (N)o     |");
            Console.WriteLine("-------------------------");
            string move = Console.ReadLine();
            if (move.ToLower() == "y")
            {
                Console.WriteLine("You pick up the potion.");
                Program.currentPlayer.potions += 1;
                Console.WriteLine("You now have " + Program.currentPlayer.potions + " potions.");
            }
            else if (move.ToLower() == "n")
            {
                Console.WriteLine("You leave the potion where it is.");
            }
            else
            {
                Console.WriteLine("You leave the potion where it is.");
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
}
