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

        public void DisplaySpareArmour(Player player)
        {
            DisplayAttire();
            Console.WriteLine("\n\tSpare Armour");
            Console.WriteLine("\t------------");
            foreach (Armour item in player.Inventory.GetArmours())
            {
                Console.WriteLine($"\t- {item.GetName()} ({item.GetDefence()} DEF) ({item.GetWeight()} Kg) ({item.GetDurability()}%)");
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

            foreach (Armour item in player.Inventory.GetArmours())
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
                            if (Helmet != null)
                            {
                                Console.WriteLine($"\tYou already have a helmet equipped. Unequip it first.");
                                return;
                            }
                            Helmet = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Chestplate":
                            if (Chestplate != null)
                            {
                                Console.WriteLine($"\tYou already have a chestplate equipped. Unequip it first.");
                                return;
                            }
                            Chestplate = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Leggings":
                            if (Leggings != null)
                            {
                                Console.WriteLine($"\tYou already have leggings equipped. Unequip it first.");
                                return;
                            }
                            Leggings = selectedItem;
                            selectedItem.DeleteItem(player);
                            break;
                        case "Boots":
                            if (Boots != null)
                            {
                                Console.WriteLine($"\tYou already have boots equipped. Unequip it first.");
                                return;
                            }
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
                            if (Helmet == null)
                            {
                                Console.WriteLine($"\tYou don't have a helmet equipped.");
                                return;
                            }
                            Helmet = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Chestplate":
                            if (Chestplate == null)
                            {
                                Console.WriteLine($"\tYou don't have a chestplate equipped.");
                                return;
                            }
                            Chestplate = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Leggings":
                            if (Leggings == null)
                            {
                                Console.WriteLine($"\tYou don't have leggings equipped.");
                                return;
                            }
                            Leggings = null;
                            player.Inventory.Items.Add(selectedItem);
                            break;
                        case "Boots":
                            Boots = null;
                            if (Boots == null)
                            {
                                Console.WriteLine($"\tYou don't have boots equipped.");
                                return;
                            }
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
            Console.WriteLine($"\tHelmet: {(Helmet != null ? $"{Helmet.GetName()} ({Helmet.GetDefence()} DEF) ({Helmet.GetDurability()}%)" : "None")}");
            Console.WriteLine($"\tChestplate: {(Chestplate != null ? $"{Chestplate.GetName()} ({Chestplate.GetDefence()} DEF) ({Chestplate.GetDurability()}%)" : "None")}");
            Console.WriteLine($"\tLeggings: {(Leggings != null ? $"{Leggings.GetName()} ({Leggings.GetDefence()} DEF) ({Leggings.GetDurability()}%)" : "None")}");
            Console.WriteLine($"\tBoots: {(Boots != null ? $"{Boots.GetName()} ({Boots.GetDefence()} DEF) ({Boots.GetDurability()}%)" : "None")}");
            Console.WriteLine($"\tTotal Defence: {CalculateDefence()}");
        }

    }
}
