using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
        public string Describe { get; set; } = null!;
        private int MinDamage
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
        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string describe) : base(name, hitChance, block, maxLife)
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
            return $"A {Name}!\n" +
                $"{Name} has the following stats:\nDamage: {MinDamage} to {MaxDamage}\nLife: {MaxLife}\nHit Chance: {HitChance}\nBlock: {Block}\nDescription: {Describe}";
        }

        //THis makes it so that its called from the class
        public static Monster GetMonster()
        {
            //Create a variety of monsters
            Monster m1 = new(name: "White Rabbit", hitChance: 50, block: 20, maxLife: 25, maxDamage: 8, minDamage: 2, describe: "Thats no ordinary rabbit! Look at those bones!");
            Monster m2 = new(name: "Dracula", hitChance: 70, block: 8, maxLife: 30, maxDamage: 8, minDamage: 1, describe: "Father of all the undead");
            Monster m3 = new(name: "Mikey", hitChance: 50, block: 10, maxLife: 25, maxDamage: 4, minDamage: 1, describe: "No longer a teenager, but he is still a mutant turtle.");
            Monster m4 = new(name: "Smaug", hitChance: 65, block: 20, maxLife: 20, maxDamage: 15, minDamage: 1, describe: "The last great dragon.");


            List<Monster> monsters = new()
            {
                m1,m1,
                m2,m2,m2,m2,
                m3,m3,m3,
                m4,
            };
            //Pick one at random to place in our dungeon room
            return monsters[new Random().Next(monsters.Count)];
        }
        
    }
}
