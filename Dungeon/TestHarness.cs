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
            //Build and test the functionality of our Library.
            //Build and test a weapon
            //Build and test a Character - test all methods


            Console.Write("Please provide a name: ");
            string givenName = Console.ReadLine();

            //Weapon test
            Console.WriteLine("============WEAPON SPAWN============");
            Weapon firstWeapon = new Weapon();
            firstWeapon.MaxDamage = 10;
            firstWeapon.MinDamage = 5;
            firstWeapon.Name = "Best Friend Sword";
            firstWeapon.BonusHitChance = 10;
            firstWeapon.IsTwoHanded = true;
            firstWeapon.WeaponClass = WeaponType.Long_Sword;



            Console.WriteLine(firstWeapon);
            Console.WriteLine();


            //Character test
            Console.WriteLine("============PLAYER SPAWN============");
            Player proto = new Player(givenName, 70, 15, 50, Race.Goblin, firstWeapon);
            Console.WriteLine();
            Console.WriteLine(proto);

            //armor and sheild
            //set up similar to weapon, make sheild unavailable when the weapon is twohanded



            //Use this stupid. Such a simple
            proto.PlayerRace = Race.Goblin;

            Console.WriteLine("Select the race you want to play as:\nHuman(1):\nELf(2):\nGoblin(3):\nGiant(4):\nDwarf(5):\nOrc(6):");
            string selRace = Console.ReadLine();
            switch (selRace)
            {
                case "1":
                    proto.PlayerRace = Race.Human;
                    break;
                case "2":
                    break;
                default:
                    break;

            }




            //Methods test
            Console.WriteLine("Testing Methods: \n" +
                $"Whats the block? {proto.CalcBlock()}\n" +
                $"What about DAMAGE? {proto.CalcDamage()}\n" +
                $"But how likely is it to hit? {proto.CalcHitChance()}");
            Console.WriteLine($"YOU DEAL {proto.CalcDamage()} DAMAGE!\n\n\n\n\n");


            //Monster test
            Console.WriteLine("============MONSTER SPAWN============");
            Console.WriteLine(Monster.GetMonster());
            Monster monster = Monster.GetMonster();
            Console.WriteLine("\n\n*****************************************COMBAT\n\n");




            //Variables for building the HP display bar
            const int barFull = 100; //As a constant this will be used to ensure the bar printed remains the same size
            int barHP = 0; //Initialized at 0, this value will be used to count as the HP bar is built

            for (int i = 0; i < barFull; i++) //A basic build to establish size
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("_");
                Console.ResetColor();
            }
            Console.WriteLine($"\n{monster.Name} HP");


            double lifeCheck = monster.Life;//it needs to be a double for math and stuff, because it becomes a decimal I guess?????
            Console.Write("Press A to attack: ");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            switch (userChoice)
            {
                case ConsoleKey.A:
                    //This is the makeshift damage calculation
                    int dmg = new Random().Next(1, 26); //This placeholder represents where I would put the damage roll. IF I COULD GET TO IT
                    lifeCheck = lifeCheck - dmg;
                    break;
            }
            Console.WriteLine();

            #region Full Bar Build
            //The idea is to build this in such a way that it could be a method.
            //What is stopping it being a method in the Combat class? getting the damage number since it is random between a few values AND IN A METHOD.



            //First is a calculation to find the current health of the monster as a percentage.
            //Since each monster will have different health values, using that value directly would cause the HP bar to vary in length and that would look bad
            //The equation is simple. (X % Y) = X percent of Y Doing this allows the bar to remain a consistent size and gives a relative reference number for the bar
            double perCheck = (lifeCheck % barFull); //This is the first half of the equation needed to keep the bar the same size
            do//This loop prints Green
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("_");
                Console.ResetColor();
                barHP++;
            } while (barHP < perCheck);
            barHP = 0; //This sets the looping value back to 0 for the red portion
            perCheck = barFull - perCheck; //This finds the left over value that needs to be red
            do//This loop prints Red
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("_");
                Console.ResetColor();
                barHP++;
            } while (barHP < perCheck);

            #endregion
            //Means of implimenting HP bar. Could go into the Combat warehouse of methods. Printed during the DoBattle method to show the monster's hp after the player attacks it
            //Everything works as is, all that is needed is somehow applying the exact damage roll from the combat method to the equation

            /*
             * public damage roll calcdamage
             *get block chance
             *get hit chance
             *randomize damage
             *
             *damageroll dr = new damageroll(10,72)
             *return dr;
             * 
             * 
             * public class damage roll
             *  public int damage  get set
             *  public int random number get set
             * 
             */



        }//end Main()
    }//end class
}//end namespace
