using DungeonLibrary;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Title/Introduction
            Console.Title = "Dungeon of Doom";
            Console.WriteLine("Welcome to the Dungeon");
            #endregion


            #region Player Creation
            //TODO Score Variable
            int score = 0;
            //TODO Weapon creation
            //Possible expansion - Display a list of pre-created weapons and let them pick one or pick one randomly
            Weapon sword = new Weapon(8, 1, "Gladius", 10, false, WeaponType.Short_Sword);
            //Player Object creation
            //Potential expansion - allow them to enter their own name
            //show them possible races and let them pick one.
            Player player = new("Muffin", 70, 5, 40, Race.Human, sword);
            #endregion

            #region Main Game Loop
            bool exit = false;
            //int innerCount = 0;
            //int outerCount = 0;
            do
            {
                //Console.WriteLine("Outer" + ++outerCount);
                //TODO Generate a random room
                Console.WriteLine(GetRoom());
                Monster monster = Monster.GetMonster();
                //TODO MadLibs Room
                //Use a list/array to generate "themes" for rooms and a "generic" room description.


                Console.WriteLine($"In this room {monster.Name}!");


                #region Gameplay Menu Loop 
                //CNTRL +K+S to surround with region
                bool reload = false;
                do
                {
                    //Console.WriteLine("Inner" + ++innerCount);
                    //Gameplay Menu
                    #region Menu
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Combat
                            //Potential Expansion : weapon/race bonus attack
                            //IDEAS IDEAS
                            Combat.DoBattle(player, monster);
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
                            break;
                        case ConsoleKey.R:
                            //TODO Attack of Opprotunity
                            Console.WriteLine("Run away!!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();//Formatting
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine("Monster info: ");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            //reload = true;
                            break;


                        default:
                            break;
                    }//end menu switch
                    //TODO Check player life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Death calls. You picked up the phone.\a");
                        exit = true;
                    }

                    #endregion
                } while (!reload && !exit); //If either exit or reload is true, the inner loop will exit.
                #endregion
            } while (!exit); //If exit is true, the outer loop is exit as well.

            //Show the score
            Console.WriteLine("You defeated " + score + " monster"+ 
                (score == 1 ? "." : "s."));

            #endregion


        }//end Main()

        private static string GetRoom()
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
                    template[5] = "shredded";
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
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} library lies beyond the {template[1]} door. \nFilled with old {template[2]} shelves with a variety of {template[3]} books, some laying strewn about the floor.\nIn the middle of the {template[4]} mess something stirs! Coming out from under a pile of {template[5]} books!",

                //Arena string FULLY CHECKED! GOOD TO GO
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} arena cascades out past the {template[1]} door.\nWide and vast the {template[1]} battleground with a variety of {template[3]} equipment laying about a variety of corpses.\nAcross the {template[4]} battleground another {template[1]} door begins to open! From the darkness a monster approaches, it's {template[5]} cloak falls away reveling itself!",
                
                //Library string FULLY CHECKED! GOOD TO GO
                $"\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} library lies beyond the {template[1]} door. \nFilled with old {template[2]} shelves with a variety of {template[3]} books, some laying strewn about the floor.\nIn the middle of the {template[4]} mess something stirs! Coming out from under a pile of {template[5]} books!",
                
                "Treasure room",
                
                "I dunno"
            };

            //This here randomized which room template is drawn from
            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;

            //Refactoring is bullshit

        }//end GetRoom()

        //TODO use a room "treasure room" to spawn a chest with items rather than a monster. Maybe an switch checking specifically for the room's name?
        //A list of lists. The inner most lists would be a bunch of adjetives and the second list would hold those to be selected from







    }//end class
}//end namespace