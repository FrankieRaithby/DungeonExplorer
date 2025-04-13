using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Weapon : Item
    {
        private int _damage;
        private string _attack;
        private int _durability;

        public Weapon(string name, string description, int damage, string attack, int durability) : base(name, description)
        {
            _damage = damage;
            _attack = attack;
            _durability = durability;
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public string Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }

        

        public override void UseItem()
        {
            Console.WriteLine($"Using weapon: {Name}, Damage: {Damage}, Durability: {Durability}");
        }
    }
}
