using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class TestingGround
    {
        static void Main(string[] args)
        {
            string[] template = new string[6];
            Console.Write("Something something something: ");
            ConsoleKey detox = Console.ReadKey(true).Key;

            //using a random number for detox here, a set of values can be assigned to the template string.
            switch (detox)
            {
                case ConsoleKey.A:
                    //Moist theme
                    template[0] = " flooded";
                    template[1] = "damp";
                    template[2] = "waterlogged";
                    template[3] = "soaked";
                    template[4] = "filthy";
                    template[5] = "moist";
                    break;

                case ConsoleKey.S:
                    //Dusty theme
                    template[0] = " dirty";
                    template[1] = "creaking";
                    template[2] = "worn out";
                    template[3] = "ragged";
                    template[4] = "filthy";
                    template[5] = "shredded";
                    break;

                case ConsoleKey.D:
                    //Blazing theme
                    template[0] = "n enflamed";
                    template[1] = "charred";
                    template[2] = "ash covered";
                    template[3] = "seared";
                    template[4] = "burnt";
                    template[5] = "crispy";
                    break;

                case ConsoleKey.F:
                    //Weird theme
                    template[0] = " warped";
                    template[1] = "upside down";
                    template[2] = "distorted";
                    template[3] = "ragged";
                    template[4] = "filthy";
                    template[5] = "shredded";
                    break;

                case ConsoleKey.G:
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

            //Dungeon is not done
            Console.WriteLine($"\n\nDungeon Template:\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} library lies beyond the {template[1]} door. \nFilled with old {template[2]} shelves with a variety of {template[3]} books, some laying strewn about the floor.\nIn the middle of the {template[4]} mess something stirs! Coming out from under a pile of {template[5]} books!");

            //Arena is done
            Console.WriteLine($"\n\nArena Template:\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} arena cascades out past the {template[1]} door.\nWide and vast the {template[1]} battleground with a variety of {template[3]} equipment laying about a variety of corpses.\nAcross the {template[4]} battleground another {template[1]} door begins to open! From the darkness a monster approaches, it's {template[5]} cloak falls away reveling itself!");

            //Library is done
            Console.WriteLine($"\n\nLibrary Template:\nA {template[1]} door blocks your path, pushing past it you enter the next room!\nA{template[0]} library lies beyond the {template[1]} door. \nFilled with old {template[2]} shelves with a variety of {template[3]} books, some laying strewn about the floor.\nIn the middle of the {template[4]} mess something stirs! Coming out from under a pile of {template[5]} books!");
























            ////Generate lists containing descriptive words to fill in the template
            //List<string> dustyRoom = new List<string>() { "C", "C++" };
            //List<string> moistRoom = new List<string>() { "Java", "C#" };

            ////Puts all the descriptive lists into one big list of lists
            //List<List<string>> listOfLists = new List<List<string>>() { dustyRoom, moistRoom };


            //string[] templates =
            //{
            //    $"A {0} library lies beyond the {1} door. Filled with old {2} shelves with a variety of {3} books, some laying strewn about the floor. In the middle of the {4} mess something stirs! Coming out from under a pile of {5} books!",

            //};


            ////foreach (var list in listOfLists)
            ////{
            ////    Console.WriteLine(String.Join(", ", list));
            ////}
        }






    }
}
