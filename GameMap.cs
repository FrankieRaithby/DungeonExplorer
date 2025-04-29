using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class GameMap
    {
        private List<Room> _rooms;
        private Dictionary<Room, (int x, int y)> mapDictionary;

        public GameMap()
        {
            // Initialize the map with rooms and their connections
            Room Room1 = new Room("Entrance", "A dark and spooky hall.", 0, 0, new List<Item>(), new List<Monster>());
            Room Room2 = new Room("Library", "A room with a treasure chest.", 1, 0, new List<Item>(), new List<Monster>());
            Room Room3 = new Room("Room3", "A room with a sleeping monster.", 0, 1, new List<Item>(), new List<Monster>());
            Room Room4 = new Room("Room4", "A room with a hidden passage.", 1, 1, new List<Item>(), new List<Monster>());
            Room Room5 = new Room("Room5", "A room with a puzzle.", 2, 0, new List<Item>(), new List<Monster>());
            Room Room6 = new Room("Room6", "A room with a trap.", 0, 2, new List<Item>(), new List<Monster>());
            Room Room7 = new Room("Room7", "A room with a treasure map.", 1, 2, new List<Item>(), new List<Monster>());
            Room Room8 = new Room("Room8", "A room with a hidden door.", 2, 1, new List<Item>(), new List<Monster>());
            Room Room9 = new Room("Room9", "A room with a riddle.", 2, 2, new List<Item>(), new List<Monster>());
            Room Room10 = new Room("Room10", "A room with a monster.", 3, 0, new List<Item>(), new List<Monster>());
            Room Room11 = new Room("Room11", "A room with a treasure chest.", 3, 1, new List<Item>(), new List<Monster>());

            _rooms = new List<Room>()
            {
                Room1,
                Room2,
                Room3,
                Room4
            };

            mapDictionary = GetMapDictionary();
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

        private Dictionary<Room, (int x, int y)> GetMapDictionary()
        {
            Dictionary<Room, (int x, int y)> mapDictionary = new Dictionary<Room, (int x, int y)>();

            foreach (Room room in Rooms)
            {
                mapDictionary[room] = (room.GetX(), room.GetY());
            }

            return mapDictionary;
        }

        public Room GetRoom(string name)
        {
            return Rooms.Where(room => room.GetName().Equals(name)).Select(room => room).FirstOrDefault();
        }

        public Dictionary<string, Room> GetDirections(Player player)
        {
            Room playerRoom = player.GetCurrentRoom();
            (int x, int y) playerPosition = mapDictionary[playerRoom];

            Dictionary<string, Room> directions = new Dictionary<string, Room>();

            foreach (KeyValuePair<Room, (int x, int y)> room in mapDictionary)
            {
                (int x, int y) position = room.Value;

                if (position.x == playerPosition.x + 1 && position.y == playerPosition.y)
                {
                    directions["North"] = room.Key;
                }
                else if (position.x == playerPosition.x - 1 && position.y == playerPosition.y)
                {
                    directions["South"] = room.Key;
                }
                else if (position.x == playerPosition.x && position.y == playerPosition.y + 1)
                {
                    directions["East"] = room.Key;
                }
                else if (position.x == playerPosition.x && position.y == playerPosition.y - 1)
                {
                    directions["West"] = room.Key;
                }
            }
            return directions;
        }

        public string GetMap()
        {
            string map = "";

            foreach (Room room in Rooms)
            {
                if (room.GetDiscovered())
                {
                    
                }
            }

            return map;
        }
    }
}