using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields
        int _minDamage;
        int _maxDamage;
        //Properties
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Describe { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > _maxDamage)
                {
                    _minDamage = _maxDamage;
                }
                else
                {
                    _minDamage = value;
                }
            }
        }

        //Constructors
        public Monster(int maxLife, string name, int hitChance, int block, int maxDamage, int minDamage, string describe) : base(maxLife, name, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Describe = describe;

        }

        //Methods
        public override int CalcDamage()
        {
            //Create a Random object
            Random rand = new Random();
            //determine the damage
            int damage = rand.Next(MinDamage, MaxDamage + 1);
            //return the damage
            return damage;
        }
        public override string ToString()
        {
            return $"A {Name} is {Describe}.\n"+
                $"{Name} has the following stats:\nMinDamage: {MinDamage}\nMaxDamage: {MaxDamage}\nLife: {MaxLife}\nHit Chance: {HitChance}\nBlock: {Block}";
        }
    }
}
