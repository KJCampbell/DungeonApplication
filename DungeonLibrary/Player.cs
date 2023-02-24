using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Fields - none

        //Properties
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }


        //Constructors
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon) : base (name, hitChance, block, maxLife)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            #region Potentail Expansion - Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Human:
                    //BASIC
                    break;
                case Race.Elf:
                    //TODO figure out initive or somethin?
                    break;
                case Race.Goblin:
                    HitChance += 5;
                    break;
                case Race.Giant:
                    MaxLife += 10;
                    //TODO Ask how to possibly override twohanded boolean so that almost all weapons count as one handed for giant//excluding bows and such
                    break;
                case Race.Dwarf:
                    MaxLife += 15;
                    //TODO damage resistances/types??? ask if possible with an efficient boolean check?
                    break;
                case Race.Orc:
                    MaxLife += 20;
                    //TODO Figure out some kind of damage boost?
                    break;
                default:
                    break;
            }
            #endregion

        }
        //Methods
        public override string ToString()
        {
            //create a string, switch on Player Race and
            //write some description about that race.
            return base.ToString() + $"\nWeapon:\n{EquippedWeapon}\n" +
                $"Description: {PlayerRace}";
        }

        public override int CalcDamage()
        {
            //Create a Random object
            Random rand = new Random();
            //determine the damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //return the damage
            return damage;
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
    }
}
