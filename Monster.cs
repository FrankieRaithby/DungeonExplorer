using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
            Console.WriteLine($"\t[{Name}] - {Description}");
            Console.WriteLine($"\t{Strength} STR, {Hitpoints} HIT, {Points} PTS\n\t{Health} Health");
            Console.WriteLine("\t--------------");
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
        public virtual void DealDamage(Weapon weapon)
        {
            throw new NotImplementedException();
        }

            public void Damage(int damage)
        {
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

        public override void GetMonsterInfo()
        {
            Console.WriteLine($"\t[{Name}] - {Description}");
            Console.WriteLine($"\t{Strength} STR, {Hitpoints} HIT, {Points} PTS\n\t{Health} Health");
            Console.WriteLine($"\tFlying: {IsFlying}");
            Console.WriteLine("\t--------------");
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

        public override void DealDamage(Weapon weapon)
        {
            Random random = new Random();
            int Roll = random.Next(0, 2);

            int damage = weapon.GetDamage();

            // Critical hit or normal hit
            if (Roll == 1)
            {
                Console.WriteLine("\tCritical Hit!");
                damage = damage * 2;
                weapon.Durability -= 5;
            }
            else
            {
                Console.WriteLine("\tNormal Hit!");
                weapon.Durability -= 10;
            }

            // Check if the weapon is ranged and the dragon is flying
            if (IsFlying)
            {
                if (weapon.Attack == "Ranged")
                {
                    Console.WriteLine($"\t{Name} is flying and the weapon is ranged. Damage dealt: {damage}");
                    damage = (int)(damage * 1.5);
                }
                else
                {
                    Console.WriteLine("\tDragon is flying, but the weapon is not ranged. No damage dealt.");
                    damage = 0;
                }
            }

            Damage(damage);
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
        private bool _isStealthy;
        public Goblin(string name, string description, int health, int hitpoints, int strength, int points) : base(name, description, health, hitpoints, strength, points)
        {
            _isStealthy = true;
        }
        public bool IsStealthy
        {
            get { return _isStealthy; }
            set { _isStealthy = value; }
        }
        public override void GetMonsterInfo()
        {
            Console.WriteLine($"\t[{Name}] - {Description}");
            Console.WriteLine($"\t{Strength} STR, {Hitpoints} HIT, {Points} PTS\n\t{Health} Health");
            Console.WriteLine($"\tStealth: {IsStealthy}");
            Console.WriteLine("\t--------------");
        }
        public override void Attack(Creature target)
        {
            Console.WriteLine($"\t{Name} attacks {target.Name} with a dagger!");
        }
    }

    public class Minotaur : Monster
    {
        private bool _isRunning;
        public Minotaur(string name, string description, int health, int hitpoints, int strength, int points) : base(name, description, health, hitpoints, strength, points)
        {
            _isRunning = false;
        }
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }
        public void Run()
        {
            IsRunning = true;
            Console.WriteLine($"{Name} is running!");
        }
        public void Stop()
        {
            IsRunning = false;
            Console.WriteLine($"{Name} has stopped running.");
        }
        public override void GetMonsterInfo()
        {
            Console.WriteLine($"\t[{Name}] - {Description}");
            Console.WriteLine($"\t{Strength} STR, {Hitpoints} HIT, {Points} PTS\n\t{Health} Health");
            Console.WriteLine($"\tRunning: {IsRunning}");
            Console.WriteLine("\t--------------");
        }
        public override void Attack(Creature target)
        {
            Console.WriteLine($"\t{Name} charges at {target.Name} with its horns!");
        }
    }


}
