using DungeonLibrary;
using System.Reflection;
using System.Threading.Channels;

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

            string[] rooms =
            {
                "A stinky cave","A dusty library","TRAMPOLINE?!?!","Treasure room","I dunno"
            };

            Random rand = new Random();

            int index = rand.Next(rooms.Length);




            string room = rooms[index];

            return room;

            //Refactoring is bullshit

        }//end GetRoom()









    }//end class
}//end namespace