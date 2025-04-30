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
        private int _hitpoints;
        private int _strength;
        private int _points;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Monster(string name, string description, int health, int hitpoints, int strength, int points) : base(name, description, health)
        {
            _name = name;
            _description = description;
            _health = health;
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
        /// 
        public virtual void GetMonsterInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Hitpoints: {Hitpoints}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Points: {Points}");
        }

        public override void Attack(Creature target)
        {

            target.Health -= Hitpoints;

            Console.WriteLine($"{Name} attacks {target.Name} for {_hitpoints} damage!");
        }

        public void Flee(GameMap gamemap)
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} is dead and cannot flee.");
                return;
            }

            if (Health <= 10)
            {
                Console.WriteLine($"\n\t{Name} is fleeing from the battle!");
                Random random = new Random();
                int fleeChance = random.Next(1, 6);
                if (fleeChance <= 2)
                {
                    Console.WriteLine($"\t{Name} successfully fled!");
                    int randomIndex = random.Next(0, gamemap.GetRooms().Count + 1);
                    gamemap.GetRooms()[randomIndex].Monsters.Add(this);
                    return;
                }
                else
                {
                    Console.WriteLine($"\t{Name} failed to flee!");
                    return;
                }
            }
            
                
        }

        public void Damage(int damage)
        {
            Console.WriteLine($"You attack the {Name}, dealing {damage} damage.");
            Health -= damage;
        }

        

    }

    public class Dragon : Monster, IFlyable
    {
        private bool _isFlying;
        public Dragon(string name, string description, int health, int hitpoints, int strength, int points) : base(name, description, health, hitpoints, strength, points)
        {
            _isFlying = false;
        }
        public bool IsFlying
        {
            get { return _isFlying; }
            set { _isFlying = value; }
        }

        public override void Attack(Creature target)
        {
            if (IsFlying)
            {
                Console.WriteLine($"\t{Name} breathes fire from the sky onto {target.Name}!");
            }
            else
            {
                Console.WriteLine($"\t{Name} uses claws to attack {target.Name}!");
            }
        }

        public void Fly()
        {
            IsFlying = true;
            Console.WriteLine($"{Name} is flying!");
        }

        public void Land()
        {
            IsFlying = false;
            Console.WriteLine($"{Name} has landed.");
        }
    }



    public class Goblin : Monster
    {
        public Goblin(string name, string description, int health, int hitpoints, int strength, int points) : base(name, description, health, hitpoints, strength, points)
        {
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"\t{Name} attacks {target.Name} with a dagger!");
        }
    }

    


}
