using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is not a datatype class, so it will not have fields/props/contor.
        //It will simply serve as a "warehouse" for a variety of combat-related methods.

        public static int DoAttack(Character attacker, Character defender)
        {
            int damageDealt = 0;
            //get a random number from 1-100; determines hit
            int roll = new Random().Next(1, 101);
            Thread.Sleep(200);
            //The attacker "hits" if the roll is less than or equal to the attacker's hitchance - defender's block
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calc damage
                damageDealt = attacker.CalcDamage();

                //assign that damage to the defender's life
                defender.Life -= damageDealt;
                //output result
                //Foreground color is text color
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }
            else //if missed
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
            return damageDealt;
        }//end do attack

        public static int DoBattle(Player player, Monster monster)
        {
            int damageDealt = 0;
            damageDealt = DoAttack(player, monster);
            //If monster survives it gets to attack
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
            return damageDealt;

        }

        public static void PrintHP(Monster monster)
        {
            //Variables for building the HP display bar
            const int barFull = 100; //As a constant this will be used to ensure the bar printed remains the same size
            int barHP; //Initialized at 0, this value will be used to count as the HP bar is built

            #region Full Bar Build
            //The idea is to build this in such a way that it could be a method.
            //What is stopping it being a method in the Combat class? getting the damage number since it is random between a few values AND IN A METHOD.



            //First is a calculation to find the current health of the monster as a percentage.
            //Since each monster will have different health values, using that value directly would cause the HP bar to vary in length and that would look bad
            //The equation is simple. (X / Y) = X percent of Y Doing this allows the bar to remain a consistent size and gives a relative reference number for the bar
            double perCheck = (monster.Life / (double)monster.MaxLife) * 100; //Equation for the dang thing
            barHP = 0;
            if (perCheck == 0)
            {
                perCheck = 100;
            }
            do//This loop prints Green
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("_");
                Console.ResetColor();
                barHP++;
            } while (barHP < perCheck);
            barHP = 0; //This sets the looping value back to 0 for the red portion
            perCheck = barFull - perCheck; //This finds the left over value that needs to be red
            while (barHP < perCheck)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("_");
                Console.ResetColor();
                barHP++;
            }
            Console.WriteLine($"\n{monster.Name} HP:");
            #endregion
        }

        public static string GetRoom()
        {
            string[] template = new string[6];

            //using a random number for themed here, a set of values can be assigned to the template string.
            Random th = new Random();
            int themed = th.Next(1, 6);
            switch (themed)
            {
                case 1:
                    //Moist theme
                    template[0] = " flooded";
                    template[1] = "damp";
                    template[2] = "waterlogged";
                    template[3] = "soaked";
                    template[4] = "filthy";
                    template[5] = "moist";
                    break;

                case 2:
                    //Dusty theme
                    template[0] = " dirty";
                    template[1] = "creaking";
                    template[2] = "worn out";
                    template[3] = "ragged";
                    template[4] = "filthy";
                    template[5] = "shredded";
                    break;

                case 3:
                    //Blazing theme
                    template[0] = "n enflamed";
                    template[1] = "charred";
                    template[2] = "ash covered";
                    template[3] = "seared";
                    template[4] = "burnt";
                    template[5] = "crispy";
                    break;

                case 4:
                    //Weird theme
                    template[0] = " warped";
                    template[1] = "upside down";
                    template[2] = "distorted";
                    template[3] = "ragged";
                    template[4] = "filthy";
                    template[5] = "twisted";
                    break;

                case 5:
                    //Spooky theme
                    template[0] = " dirty";
                    template[1] = "decrepid";
                    template[2] = "worn out";
                    template[3] = "ragged";
                    template[4] = "filthy";
                    template[5] = "shredded";
                    break;

                default:
                    //Placeholders 
                    template[0] = " General room descriptor";
                    template[1] = "Door descriptor";
                    template[2] = "Objects in room";
                    template[3] = "Placeholder";
                    template[4] = "Placeholder";
                    template[5] = "Placeholder";
                    break;
            }

            string[] rooms =
            {
                //Dungeon string NOT FULLY CHECKED
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} dungeon can be found beyond the {template[1]} door. \nLines of {template[2]} cells some empty and some with old {template[3]} skeletons left behind the bars. Near the end of the line, a larger cell door creaks open.\nFrom inside that final {template[4]} cell something emerges! Coming out to fight, adorned with a {template[5]} prisoner's rags!",

                //Arena string FULLY CHECKED! GOOD TO GO
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} arena cascades out past the {template[1]} door.\nWide and vast the {template[1]} battleground with a variety of {template[3]} equipment laying about a variety of corpses.\nAcross the {template[4]} battleground another {template[1]} door begins to open! From the darkness a monster approaches, it's {template[5]} cloak falls away reveling itself!",
                
                //Library string FULLY CHECKED! GOOD TO GO
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} library lies beyond the {template[1]} door. \nFilled with old {template[2]} shelves with a variety of {template[3]} books, some laying strewn about the floor.\nIn the middle of the {template[4]} mess something stirs! Coming out from under a pile of {template[5]} books!"
            };

            //This here randomized which room template is drawn from
            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;

            //Refactoring is bullshit

        }//end GetRoom()

    }
}
