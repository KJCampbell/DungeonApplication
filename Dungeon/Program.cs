using System.Reflection;

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

            //Player Object creation


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
                //TODO select a random monster to inhabit the room
                Console.WriteLine("Here's a monster!");


                #region Gameplay Menu Loop
                //CNTRL +K+S to surround with region
                bool reload = false;
                do
                {
                    //Console.WriteLine("Inner" + ++innerCount);
                    //TODO Gameplay Menu
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
                            //TODO Combat
                            Console.WriteLine("ATTACK!");
                            break;
                        case ConsoleKey.R:
                            //TODO Attack of Opprotunity
                            Console.WriteLine("Run away!!");
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine("Player Info: ");
                            break;
                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine("Monster info: ");
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

                    #endregion
                } while (!reload && !exit); //If either exit or reload is true, the inner loop will exit.
                #endregion
                //TODO Check player life

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
                "1","2","3","4","5"
            };

            Random rand = new Random();

            int index = rand.Next(rooms.Length);




            string room = rooms[index];

            return room;

            //Refactoring is bullshit

        }//end GetRoom()









    }//end class
}//end namespace