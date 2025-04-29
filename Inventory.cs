using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> _items;
        private float _maxWeight;
        private float _currentWeight;

        public Inventory(List<Item> items, float maxWeight)
        {
            _items = items;
            _maxWeight = maxWeight;
            _currentWeight = CalculateCurrentWeight();
        }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public float MaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }
        public float CurrentWeight
        {
            get { return _currentWeight; }
            set { _currentWeight = value; }
        }

        public List<Item> GetItems()
        {
            return Items;
        }

        public float GetMaxWeight()
        {
            return MaxWeight;
        }

        public float GetCurrentWeight()
        {
            return CurrentWeight;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n\tINVENTORY");
            Console.WriteLine("\t---------");
            Console.WriteLine($"\t{GetCurrentWeight()} / {GetMaxWeight()} kg");
            SortItemsByAscendingWeight();
            foreach (var item in Items)
            {
                Console.WriteLine($"\t- {item.GetName()} ({item.GetWeight()} Kg)");
            }
        }

        public void AddItem(Item item, Room room)
        {
            if (item.GetWeight() + CurrentWeight <= MaxWeight)
            {
                room.Loot.Remove(item);
                Items.Add(item);
                CurrentWeight += item.GetWeight();
            }
            else
            {
                Console.WriteLine("Cannot add item. Inventory weight limit exceeded.");
            }
        }

        public void DropItemMenu(Player player)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();

            int i = 0;
            foreach (Item item in player.Inventory.GetItems())
            {
                char letter = (char)('A' + i);
                items[letter.ToString()] = item.GetName();
                i++;
            }

            Console.WriteLine("\tDrop an item:");

            string ItemChosen = player.GetChoice(items);

            if (items.ContainsKey(ItemChosen))
            {
                player.Inventory.DropItem(player.Inventory.GetItem(ItemChosen), player.GetCurrentRoom());
                Testing.CheckItem(player, player.Inventory.GetItem(ItemChosen));
            }
        }

        public void UseItemMenu(Player player)
        {
            Dictionary<string, string> useItems = new Dictionary<string, string>();

            int j = 0;
            foreach (Item item in player.GetInventory().GetItems())
            {
                char letter = (char)('A' + j);
                useItems[letter.ToString()] = item.GetName();
                j++;
            }

            Console.WriteLine("\tUse an item:");

            string ItemUsed = player.GetChoice(useItems);

            if (useItems.ContainsKey(ItemUsed))
            {
                player.GetInventory().GetItem(ItemUsed).UseItem();
                Testing.CheckItem(player, player.GetInventory().GetItem(ItemUsed));
            }
        }

        public void DropItem(Item item, Room room)
        {
            if (Items.Contains(item))
            {
                room.Loot.Add(item);
                Items.Remove(item);
                CurrentWeight -= item.GetWeight();
            }
            else
            {
                Console.WriteLine("Cannot remove item. Item not in inventory.");
            }
        }

        public bool ItemExists(string name)
        {
            return Items.Exists(item => item.Name == name);
        }
        public Item GetItem(string name)
        {
            return Items.FirstOrDefault(item => item.Name == name);
        }

        public void SortItemsByAscendingWeight()
        {
            Items = Items.OrderBy(item => item.Weight).ToList();
        }



        private int CalculateCurrentWeight()
        {
            return Items.Sum(item => item.Weight);
        }

    }
}