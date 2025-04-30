using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private string _name;
        private string _description;
        private int _x;
        private int _y;
        private List<Item> _loot;
        private List<Monster> _monsters;
        private bool _discovered;
        private int _puzzle;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Room(string name, string description, int x, int y, List<Item> loot, List<Monster> monsters, int puzzle)
        {
            _name = name;
            _description = description;
            _x = x;
            _y = y;
            _loot = loot;
            _monsters = monsters;
            _discovered = false;
            _puzzle = puzzle;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Description cannot be empty.");
                else
                    _description = value;
            }
        }
        public List<Item> Loot
        {
            get { return _loot; }
            set
            {
                _loot = value;
            }
        }

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


        public int Puzzle
        {
            get { return _puzzle; }
            set
            {
                _puzzle = value;
            }
        }

        public List<Monster> Monsters
        {
            get { return _monsters; }
            set
            {
                _monsters = value;
            }
        }

        public bool Discovered
        {
            get { return _discovered; }
            set { _discovered = value;}
        }

        public string GetName()
        {
            return Name;
        }


        /// <summary>
        /// This method returns room's loot.
        /// </summary>
        public string GetLoot()
        {
            return string.Join(", ", Loot);
        }

        /// <summary>
        /// This method returns room's description.
        /// </summary>
        public string GetDescription()
        {
            return Description;
        }



        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }



        public List<Monster> GetMonsters()
        {
            return Monsters;
        }

        public bool GetDiscovered()
        {
            return _discovered;
        }

        public void SetDiscovered(bool value)
        {
            Discovered = value;
        }

        public string IfDiscovered()
        {
            if (GetDiscovered() == false)
            {
                return "Unknown";
            }
            else
            {
                return "Discovered";
            }
        }

        public Item GetItemByName(string name)
        {
            return Loot.FirstOrDefault(item => item.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// This method returns true if room has loot, false if not.
        /// </summary>
        public bool HasLoot()
        {
            if (Loot.Count == 0)
            {
                Console.WriteLine("\tThere is nothing to scavenge in this room.");
                return false;
            }
            else
            {
                Console.WriteLine("\tYou have found some loot in this room!");
                return true;
            }
        }

        public int GetPuzzle()
        {
            return Puzzle;
        }

        public void SetPuzzle(int puzzle)
        {
            Puzzle = puzzle;
        }

        public bool HasMonsters()
        {
            if (GetMonsters().Count == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\tYou are not alone in this room...");
                return true;
            }
        }

        public Monster GetMonsterByName(string name)
        {
            return Monsters.FirstOrDefault(monster => monster.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}