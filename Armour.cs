using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Armour : Item, IDurability
    {
        private string _variant;
        private int _defence;
        private int _durability;
        
        public Armour(string name, string description, int weight, string type, int defence, int durability) : base(name, description, weight)
        {
            _variant = type; // Helmet, Chestplate, Leggings, Boots
            _defence = defence;
            _durability = durability;
        }

        public string Variant
        {
            get { return _variant; }
            set { _variant = value; }
        }

        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }
        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }

        public string GetVariant()
        {
            return Variant;
        }
        public int GetDefence()
        {
            return Defence;
        }
        public int GetDurability()
        {
            return Durability;
        }

        public override void UseItem(Player player)
        {
            Console.WriteLine($"\tCan only use armour on attire menu.");
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
