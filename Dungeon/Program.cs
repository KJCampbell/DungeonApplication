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
            #endregion

            //Important Variables for everything
            int score = 0;
            bool exit = false;
            int qNum = 0;
            int pPer = 0;
            int pRace = 0;
            int damageDealt; 
            string pName = "You";
            ConsoleKey userIntro;
            ConsoleKey fChoice;

            #region Player Creation

            Weapon sword = new Weapon(10, 1, "Gladius", 10, false, WeaponType.Short_Sword);
            Player player = new(pName, 70, 5, 40, Race.Human, sword);
            #endregion

            #region Intro/Character Creation
            //Initial greeting
            //Sorta snarky, kinda
            Console.WriteLine("???: Well well, whats this? A fresh soul here to challenge this place?");
            Console.WriteLine($"{player.Name}: ...");
            Console.WriteLine("???: Right right, you can't talk yet. I'll fix that right up for ya. You should be able to make a choice now. Do you see it?");
            qNum = 1;
            while (qNum < 8)
            {
                if (qNum == 1)
                {
                    Console.Write("Can you decide? Y/N: ");
                    userIntro = Console.ReadKey().Key;
                    switch (userIntro)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine("\n???: Good, lets move onto more important questions then.");
                            qNum = 2;
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("\n???: Huh? Alright. Then I guess you better leave.");
                            Console.Clear();
                            Console.WriteLine("Your journey ends here.");
                            qNum = 0;
                            break;
                        default:
                            Console.WriteLine("\n???: What was that? Can you give a clearer answer?");
                            break;
                    }
                }
                //Player selects personality
                else if (qNum == 2)
                {
                    Console.WriteLine("\n\nHearing you speak would make this easier, yes? So lets start with the basics. What kind of person are you?");
                    Console.WriteLine("1)Aggressive\n2)Quiet\n3)Confident");
                    string answer = Console.ReadLine();
                    pPer = int.Parse(answer);
                    switch (pPer)
                    {
                        case 1:
                            Console.WriteLine($"{player.Name}: Can we move along faster? I wanna get to fighting!");
                            Console.WriteLine("???: Yes yes, we will get there");
                            qNum = 3;
                            break;
                        case 2:
                            Console.WriteLine($"{player.Name}: Quiet, I guess.");
                            Console.WriteLine("???: Hmm? Did you answer? I think I heard you.");
                            qNum = 3;
                            break;
                        case 3:
                            Console.WriteLine($"{player.Name}: Confident, I've got this. Whats the next question?");
                            Console.WriteLine("???: Very good, I like that. Let's carry on.");
                            qNum = 3;
                            break;
                        default:
                            Console.WriteLine($"{player.Name}: *&*!@^&#%!(#&!#*");
                            Console.WriteLine("???: What?");
                            qNum = 2;
                            break;
                    }
                }
                //Player selects name
                else if (qNum == 3)
                {
                    Console.Write("\n\nWhat is your name? ");
                    player.Name = Console.ReadLine();
                    //Personality split
                    if (pPer == 1)
                    {
                        Console.WriteLine($"{player.Name}: I'm {player.Name}!");
                        Console.WriteLine($"???: Well then, got it {player.Name}.");
                        qNum = 4;
                    }
                    if (pPer == 2)
                    {
                        Console.WriteLine($"{player.Name}: I'm {player.Name}..");
                        Console.WriteLine($"???: {player.Name}? Did I hear right? You need to speak up.");
                        qNum = 4;
                    }
                    if (pPer == 3)
                    {
                        Console.WriteLine($"{player.Name}: I'm {player.Name}, perhaps you've heard of me before?");
                        Console.WriteLine($"???: {player.Name}? Doesn't ring any bells, but I'll be sure to remember it.");
                        qNum = 4;
                    }
                }
                //Player selects race
                else if (qNum == 4)
                {
                    Console.WriteLine("\n\nThis is the last question. What are you?");
                    Console.WriteLine("1)Human\n2)Elf\n3)Goblin\n4)Giant\n5)Dwarf\n6)Orc");
                    string answer = Console.ReadLine();
                    pRace = int.Parse(answer);
                    //Personality split
                    if (pPer == 1)
                    {
                        switch (pRace)
                        {
                            case 1:
                                player.PlayerRace = Race.Human;
                                break;

                            case 2:
                                player.PlayerRace = Race.Elf;
                                break;

                            case 3:
                                player.PlayerRace = Race.Goblin;
                                break;

                            case 4:
                                player.PlayerRace = Race.Giant;
                                break;

                            case 5:
                                player.PlayerRace = Race.Dwarf;
                                break;

                            case 6:
                                player.PlayerRace = Race.Orc;
                                break;

                            default:
                                break;
                        }
                        Console.WriteLine($"{player.Name}: I'm a {player.PlayerRace}. Isn't it obvious?");
                        Console.WriteLine($"???: Right right of course, sorry. But just about all mortal souls look the same. So I have to ask.");
                        qNum = 5;
                    }
                    if (pPer == 2)
                    {
                        switch (pRace)
                        {
                            case 1:
                                player.PlayerRace = Race.Human;
                                break;

                            case 2:
                                player.PlayerRace = Race.Elf;
                                break;

                            case 3:
                                player.PlayerRace = Race.Goblin;
                                break;

                            case 4:
                                player.PlayerRace = Race.Giant;
                                break;

                            case 5:
                                player.PlayerRace = Race.Dwarf;
                                break;

                            case 6:
                                player.PlayerRace = Race.Orc;
                                break;

                            default:
                                break;
                        }
                        Console.WriteLine($"{player.Name}: {player.PlayerRace}...");
                        Console.WriteLine($"???: Eh? Seriously, speak up louder!");
                        Console.WriteLine($"{player.Name}: {player.PlayerRace}!!");
                        Console.WriteLine($"???: Whoa whoa! {player.Name}, no need to shout, I've got it. {player.PlayerRace}.");
                        qNum = 5;
                    }
                    if (pPer == 3)
                    {
                        switch (pRace)
                        {
                            case 1:
                                player.PlayerRace = Race.Human;
                                break;

                            case 2:
                                player.PlayerRace = Race.Elf;
                                break;

                            case 3:
                                player.PlayerRace = Race.Goblin;
                                break;

                            case 4:
                                player.PlayerRace = Race.Giant;
                                break;

                            case 5:
                                player.PlayerRace = Race.Dwarf;
                                break;

                            case 6:
                                player.PlayerRace = Race.Orc;
                                break;

                            default:
                                break;
                        }
                        Console.WriteLine($"{player.Name}: I'm a {player.PlayerRace}.");
                        Console.WriteLine($"???: Ah yes, noted. Well then..");
                        qNum = 5;
                    }
                }
                else if (qNum == 5)
                {
                    Console.Write($"\n\nThat should be everything {player.Name} the {player.PlayerRace}. Are you ready to depart for your adventure? Y/N: ");
                    fChoice = Console.ReadKey().Key;
                    switch (fChoice)
                    {
                        case ConsoleKey.Y:
                            if (pPer == 1)
                            {
                                qNum = 10;
                            }
                            if (pPer == 2)
                            {
                                qNum = 10;
                            }
                            if (pPer == 3)
                            {
                                qNum = 10;
                            }
                            Console.WriteLine("\n\nGood Luck.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("\n\nHuh? You aren't? Guess we better start over then.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            qNum = 1;
                            break;
                        default:
                            break;
                    }

                }

            }


            #endregion

            #region Main Game Loop
            do
            {
                //Console.WriteLine("Outer" + ++outerCount);
                //TODO Generate a random room
                Console.WriteLine(Combat.GetRoom());
                Monster monster = Monster.GetMonster();
                //TODO MadLibs Room


                Console.WriteLine($"In this room {monster.Name}!");
                //Variables for building the HP display bar
                const int barFull = 100; //As a constant this will be used to ensure the bar printed remains the same size
                int barHP = 0; //Initialized at 0, this value will be used to count as the HP bar is built

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
                            damageDealt = Combat.DoBattle(player, monster);
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
                                Combat.PrintHP(monster);
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
                            Console.WriteLine($"Current Score: {score}");
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
            /*
             * BIG BRAIN MOVE
             * 
             * When given the option to swap equipment, compare stats side by side with a specialized ToString()
             * 
             * -> with white for no change
             * -> with green to indicate an increase in stats
             * -> with red to indicate a decrease in stats
             * 
             * Drop what you have and pick up this new {Item.Type}? Y/N 
             * 
             */

        }//end Main()

        //TODO use a room "treasure room" to spawn a chest with items rather than a monster. Maybe an switch checking specifically for the room's name?
        //A list of lists. The inner most lists would be a bunch of adjetives and the second list would hold those to be selected from.
        //What







    }//end class
}//end namespace