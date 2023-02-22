using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Public again
    public class Weapon
    {
        //Fields
        /*
         * int for min damage (cannot be less than 0 or > max)
         * int for max damage (cannot be less than 0) - assign first in ctor
         * string for the name
         * int for bonusHitChance
         * bool isTwoHanded
         * 
         */
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _weaponClass;


        //Properties - 1 for each field
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
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public WeaponType WeaponClass
        { 
            get { return _weaponClass; }
            set { _weaponClass = value; }
        }


        //Constructors
        //1 fully qualified ctor, and 1 unqualified
        //Unqualified ctor First
        public Weapon() { }//Default

        //Qualified ctor, ready for its job
        public Weapon(int maxDamage, int minDamage, string name, int bonusHitChance, bool isTwoHanded, WeaponType weaponClass)
        {
            //Assignment/Mapping (assignment)
            //Property = parameter
            //White = blue
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            WeaponClass = weaponClass;
        }


        //Methods
        //Nicely formatted ToString() override
        public override string ToString()
        {
            //return base.ToString();
            return $"Max Damage: {MaxDamage}\n" +
                $"Min Damage: {MinDamage}\n" +
                $"Name: {Name}\n" +
                $"Bonus Hit Chance: {BonusHitChance}\n"+
                $"Two Handed: {IsTwoHanded}\n"+
                $"Weapon Class: {WeaponClass}";
        }//end ToString()




    }//end class
}//end namespace
