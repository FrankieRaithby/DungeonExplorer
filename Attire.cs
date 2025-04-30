using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
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
        public int GetDefence()
        {
            return Defence;
        }

        public void DisplaySpareArmour()
        {
            Console.WriteLine("\n\tSpare Armour");
            Console.WriteLine("\t------------");
            foreach (var item in GetArmours())
            {
                Console.WriteLine($"\t- {item.GetName()} ({item.GetDefence()} DEF) ({item.GetWeight()} Kg)");
            }
        }

        public void EquipArmour(Player player)
        {
            if (player.Inventory.GetArmours().Count == 0)
            {
                Console.WriteLine("No armour to pick up.");
                return;
            }

            Dictionary<string, string> armourChoices = new Dictionary<string, string>();
            int i = 0;

            foreach (Item item in player.Inventory.GetArmours())
            {
                string letter = ((char)('A' + i)).ToString();
                armourChoices[letter] = item.GetName();
                i++;
            }

            Console.WriteLine("\tEquip an armour:");

            string ChosenItem = player.GetChoice(armourChoices);

            if (armourChoices.ContainsKey(ChosenItem))
            {
                Armour selectedItem = player.Inventory.GetItem(armourChoices[ChosenItem]) as Armour;
                if (selectedItem is Armour)
                {
                    string variant = selectedItem.GetVariant();

                    switch (variant)
                    {
                        case "Helmet":
                            Helmet = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Chestplate":
                            Chestplate = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Leggings":
                            Leggings = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Boots":
                            Boots = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        default:
                            Console.WriteLine("Invalid armour variant.");
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void UnequipArmour(Player player)
        {
            if (player.Attire.GetArmours().Count == 0)
            {
                Console.WriteLine("No armour to unequip.");
                return;
            }

            Dictionary<string, string> armourChoices = new Dictionary<string, string>();
            int i = 0;

            foreach (Armour item in player.Attire.GetArmours())
            {
                string letter = ((char)('A' + i)).ToString();
                armourChoices[letter] = item.GetName();
                i++;
            }

            Console.WriteLine("\tUnequip an armour:");

            string ChosenItem = player.GetChoice(armourChoices);

            if (armourChoices.ContainsKey(ChosenItem))
            {
                Armour selectedItem = GetArmourByname(armourChoices[ChosenItem]);
                if (selectedItem is Armour)
                {
                    string variant = selectedItem.GetVariant();

                    switch (variant)
                    {
                        case "Helmet":
                            Helmet = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Chestplate":
                            Chestplate = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Leggings":
                            Leggings = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Boots":
                            Boots = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        default:
                            Console.WriteLine("Invalid armour variant.");
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public List<Armour> GetArmours()
        {
            List<Armour> equipedArmours = new List<Armour>();
            if (Helmet != null)
            {
                equipedArmours.Add(Helmet);
            }
            if (Chestplate != null)
            {
                equipedArmours.Add(Chestplate);
            }
            if (Leggings != null)
            {
                equipedArmours.Add(Leggings);
            }
            if (Boots != null)
            {
                equipedArmours.Add(Boots);
            }
            return equipedArmours;
        }
        public Armour GetArmourByname(string name)
        {
            return GetArmours().FirstOrDefault(armour => armour.Name == name);
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
