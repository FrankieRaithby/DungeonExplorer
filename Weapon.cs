using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Weapon : Item, IDurability
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
            Console.WriteLine($"\tWeapon Name: {Name}");
            Console.WriteLine($"\tDescription: {Description}");
            Console.WriteLine($"\tWeight: {Weight} kg");
            Console.WriteLine($"\tDamage: {Damage}");
            Console.WriteLine($"\tAttack Type: {Attack}");
            Console.WriteLine($"\tDurability: {Durability}");
            Console.WriteLine("\t------------------------------");
        }


        public override void UseItem(Player player)
        {
            Console.WriteLine($"\tCan only use weapon on monsters.");
        }

        public void DecreaseDurability(int damage)
        {
            if (Durability > 0)
            {
                Durability -= damage;
                Console.WriteLine($"\t{Name} durability decreased to {Durability}.");
            }
            else
            {
                Console.WriteLine($"\t{Name} is broken and cannot be used.");
            }
        }
    }
}
