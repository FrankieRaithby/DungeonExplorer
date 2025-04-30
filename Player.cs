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
        private Room _currentRoom;
        private Inventory _inventory;
        private Attire _attire;
        private int _score;


        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Player(string name, string description, int health, Room currentRoom) : base(name, description, health, currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _inventory = new Inventory(new List<Item>(), 150);
            _attire = new Attire(null, null, null, null);
            _currentRoom = currentRoom;
            _score = 0;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>
        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public Attire Attire
        {
            get { return _attire; }
            set { _attire = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Inventory GetInventory()
        {
            return Inventory;
        }
        public Attire GetAttire()
        {
            return Attire;
        }
        public int GetScore()
        {
            return _score;
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

        public void EnterRoom(Room room)
        {
            // Check if the room is valid
            if (room != null)
            {
                _currentRoom = room;
                Console.WriteLine($"You have entered {room.GetName()}.");
                Console.WriteLine($"Description: {room.GetDescription()}");
                room.SetDiscovered(true);
            }
            else
            {
                Console.WriteLine("Invalid room.");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"\n\t{GetName()}");
            Console.WriteLine($"\t{GetDescription()}");
            Console.WriteLine("\t--------------");
            Console.WriteLine($"\tHealth: {GetHealth()}");
            Console.WriteLine($"\tScore: {GetScore()}");
            Attire.DisplayAttire();
        }

        /// <summary>
        /// This method gets user input for their choice.
        /// </summary>
        public string GetChoice(Dictionary<string, string> choices)
        {
            Console.WriteLine("\n");
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


        public void Damage()
        {

        }

        public override void Attack(Creature target)
        {
            if (target is Monster monster)
            {
                Console.WriteLine($"{Name} attacks {monster.GetName()}!");
                // Implement attack logic here
                // For example, reduce monster's health
                monster.Health -= 10; // Example damage value
                Console.WriteLine($"{monster.GetName()} now has {monster.Health} health left.");
            }
            else
            {
                Console.WriteLine("Target is not a valid monster.");
            }
        }






    }
}