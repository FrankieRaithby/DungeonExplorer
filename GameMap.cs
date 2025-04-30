using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class GameMap
    {
        private List<Room> _rooms;
        private Dictionary<Room, (int x, int y)> RoomCoordinates;

        private Room Room1;
        private Room Room2;
        private Room Room3;
        private Room Room4;
        private Room Room5;
        private Room Room6;
        private Room Room7;
        private Room Room8;
        private Room Room9;
        private Room Room10;
        private Room Room11;

        public GameMap()
        {
            // Initialize the map with rooms and their connections
            Random random = new Random();

            Room1 = new Room("Entrance", "A dark and spooky hall.", 0, 0, new List<Item>(), new List<Monster>(), 0);
            Room2 = new Room("Chamber of Whispers", "Voices echo from unseen, ancient mouths.", 1, 0, new List<Item>(), new List<Monster>(), 0);
            Room3 = new Room("Forgotten Forge", "Cold anvil rests beneath broken tools.", 0, 1, new List<Item>(), new List<Monster>(), 1);
            Room4 = new Room("Hall of Echoes", "Every step repeats with haunting delay.", 1, 1, new List<Item>(), new List<Monster>(), 0);
            Room5 = new Room("Crypt of the Fallen", "Resting place of heroes turned to dust.", 2, 0, new List<Item>(), new List<Monster>(), 0);
            Room6 = new Room("Wailing Vault", "Crying winds seep from sealed cracks.", 0, 2, new List<Item>(), new List<Monster>(), 0);
            Room7 = new Room("Emberwatch Spire", "Ash drifts in heat-scarred air.", 1, 2, new List<Item>(), new List<Monster>(), 2);
            Room8 = new Room("Obsidian Gallery", "Black glass walls reflect shifting shapes.", 2, 1, new List<Item>(), new List<Monster>(), 0);
            Room9 = new Room("Ashen Crossroads", "Paths split beneath layers of soot.", 2, 2, new List<Item>(), new List<Monster>(), 0);
            Room10 = new Room("Sealed Sanctum", "Runes glow on a silent door.", 3, 0, new List<Item>(), new List<Monster>(), 3);
            Room11 = new Room("Rifted Maw", "Ground splits into a yawning void.", 3, 1, new List<Item>(), new List<Monster>(), 0);





            _rooms = new List<Room>()
            {
                Room1,
                Room2,
                Room3,
                Room4,
                Room5,
                Room6,
                Room7,
                Room8,
                Room9,
                Room10,
                Room11
            };

            RoomCoordinates = GetRoomCoordinates();

            // weight, type, defence, durability
            Item armour1 = new Armour("Leather Helmet", "A sturdy leather Helmet.", 15, "Helmet", 1, 40);
            Item armour2 = new Armour("Leather Chestplate", "A sturdy leather Chestplate.", 30, "Chestplate", 3, 40);
            Item armour3 = new Armour("Leather Leggings", "A sturdy leather Leggings.", 20, "Leggings", 2, 40);
            Item armour4 = new Armour("Leather Boots", "A sturdy leather Boots.", 15, "Boots", 1, 40);

            Item armour5 = new Armour("Iron Helmet", "A sturdy Iron Helmet.", 20, "Helmet", 2, 60);
            Item armour6 = new Armour("Iron Chestplate", "A sturdy Iron Chestplate.", 40, "Chestplate", 4, 60);
            Item armour7 = new Armour("Iron Leggings", "A sturdy Iron Leggings.", 30, "Leggings", 3, 60);
            Item armour8 = new Armour("Iron Boots", "A sturdy Iron Boots.", 20, "Boots", 2, 60);

            Item armour9 = new Armour("Steel Helmet", "A sturdy Steel Helmet.", 25, "Helmet", 3, 80);
            Item armour10 = new Armour("Steel Chestplate", "A sturdy Steel Chestplate.", 50, "Chestplate", 5, 80);
            Item armour11 = new Armour("Steel Leggings", "A sturdy Steel Leggings.", 40, "Leggings", 4, 80);
            Item armour12 = new Armour("Steel Boots", "A sturdy Steel Boots.", 25, "Boots", 3, 80);

            // weight, damage, attack, durability
            Item weapon1 = new Weapon("Epipharnes' Kopis", "A sharp sword.", 20, 40, "Melee", 100);
            Item weapon2 = new Weapon("Epdorus' Dagger", "A sharp dagger.", 5, 25, "Melee", 100);
            Item weapon3 = new Weapon("Epitheos' Dory", "A sharp dory.", 40, 50, "Melee", 100);
            Item weapon4 = new Weapon("Antigonous' Dagger", "A sharp dagger.", 4, 20, "Melee", 100);
            Item weapon5 = new Weapon("Terkleius' Greatsword", "A sharp sword.", 60, 80, "Melee", 100);

            Item weapon6 = new Weapon("Epidias' Bow", "A sharp bow.", 15, 30, "Ranged", 100);
            Item weapon7 = new Weapon("Epixios' Staff", "A sharp staff.", 20, 50, "Ranged", 100);
            Item weapon8 = new Weapon("Hippocrates' Bow", "A sharp bow.", 10, 20, "Ranged", 100);
            Item weapon9 = new Weapon("Apollomedes' Crossbow", "A sharp staff.", 20, 40, "Ranged", 100);

            List<Item> weapons = new List<Item>()
            {
                weapon1,
                weapon2,
                weapon3,
                weapon4,
                weapon5,
                weapon6,
                weapon7,
                weapon8,
                weapon9
            };

            List<Item> armours = new List<Item>()
            {
                armour1,
                armour2,
                armour3,
                armour4,
                armour5,
                armour6,
                armour7,
                armour8,
                armour9,
                armour10,
                armour11,
                armour12
            };

            // Randomly assign loot to rooms
            foreach (Armour armour in armours)
            {
                int randomArmour = random.Next(0, Rooms.Count);
                Rooms[randomArmour].Loot.Add(armour);
            }
            foreach (Weapon weapon in weapons)
            {
                int randomWeapon = random.Next(0, Rooms.Count);
                Rooms[randomWeapon].Loot.Add(weapon);
            }


            foreach (Room room in Rooms)
            {
                int random1 = random.Next(0, 3);
                if (random1 == 0)
                {
                    int random2 = random.Next(0, 2);
                    if (random2 == 0)
                    {
                        room.Loot.Add(new Potion("Small Health Potion", "A potion that restores health.", 1, "Health", 10));
                    }
                    else if (random2 == 1)
                    {
                        room.Loot.Add(new Potion("Small Health Potion", "A potion that restores health.", 4, "Health", 40));
                    }
                }
                else if (random1 == 1)
                {
                    int random2 = random.Next(0, 2);
                    if (random2 == 0)
                    {
                        room.Loot.Add(armour1); // need to randomise
                    }
                    else if (random2 == 1)
                    {
                        room.Loot.Add(armour2);
                    }
                }
                else if (random1 == 2)
                {
                    int random2 = random.Next(0, 2);
                    if (random2 == 0)
                    {
                        room.Loot.Add(new Potion("Small Points Potion", "A potion that increases score.", 1, "Points", 10));
                    }
                    else if (random2 == 1)
                    {
                        room.Loot.Add(new Potion("Large Points Potion", "A potion that increases score.", 4, "Points", 40));
                    }
                }
            }

            // health, hitpoints, strength, health
            

            for (int i = 0; i < 3; i++)
            {
                foreach (Room room in Rooms)
                {
                    int random1 = random.Next(0, 7);
                    if (random1 == 0)
                        room.Monsters.Add(new Dragon("Dragon", "A fierce dragon.", 40, 20, 10, 60));
                    else if (random1 == 1)
                        room.Monsters.Add(new Goblin("Goblin", "A sneaky Goblin.", 10, 5, 2, 20));
                    else if (random1 == 2)
                        room.Monsters.Add(new Minotaur("Minotaur", "A rampaging Minotaur.", 10, 10, 5, 40));
                }
            }

        }

        public List<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        public List<Room> GetRooms()
        {
            return Rooms;
        }

        private Dictionary<Room, (int x, int y)> GetRoomCoordinates()
        {
            Dictionary<Room, (int x, int y)> mapDictionary = new Dictionary<Room, (int x, int y)>();

            foreach (Room room in Rooms)
            {
                mapDictionary[room] = (room.GetX(), room.GetY());
            }

            return mapDictionary;
        }

        public Room GetRoomByName(string name)
        {
            return Rooms.FirstOrDefault(room => room.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Room GetRoomByCoordinate(int x, int y)
        {
            return Rooms.FirstOrDefault(room => room.GetX() == x && room.GetY() == y);
        }

        public Room GetDirections(Player player)
        {
            Room currentRoom = player.GetCurrentRoom();

            if (currentRoom == null)
            {
                Console.WriteLine("ERROR: Player's current room is null.");
                return null;
            }

            if (!RoomCoordinates.TryGetValue(currentRoom, out var playerPosition))
            {
                Console.WriteLine($"Room '{currentRoom.GetName()}' not found in RoomCoordinates.");
                return null;
            }

            Dictionary<string, Room> directions = new Dictionary<string, Room>();

            Room North = GetRoomByCoordinate(playerPosition.x, playerPosition.y + 1);
            Room East = GetRoomByCoordinate(playerPosition.x + 1, playerPosition.y);
            Room South = GetRoomByCoordinate(playerPosition.x, playerPosition.y - 1);
            Room West = GetRoomByCoordinate(playerPosition.x - 1, playerPosition.y);

            if (North != null) directions["North"] = North;
            if (East != null) directions["East"] = East;
            if (South != null) directions["South"] = South;
            if (West != null) directions["West"] = West;

            Dictionary<string, string> choiceLabels = new Dictionary<string, string>();
            Dictionary<string, Room> choiceRooms = new Dictionary<string, Room>();

            int i = 0;
            foreach (var direction in directions)
            {
                string key = ((char)('A' + i)).ToString();
                choiceLabels[key] = $"{direction.Value.GetName()} ({direction.Key}) [{direction.Value.IfDiscovered()}]";
                choiceRooms[key] = direction.Value;
                i++;
            }

            string playerChoice = player.GetChoice(choiceLabels);

            if (choiceRooms.TryGetValue(playerChoice, out Room selectedRoom))
            {
                return selectedRoom;
            }

            Console.WriteLine("Invalid direction choice.");
            return null;
        }

        public void Travel(Player player, Room room)
        {
            if (player.CurrentRoom.GetDiscovered() == false)
            {
                player.CurrentRoom.SetDiscovered(true);
                player.Statistics.IncrementRoomsDiscovered();
            }
            player.CurrentRoom = room;
            Console.WriteLine($"\n\t{player.CurrentRoom.GetName()}\n\t{player.CurrentRoom.GetDescription()}");
        }

        //public string GetMap()
        //{
        //    string map = "";

        //    foreach (Room room in Rooms)
        //    {
        //        if (room.GetDiscovered())
        //        {

        //        }
        //    }

        //    return map;
        //}


    }
}