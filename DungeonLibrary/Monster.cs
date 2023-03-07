using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields
        int _minDamage;
        int _maxDamage;
        //Revive condition for potential bosses and zombie
        bool twoStage;
        //Properties
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Describe { get; set; } = null!;
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
        public bool TwoStage 
        {
            get { return twoStage; }
            set { twoStage = value; }
        }
        //Constructors
        public Monster()
        {

        }//empty ctor for children
        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string describe, bool twoStage) : base(name, hitChance, block, maxLife)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Describe = describe;
            TwoStage = twoStage;

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
            return $"A {Name}!\n" +
                $"{Name} has the following stats:\nDamage: {MinDamage} to {MaxDamage}\nLife: {MaxLife}\nHit Chance: {HitChance}\nBlock: {Block}\nDescription: {Describe}";
        }

        //This makes it so that its called from the class
        public static Monster GetMonster()
        {
            //Create a variety of monsters
            Wolf m1 = new Wolf();
            Bunny m2 = new Bunny();
            Zombie m3 = new Zombie();
            Monster m4 = new(name: "Smaug", hitChance: 65, block: 20, maxLife: 20, maxDamage: 15, minDamage: 1, describe: "The last great dragon.", false);
            Monster m5 = new("Practice Dummy", 30, 30, 100, 10, 1, "Its just some practice dummy, you can practice your swing on it! The thing shouldn't be able to fight back.", false);

            List<Monster> monsters = new()
            {
                m1,m1,m1,m1,
                m2,m2,m2,m2,
                m3,m3,m3,
                m4,
                m5,
            };
            //Pick one at random to place in our dungeon room
            return monsters[new Random().Next(monsters.Count)];
        }


    }
}
