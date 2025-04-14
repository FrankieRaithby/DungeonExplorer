using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private List<Room> rooms;
        private Dictionary<Room, (int x, int y)> mapDictionary;

        public GameMap()
        {
            // Initialize the map with rooms and their connections
            Room Room1 = new Room("Room1", "A dark and spooky room.", 0, 0, new List<Item>());
            Room Room2 = new Room("Room2", "A room with a treasure chest.", 1, 0, new List<Item>());
            Room Room3 = new Room("Room3", "A room with a sleeping monster.", 0, 1, new List<Item>());
            Room Room4 = new Room("Room4", "A room with a hidden passage.", 1, 1, new List<Item>());

            rooms = new List<Room>()
            {
                Room1,
                Room2,
                Room3,
                Room4
            };

            mapDictionary = GetMapDictionary();
        }

        private Dictionary<Room, (int x, int y)> GetMapDictionary()
        {
            Dictionary<Room, (int x, int y)> mapDictionary = new Dictionary<Room, (int x, int y)>();

            foreach (Room room in rooms)
            {
                mapDictionary[room] = (room.GetX(), room.GetY());
            }

            return mapDictionary;
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

        public string GetMap(Player player)
        {
            string map = "";

            foreach (Room room in rooms)
            {
                if (room.IsDiscovered())
                {
                    
                }
            }

            return map;
        }
    }
}