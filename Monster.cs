using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int _damage;
        private int _strength;
        private int _points;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Monster(string name, string description, int health, Inventory inventory, Room currentRoom, int damage, int points) : base(name, description, health, currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _inventory = inventory;
            _damage = damage;
            _points = points;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>

        public override void Attack(Creature target)
        {
            
        }

        public void Flee(GameMap gamemap)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, gamemap.GetRooms().Count);
            CurrentRoom = gamemap.GetRooms()[randomIndex];
        }

        public void Damage()
        {
            // Implement damage logic here
            throw new NotImplementedException();
        }
    }
}
