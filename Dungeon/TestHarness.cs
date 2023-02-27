using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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





            //Weapon test
            Console.WriteLine("============WEAPON SPAWN============");
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
            Console.WriteLine("============PLAYER SPAWN============");
            Player proto = new Player("Proto", 70, 15, 50, Race.Goblin, firstWeapon);
            Console.WriteLine();
            Console.WriteLine(proto);
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


        

            /*
             * public damage roll calcdamage
             *get block chance
             *hit chance
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
