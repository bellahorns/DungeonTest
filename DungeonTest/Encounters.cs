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
        //Encounter Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You charge towards your captor, grabbing a rusty sword");
            Console.WriteLine("He turns...");
            Console.ReadKey();
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
                Console.WriteLine("-------------------------");
                Console.WriteLine("|  (A)ttack    (D)efend  |");
                Console.WriteLine("|  (R)un       (H)eal    |");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
            }
        }
    }
}
