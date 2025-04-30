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
        private Room _currentRoom;
        private int _hitpoints;
        private int _strength;
        private int _points;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Monster(string name, string description, int health, Room currentRoom, int hitpoints, int strength, int points) : base(name, description, health, currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _currentRoom = currentRoom;
            _hitpoints = hitpoints;
            _strength = strength;
            _points = points;
        }

        public int Hitpoints
        {
            get { return _hitpoints; }
            set { _hitpoints = value; }
        }
        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public int GetHitpoints()
        {
            return Hitpoints;
        }
        public int GetStrength()
        {
            return Strength;
        }
        public int GetPoints()
        {
            return Points;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>

        public override void Attack(Creature target)
        {

            target.Health -= Hitpoints;

            Console.WriteLine($"{Name} attacks {target.Name} for {_hitpoints} damage!");
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
