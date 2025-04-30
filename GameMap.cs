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

            List<Item> items1 = new List<Item>()
            {
                new Item("Key", "A rusty key.", 0.5f),
            };

            
            Room1 = new Room("Entrance", "A dark and spooky hall.", 0, 0, items1, new List<Monster>(), 0);
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
            Monster Monster1 = new Dragon("Dragon", "A fierce dragon.", 100, 50, 20, 100);
            Room2.Monsters.Add(Monster1);
            

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
            player.CurrentRoom.SetDiscovered(true);
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