using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Private Fields
        private string _name;
        private int _health;
        private List<string> _inventory;

        // Parameterized Constructor

        public Player(string name, int health, List<string> inventory) 
        {
            _name = name;
            _health = health;
            _inventory = inventory;
        }

        // Public properties for accessing private fields
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Name cannot be empty.");
                else
                    _name = value; 
            }
        }
        public int Health
        {
            get { return _health; }
            set 
            {
                if (value < 0)
                    Console.WriteLine("Health cannot be negative.");
                else
                    _health = value; 
            }
        }
        public List<string> Inventory
        {
            get { return _inventory; }
            set
            {
                    _inventory = value;
            }
        }
        public void PickUpItem(string item)
        {
            Inventory.Add(item);
        }
        public string CurrentStatus()
        {
            return ($"You are at {Health} health.");
        }
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
        public string GetChoice(string[] choices)
        {
            while (true)
            {
                Console.WriteLine("\n[A] to view inventory.");
                Console.WriteLine("[B] to view current status.");
                foreach (string choice in choices)
                {
                    Console.WriteLine(choice);
                }
                return Console.ReadLine().Trim().ToLower();
            }
        }
    }
}