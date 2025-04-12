using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private string _name;
        private int _health;
        private List<Item> _inventory;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Player(string name, int health, List<string> inventory):base(name, health)
        {
            _name = name;
            _health = health;
            _inventory = inventory;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
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

        /// <summary>
        /// This method gives the player an item into their inventory and clears the room's loot.
        /// </summary>
        public void PickUpItem(string item, Room room)
        {
            Console.WriteLine($"You pick up the {item}.");
            room.Loot.Remove(item);
            Inventory.Add(item);
            room.Loot.Clear();
        }

        /// <summary>
        /// This method returns the player healt as a string.
        /// </summary>
        public string CurrentStatus()
        {
            return ($"You are at {Health} health.");
        }

        /// <summary>
        /// This method returns the inventory list as a string.
        /// </summary>
        public string InventoryContents()
        {
            return ($"{Name}'s Inventory: {string.Join(", ", Inventory)}");
        }

        /// <summary>
        /// This method sets the player name.
        /// </summary>
        public void SetName()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        throw new ArgumentNullException(nameof(username));
                    }
                    Name = username;
                    Console.WriteLine($"Username set to {username}.");
                    Console.WriteLine("Character successfuly created!\n");
                    // Exit loop on successful creation
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Username cannot be empty.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// This method gets user input for their choice.
        /// </summary>
        public string GetChoice(Dictionary<string, string> choices)
        {
            // Collect UserInput
            while (true)
            {
                foreach (KeyValuePair<string, string> choice in choices)
                {
                    Console.WriteLine($"\t[{choice.Key}] - {choice.Value}.");
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

        // No function as of yet.
        public void UseItem()
        {

            //
        }

        public void Attack(Player hostile, int damage)
        {
            //
        }
    }
}