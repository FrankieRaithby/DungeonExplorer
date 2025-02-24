using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Private Fields
        private string _name;
        private int _health;
        private List<string> inventory = new List<string>();

        // Parameterized Constructor

        public Player(string name, int health) 
        {
            _name = name;
            _health = health;
        }

        // Public properties for accessing private fields
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }


        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}