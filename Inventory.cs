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
            Console.WriteLine("INVENTORY");
            Console.WriteLine("---------");
            Console.WriteLine($"{GetCurrentWeight()} / {GetMaxWeight()} Kg");
            foreach (var item in Items)
            {
                Console.WriteLine($"\t- {item.GetName()} ({item.GetWeight()} Kg)");
            }
            Console.WriteLine($"Total Weight: {CurrentWeight}/{MaxWeight}");
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

        public void RemoveItem(Item item, Room room)
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

        

        private int CalculateCurrentWeight()
        {
            return Items.Sum(item => item.Weight);
        }

    }
}