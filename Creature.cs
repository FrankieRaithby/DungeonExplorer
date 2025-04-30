using System;

namespace DungeonExplorer
{
     public class Creature
    {
        protected string _name;
        protected string _description;
        protected int _health;

        protected Creature(string name, string description, int health)
        {
            _name = name;
            _description = description;
            _health = health;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public string GetName()
        {
            return Name;
        }
        public string GetDescription()
        {
            return Description;
        }
        public int GetHealth()
        {
            return Health;
        }

        public virtual void Attack(Creature target)
        {
            Console.WriteLine(target.GetName() + " is attacked by " + Name);
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}