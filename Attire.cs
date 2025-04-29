using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Attire
    {
        private int _defence;
        private Armour _helmet;
        private Armour _chestplate;
        private Armour _leggings;
        private Armour _boots;

        public Attire(Armour helmet, Armour chestplate, Armour leggings, Armour boots)
        {
            _helmet = helmet;
            _chestplate = chestplate;
            _leggings = leggings;
            _boots = boots;
            _defence = CalculateDefence();
        }
        public Armour Helmet
        {
            get { return _helmet; }
            set { _helmet = value; }
        }
        public Armour Chestplate
        {
            get { return _chestplate; }
            set { _chestplate = value; }
        }
        public Armour Leggings
        {
            get { return _leggings; }
            set { _leggings = value; }
        }
        public Armour Boots
        {
            get { return _boots; }
            set { _boots = value; }
        }

        public Armour GetHelmet()
        {
            return Helmet;
        }
        public Armour GetChestplate()
        {
            return Chestplate;
        }
        public Armour GetLeggings()
        {
            return Leggings;
        }
        public Armour GetBoots()
        {
            return Boots;
        }


        public void EquipArmour(Armour armour)
        {
            string variant = armour.GetVariant();

            switch(variant)
            {
                case "Helmet":
                    Helmet = armour;
                    break;
                case "Chestplate":
                    Chestplate = armour;
                    break;
                case "Leggings":
                    Leggings = armour;
                    break;
                case "Boots":
                    Boots = armour;
                    break;
                default:
                    Console.WriteLine("Invalid armour variant.");
                    break;
            }
        }

        public void UnequipArmour(string variant)
        {
            switch (variant)
            {
                case "Helmet":
                    Helmet = null;
                    break;
                case "Chestplate":
                    Chestplate = null;
                    break;
                case "Leggings":
                    Leggings = null;
                    break;
                case "Boots":
                    Boots = null;
                    break;
                default:
                    Console.WriteLine("Invalid armour variant.");
                    break;
            }
        }

        public List<Armour> GetArmours(List<Item> items)
        {
            return items.OfType<Armour>().ToList();
        }
        private int CalculateDefence()
        {
            List<Armour> EquipedArmour = new List<Armour> { Helmet, Chestplate, Leggings, Boots };
            return EquipedArmour.Where(a => a != null).Sum(a => a.Defence);
        }


        public void DisplayAttire()
        {
            Console.WriteLine("\n\tEQUIPED ARMOUR");
            Console.WriteLine("\t--------------");
            Console.WriteLine($"\tHelmet: {(Helmet != null ? $"{Helmet.GetName()} ({Helmet.GetDefence()} DEF)" : "None")}");
            Console.WriteLine($"\tChestplate: {(Chestplate != null ? $"{Chestplate.GetName()} ({Chestplate.GetDefence()} DEF)" : "None")}");
            Console.WriteLine($"\tLeggings: {(Leggings != null ? $"{Leggings.GetName()} ({Leggings.GetDefence()} DEF)" : "None")}");
            Console.WriteLine($"\tBoots: {(Boots != null ? $"{Boots.GetName()} ({Boots.GetDefence()} DEF)" : "None")}");
            Console.WriteLine($"\tTotal Defence: {CalculateDefence()}");
        }

    }
}
