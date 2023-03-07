using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DungeonLibrary;

namespace Dungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            #region Important Variables
            int score = 0;
            bool exit = false;
            bool reload = false;
            int damageDealt;
            #endregion
            //Testing character
            Weapon sword = new Weapon(8, 1, "Gladius", 10, false, WeaponType.Short_Sword);
            Player player = new("Test", 70, 5, 40, Race.Human, sword);

            //Thread.sleep
            #region Action Loop

            do
            {
                Monster monster = Monster.GetMonster();
                Console.WriteLine($"In this room {monster.Name}!");
                //Variables for building the HP display bar
                const int barFull = 100; //As a constant this will be used to ensure the bar printed remains the same size
                int barHP = 0; //Initialized at 0, this value will be used to count as the HP bar is built

                for (int i = 0; i < barFull; i++) //First HP bar to start the fight
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("_");
                    Console.ResetColor();
                }
                Console.WriteLine($"\n{monster.Name} HP");


                //CNTRL +K+S to surround with region
                reload = false;
                do
                {
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            damageDealt = Combat.DoBattle(player, monster);
                            Console.WriteLine($"{monster.Life} HP remaining");
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Combat rewards, inventory system. money health whatever
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                reload = true;
                                score++;
                                //TODO Utalize the score counter to determine when a boss fight will occur. 
                            }
                            else
                            {
                                Console.WriteLine(damageDealt + " Damage dealt");
                                #region Storage


                                double lifeCheck = monster.Life;//it needs to be a double for math and stuff, because it becomes a decimal I guess?????
                                #region Full Bar Build
                                //The idea is to build this in such a way that it could be a method.
                                //What is stopping it being a method in the Combat class? getting the damage number since it is random between a few values AND IN A METHOD.



                                //First is a calculation to find the current health of the monster as a percentage.
                                //Since each monster will have different health values, using that value directly would cause the HP bar to vary in length and that would look bad
                                //The equation is simple. (X % Y) = X percent of Y Doing this allows the bar to remain a consistent size and gives a relative reference number for the bar
                                //double perCheck = (lifeCheck % barFull); //This is the first half of the equation needed to keep the bar the same size
                                double perCheck = (monster.Life / (double)monster.MaxLife) * 100;
                                barHP = 0;
                                double greenCheck = perCheck;
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
                                double redCheck = perCheck;
                                while (barHP < perCheck)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("_");
                                    Console.ResetColor();
                                    barHP++;
                                }
                                Console.WriteLine($"\n{monster.Name} HP:");
                                Console.WriteLine("perCheck right after green equation: " + greenCheck);
                                Console.Write("perCheck right after red: " + redCheck);
                                #endregion
                                #endregion
                            }
                            break;


                        case ConsoleKey.R:
                            //TODO Attack of Opprotunity
                            Console.WriteLine("Run away!!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();//Formatting
                            reload = true;
                            break;


                        case ConsoleKey.X:
                            Console.Clear();
                            Console.WriteLine("Leaving..");
                            exit = true;
                            break;


                        default:
                            break;
                    }


                } while (!reload && !exit);

            } while (!exit);


                    #endregion

                }//end Main()
    }//end class
}//end namespace
