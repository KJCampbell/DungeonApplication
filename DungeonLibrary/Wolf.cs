using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    internal class Wolf : Monster
    {
        public int CritChance { get; set; }
        public int CritBonus { get; set; }

        public Wolf(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string describe, bool twoStage, int critChance, int critBonus) :
            base(name, hitChance, block, maxLife, maxDamage, minDamage, describe, twoStage)
        {
            CritChance = critChance;
            CritBonus = critBonus;

        }
        public Wolf()
        {
            MaxLife = 20;
            Life = MaxLife;
            MaxDamage = 8;
            MinDamage = 3;
            HitChance = 40;
            Block = 15;
            Name = "Wolf Pup";
            Describe = "It would be cute if it wasnt so mean";
            TwoStage = false;
            CritChance = 15;
            CritBonus = 5;

        }//end default ctor
        public override string ToString()
        {
            return string.Format("{0}\n{1}% chance it will land a critical strike and deal {2} bonus damage.",base.ToString(), CritChance, CritBonus);
        }

        public override int CalcDamage()
        {
            int Bonus = CritBonus;
            int Min = MinDamage;
            int Max = MaxDamage;
            Random chance = new Random();
            int percent = chance.Next(101);
            if (percent <= CritChance)
            {
                Min += Bonus;
                Max += Bonus;
            }
            //Create a Random object
            Random rand = new Random();
            //determine the damage
            int damage = rand.Next(Min, Max + 1);
            //return the damage
            return damage;
        }

    }
}
