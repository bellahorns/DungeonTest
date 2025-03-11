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
        static Ranndom rand = new Ranndom();
        public static string getRoomType()
        {
            switch (rand.Next(0, 5))
            {
                case 0:
                    return "Cells";
                    break;
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

        public string roomType = getRoomType();
        public bool isMonster = halfChance();
        public bool isPotion = halfChance();

        //static string getRoomDescription(roomType)
        //{
        //    switch roomType
        //    { 
        //        case ""
        //    }
        //}

        static void roomActions(roomType, isMonster, isPotion)
        {
            Console.WriteLine(roomType);
            Console.WriteLine(isMonster);
            Console.WriteLine(isPotion);

        }
    }
}