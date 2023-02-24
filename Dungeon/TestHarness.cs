using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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





            //Weapon test
            Weapon firstWeapon = new Weapon();
            firstWeapon.MaxDamage = 10;
            firstWeapon.MinDamage = 5;
            firstWeapon.Name = "Best Friend Sword";
            firstWeapon.BonusHitChance = 10;
            firstWeapon.IsTwoHanded = true;
            firstWeapon.WeaponClass = WeaponType.Long_Sword;//input the Weapon Class

           

            Console.WriteLine(firstWeapon);

            Console.WriteLine();



            //Character test
            Player proto = new Player(50, "Proto", 70, 15,Race.Goblin,firstWeapon);
            Console.WriteLine();
            Console.WriteLine(proto);
            //Methods test
            Console.WriteLine("Testing Methods: \n" +
                $"Whats the block? {proto.CalcBlock()}\n" +
                $"What about DAMAGE? {proto.CalcDamage()}\n" +
                $"But how likely is it to hit? {proto.CalcHitChance()}");
            Console.WriteLine($"YOU DEAL {proto.CalcDamage()} DAMAGE!\n\n\n\n\n");


            //Monster test
            Monster bat = new Monster(20, "Bat", 20, 2, 4, 2, "a small flappy= rat");
            Console.WriteLine(bat);
        }//end Main()
    }//end class
}//end namespace
