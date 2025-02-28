using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        private List<string> _loot;

        public Room(string description, List<string> loot)
        {
            _description = description;
            _loot = loot;
        }
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
        public List<string> loot
        {
            get { return _loot; }
            set
            {
                _loot = value;
            }
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}