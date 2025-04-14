using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature, IDamageable
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
        public Monster(string name, string description, int health, Inventory inventory, Room currentRoom) : base(name, description, health, currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _inventory = inventory;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>

        /// <summary>
        /// This method returns the monster healt as a string.
        /// </summary>
        public string CurrentStatus()
        {
            return ($"You are at {Health} health.");
        }

        public void Damage()
        {
            // Implement damage logic here
            throw new NotImplementedException();
        }
    }
}
