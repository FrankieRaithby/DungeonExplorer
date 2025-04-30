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
            
            if (target is Player player)
            {
                int defence = player.Attire.GetDefence();

                int damage = Math.Max(0, Hitpoints - defence);
            }

            target.Health -= Hitpoints;

            Console.WriteLine($"{Name} attacks {target.Name} for {Hitpoints} damage!");
        }

        public void Flee(Player player, GameMap gamemap)
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
                    int randomIndex = random.Next(0, gamemap.GetRooms().Count);
                    player.CurrentRoom.Monsters.Remove(this);
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



    public class Goblin : Monster, IStealthy
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
            if (IsStealthy)
            {
                Console.WriteLine($"\t{Name} is in stealth mode and cannot be attacked!");
                damage = 0;
                Appear();
            }
            else
            {
                Console.WriteLine($"\t{Name} is not in stealth mode. Damage dealt: {damage}");
                Sneak();
            }

            Damage(damage);
        }
        public void Appear()
        {
            IsStealthy = false;
        }
        public void Sneak()
        {
            IsStealthy = true;
        }
    }

    public class Minotaur : Monster, IRunning
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
        public override void GetMonsterInfo()
        {
            Console.WriteLine($"\t[{Name}] - {Description}");
            Console.WriteLine($"\t{Strength} STR, {Hitpoints} HIT, {Points} PTS\n\t{Health} Health");
            Console.WriteLine($"\tRunning: {IsRunning}");
            Console.WriteLine("\t--------------");
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

            // Check if the weapon is ranged and the minotaur running
            if (IsRunning)
            {
                if (weapon.Attack == "Ranged")
                {
                    Console.WriteLine($"\t{Name} is running and the weapon is ranged. Damage dealt: {damage}");
                    damage = (int)(damage * 1.5);
                }
                else
                {
                    Console.WriteLine("\tMinotaur is running, but the weapon is not ranged. No damage dealt.");
                    damage = 0;
                }
                Stop();
            }
            else
            {
                Run();
            }

            Damage(damage);
        }

        public void Run()
        {
            IsRunning = true;
        }
        public void Stop()
        {
            IsRunning = false;
        }

    }


}
