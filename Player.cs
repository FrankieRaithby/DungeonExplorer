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
        public string GetChoice(Dictionary<string, string> additionalChoices)
        {
            // Predefined choices
            Dictionary<string, string> choices = new Dictionary<string, string>
            {
                { "A", "View Inventory" },
                { "B", "View Current Status" },
                { "C", "Inspect Room" }
            };

            // Merge dictionaries
            foreach (var choice in additionalChoices)
            {
                choices[choice.Key] = choice.Value;
            }

            // Collect UserInput
            while (true)
            {
                Console.WriteLine("\n");
                foreach (KeyValuePair<string, string> choice in choices)
                {
                    Console.WriteLine($"[{choice.Key}] - {choice.Value}.");
                }
                
                string UserInput = Console.ReadLine().Trim().ToUpper();

                // Check UserInput is a dictionary key
                if (choices.ContainsKey(UserInput))
                {
                    return UserInput;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please pick from the list.");
                }
            }
        }
    }
}