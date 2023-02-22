namespace DungeonLibrary
{
    public class Character
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
        private int Life
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
        private int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        private string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        private int Block
        {
            get { return _block; }
            set { _block = value; }
        }

        //Ctor - 1 fully qualified, 1 default/unqualified
        //Unqualified Ctor
        public Character() { }

        //Fully qualified Ctor
        public Character(int maxLife, int life, string name, int hitChance, int block)
        {
            //Assignment/Mapping (assignment)
            //Property = parameter
            //White = blue
            MaxLife = maxLife;
            Life = life;
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
                   $"Life: {Life}\n" +
                   $"Name: {Name}\n" +
                   $"HitChance: {HitChance}\n" +
                   $"Block: {Block}\n";
        }

        //CalcBlock() returns an int -> return Block;
        public int CalcBlock()
        {
            return Block;
        }

        //CalcHitChance() returns an int - return HitChance;
        public int CalcHitChance()
        {
            return HitChance;
        }

        //CalcDamage() returns an int -> return 0;
        public int CalcDamage()
        {
            return 0;
        }

    }//end class
}//end namespace