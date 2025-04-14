using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> _items;
        private int _maxWeight;
        private int _currentWeight;

        public Inventory(List<Item> items, int maxWeight)
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
        public int MaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }
        public int CurrentWeight
        {
            get { return _currentWeight; }
            set { _currentWeight = value; }
        }

        public List<Item> GetItems()
        {
            return Items;
        }

        public int GetMaxWeight()
        {
            return MaxWeight;
        }

        public int GetCurrentWeight()
        {
            return CurrentWeight;
        }


        public void AddItem(Item item)
        {
            if (item.GetWeight() + CurrentWeight <= MaxWeight)
            {
                Items.Add(item);
                CurrentWeight += item.GetWeight();
            }
            else
            {
                Console.WriteLine("Cannot add item. Inventory weight limit exceeded.");
            }
        }

        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
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

        private int CalculateCurrentWeight()
        {
            return Items.Sum(item => item.Weight);
        }

    }
}