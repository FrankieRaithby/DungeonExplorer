using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private string _description;
        private List<string> _loot;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Room(string description, List<string> loot)
        {
            _description = description;
            _loot = loot;
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
        public List<string> Loot
        {
            get { return _loot; }
            set
            {
                _loot = value;
            }
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