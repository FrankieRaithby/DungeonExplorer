using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player
    {
        // Private Fields
        private string _name;
        public int _health { get; private set; }

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

        public List<string> Inventory
        {
            get { return _inventory; }
            set
            {
                    _inventory = value;
            }
        }
        public void PickUpItem(string item, Room room)
        {
            Console.WriteLine($"You pick up the {item}.");
            room.Loot.Remove(item);
            Inventory.Add(item);
        }
        public string CurrentStatus()
        {
            return ($"You are at {_health} health.");
        }
        public string InventoryContents()
        {
            return ($"{Name}'s Inventory: {string.Join(", ", Inventory)}");
        }
        public string GetChoice(Dictionary<string, string> choices)
        {
            // Collect UserInput
            while (true)
            {
                foreach (KeyValuePair<string, string> choice in choices)
                {
                    Console.WriteLine($"[{choice.Key}] - {choice.Value}.");
                }
                
                string UserInput = Console.ReadLine().Trim().ToUpper();

                // Check UserInput is a dictionary key
                if (choices.ContainsKey(UserInput))
                {
                    //Console.WriteLine($"{Name} has chosen [{UserInput}] - {choices[UserInput]}.");
                    return UserInput;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please pick from the list");
                }
            }
        }
        public void UseItem()
        {

            //
        }

        public void Damage(int damage)
        {
            //
        }
    }
}