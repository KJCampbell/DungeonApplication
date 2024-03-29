﻿namespace DungeonLibrary
{
    //"Abstract" denotes an "incomplete" class or method.
    //This tells the program that we will not create any Character objects directly. It is a starting point
    public abstract class Character
    {
        //Fields

        /*
         * int life (cannot be more than maxlife)
         * int maxlife (assign first in ctor)
         * string name
         * int hit chance
         * int block
         */
        int _life;
        int _maxLife;
        string _name;
        int _hitChance;
        int _block;

        //Properties - 1 for each field
        public int Life
        {
            get { return _life; }
            set
            {
                if (value > _maxLife)
                {
                    _life = _maxLife;
                }
                else
                {
                    _life = value;
                }
            }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }

        //Ctor - 1 fully qualified, 1 default/unqualified
        //Unqualified Ctor
        public Character() { }

        //Fully qualified Ctor
        public Character(string name, int hitChance, int block, int maxLife)
        {
            //Assignment/Mapping (assignment)
            //Property = parameter
            //White = blue
            MaxLife = maxLife;
            Life = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
        }

        //Methods
        //ToString() overrride
        public override string ToString()
        {
            //Don't want that basic stuff. ITS CUSTOM TIME
            //return base.ToString();

            return $"MaxLife: {MaxLife}\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Name: {Name}\n" +
                   $"HitChance: {HitChance}\n" +
                   $"Block: {Block}\n";
        }

        //CalcBlock() returns an int -> return Block;
        public virtual int CalcBlock()
        {
            return Block;
        }

        //CalcHitChance() returns an int - return HitChance;
        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        //CalcDamage() returns an int -> return 0;
        public abstract int CalcDamage();//an abstract just says somewhere down the line, one of the child classes MUST impliment this with some functionality.

    }//end class
}//end namespace