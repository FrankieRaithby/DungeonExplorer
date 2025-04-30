using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        private int _damage;
        private string _attack;
        private int _durability;

        public Weapon(string name, string description, int weight, int damage, string attack, int durability) : base(name, description, weight)
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

        public int GetDamage()
        {
            return Damage;
        }

        public void GetWeaponInfo()
        {
            Console.WriteLine($"Weapon Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Attack Type: {Attack}");
            Console.WriteLine($"Durability: {Durability}");
            Console.WriteLine("------------------------------");
        }


        public override void UseItem(Player player)
        {
            Console.WriteLine($"Using weapon: {Name}, Damage: {Damage}, Durability: {Durability}");
        }
    }
}
