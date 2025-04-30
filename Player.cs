using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private Room _currentRoom;
        private Inventory _inventory;
        private Attire _attire;
        private int _score;
        private Statistics _statistics;


        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Player(string name, string description, int health, Room currentRoom) : base(name, description, health)
        {
            _inventory = new Inventory(new List<Item>(), 150);
            _attire = new Attire(null, null, null, null);
            _currentRoom = currentRoom;
            _score = 0;
            _statistics = new Statistics();
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>
        public Statistics Statistics
        {
            get { return _statistics; }
            set { _statistics = value; }
        }
        public Room CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public Attire Attire
        {
            get { return _attire; }
            set { _attire = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public Room GetCurrentRoom()
        {
            return CurrentRoom;
        }
        public Inventory GetInventory()
        {
            return Inventory;
        }
        public Attire GetAttire()
        {
            return Attire;
        }
        public int GetScore()
        {
            return _score;
        }






        /// <summary>
        /// This method sets the player name.
        /// </summary>
        public void SetName()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        throw new ArgumentNullException(nameof(username));
                    }
                    Name = username;
                    Console.WriteLine($"Username set to {username}.");
                    Console.WriteLine("Character successfuly created!\n");
                    // Exit loop on successful creation
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Username cannot be empty.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EnterRoom(Room room)
        {
            // Check if the room is valid
            if (room != null)
            {
                _currentRoom = room;
                Console.WriteLine($"You have entered {room.GetName()}.");
                Console.WriteLine($"Description: {room.GetDescription()}");
                room.SetDiscovered(true);
                Statistics.IncrementRoomsDiscovered();
            }
            else
            {
                Console.WriteLine("Invalid room.");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"\n\t{GetName()}");
            Console.WriteLine($"\t{GetDescription()}");
            Console.WriteLine("\t--------------");
            Console.WriteLine($"\tHealth: {GetHealth()}");
            Console.WriteLine($"\tScore: {GetScore()}");
            Attire.DisplayAttire();
        }

        public void SolvePuzzle(int puzzleIndex)
        {
            if (puzzleIndex == 1)
            {
                Puzzle.BinaryCodePuzzle();
                CurrentRoom.SetPuzzle(0);
            }
            else if (puzzleIndex == 2)
            {
                Puzzle.TileOrderPuzzle();
                CurrentRoom.SetPuzzle(0);
            }
            else
            {
                Puzzle.NumberCodePuzzle();
                CurrentRoom.SetPuzzle(0);
            }
        }

        public void BattleMenu(Player player, GameMap gamemap)
        {
            if (player.CurrentRoom.GetMonsters() == null)
            {
                Console.WriteLine("\tNo monsters in this room.");
                return;
            }

            List<Monster> monsters = SortMonsterAscendingStrength(CurrentRoom.GetMonsters());

            Console.WriteLine("\n\tChoose a monster to attack\n");

            foreach (Monster monster in monsters)
            {
                monster.GetMonsterInfo();
            }

            Dictionary<string, string> monsterChoices = new Dictionary<string, string>();

            int i1 = 0;
            foreach (Monster monster in monsters)
            {
                string letter = ((char)('A' + i1)).ToString();
                monsterChoices[letter] = monster.GetName();
                i1++;
            }

            string chosenMonster = player.GetChoice(monsterChoices);
            Monster monsterToAttack = null;

            if (monsterChoices.ContainsKey(chosenMonster))
            {
                monsterToAttack = player.CurrentRoom.GetMonsterByName(monsterChoices[chosenMonster]);
            }


            Console.WriteLine("\n\tChoose a weapon to attack with\n");

            List<Weapon> weapons = Inventory.GetWeapons();
            Weapon weaponToUse = null;

            if (weapons == null || weapons.Count == 0)
            {
                Console.WriteLine("\tNo weapons available.");
            }
            else
            {
                foreach (Weapon weapon in weapons)
                {
                    weapon.GetWeaponInfo();
                }

                Dictionary<string, string> weaponChoices = new Dictionary<string, string>();

                int i2 = 0;
                foreach (Weapon weapon in weapons)
                {
                    string letter = ((char)('A' + i2)).ToString();
                    weaponChoices[letter] = weapon.GetName();
                    i2++;
                }

                string chosenWeapon = player.GetChoice(weaponChoices);


                if (weaponChoices.ContainsKey(chosenWeapon))
                {
                    weaponToUse = player.Inventory.GetWeaponByName(weaponChoices[chosenWeapon]);
                }
            }

            

            Attack(monsterToAttack, weaponToUse, gamemap);

        }

        /// <summary>
        /// This method gets user input for their choice.
        /// </summary>
        public string GetChoice(Dictionary<string, string> choices)
        {
            Console.WriteLine("\n");
            // Collect UserInput
            while (true)
            {
                foreach (KeyValuePair<string, string> choice in choices)
                {
                    Console.WriteLine($"\t[{choice.Key}] - {choice.Value}.");
                }

                string UserInput = Console.ReadLine().Trim().ToUpper();

                // Check UserInput is a dictionary key
                if (choices.ContainsKey(UserInput))
                {
                    //Console.WriteLine($"{Name} has chosen [{UserInput}] - {choices[UserInput]}.");
                    return UserInput;
                }
                else
                {
                    Console.WriteLine("\tInvalid choice, please pick from the list");
                }
            }
        }


        public void Damage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"You have taken {damage} damage.");
            if (Health <= 0)
            {
                Console.WriteLine("You have been defeated!");
                // Handle player defeat (e.g., end game, respawn, etc.)
            }
        }

        public void Attack(Monster target, Weapon weapon, GameMap gamemap)
        {
            

            if (weapon == null)
            {
                weapon = new Weapon("Fists", "Brute Force", 0, 10, "Melee", 1000);
            }

            target.DealDamage(weapon);
            if (weapon.GetName() != "Firsts")
            {
                weapon.DecreaseDurability(20);
            }
            
            if (target.IsAlive())
            {
                Console.WriteLine($"\t{target.GetName()} has {target.GetHealth()} health remaining.");
                target.Flee(gamemap);
            }
            else
            {
                Console.WriteLine($"\t{target.GetName()} has been defeated!");
                Score += target.GetPoints();
                Console.WriteLine($"\tYou have gained {target.GetPoints()} points!");
                CurrentRoom.GetMonsters().Remove(target);
            }
        }


        public List<Monster> SortMonsterAscendingStrength(List<Monster> monsters)
        {
            // Sort the list of monsters by strength in ascending order
            return monsters.OrderBy(monster => monster.Strength).ToList();
        }



    }
}