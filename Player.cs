using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private string _name;
        private string _description;
        private int _health;
        private Inventory _inventory;
        private int _currentRoom;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Player(string name, string description, int health, Inventory inventory, Room currentRoom) : base(name, description, health, currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _inventory = inventory;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>


        public void Damage()
        {

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
    }
}