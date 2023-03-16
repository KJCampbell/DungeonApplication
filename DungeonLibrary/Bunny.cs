using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    internal class Bunny : Monster
    {
        public int RunAwayChance { get; set; }
        public int BlockBonus { get; set; }

        public Bunny(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string describe, bool twoStage, int runAwayChance, int blockBonus) :
            base(name, hitChance, block, maxLife, maxDamage, minDamage, describe, twoStage)
        {
            RunAwayChance = runAwayChance;
            BlockBonus = blockBonus;

        }
        public Bunny()
        {
            MaxLife = 15;
            Life = MaxLife;
            MaxDamage = 4;
            MinDamage = 1;
            HitChance = 40;
            Block = 10;
            Name = "Itty Bitty Bunny";
            Describe = "Its small but fierce";
            TwoStage = false;
            RunAwayChance = 15;
            BlockBonus = 10;

        }//end default ctor
        public override string ToString()
        {
            return string.Format("{0}\n{1}% chance it will focus on dodging.", base.ToString(), RunAwayChance, BlockBonus);
        }

        public override int CalcBlock()
        {
            Random chance = new Random();
            int percent = chance.Next(101);
            if (percent <= RunAwayChance)
            {
                Block += BlockBonus;
            }
            return Block;
        }
    }
}
