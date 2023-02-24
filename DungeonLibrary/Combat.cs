using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is not a datatype class, so it will not have fields/props/contor.
        //It will simply serve as a "warehouse" for a variety of combat-related methods.

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100; determines hit
            int roll = new Random().Next(1, 101);
            Thread.Sleep(200);
            //The attacker "hits" if the roll is less than or equal to the attacker's hitchance - defender's block
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calc damage
                int damageDealt = attacker.CalcDamage();

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
        }//end do attack

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            //If monster survives it gets to attack
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }

        }




    }
}
