using System;
using System.Collections.Generic;

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
        private bool discovered;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Room(string name, string description, int x, int y, List<Item> loot)
        {
            _name = name;
            _description = description;
            _x = x;
            _y = y;
            _loot = loot;
            discovered = false;
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

        public bool GetDiscovered()
        {
            return discovered;
        }

        public void SetDiscovered(bool value)
        {
            discovered = value;
        }



        /// <summary>
        /// This method returns true if room has loot, false if not.
        /// </summary>
        public bool HasLoot()
        {
            if (Loot.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}