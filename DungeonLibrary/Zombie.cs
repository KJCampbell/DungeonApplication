using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Zombie : Monster
    {
        public int Revive { get; set; }
        public Zombie(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string describe, bool twoStage, int revive) : base(name, hitChance, block, maxLife, maxDamage, minDamage, describe, twoStage)
        {
            Revive = revive;

        }
        public Zombie()
        {
            MaxLife = 20;
            Life = MaxLife;
            MaxDamage = 8;
            MinDamage = 3;
            HitChance = 40;
            Block = 15;
            Name = "Mostly Decayed Zombie";
            Describe = "It would probably fall apart if you left it alone";
            TwoStage = true;
            Revive = 30;

        }//end default ctor
        public override string ToString()
        {
            return string.Format("{0}\n{1}% chance it will come back to life after reaching 0 Health.", base.ToString(), Revive);
        }

    }
}
