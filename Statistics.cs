using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Statistics
    {
        private int _roomsDiscovered;
        private int _monstersDefeated;
        private int _itemsCollected;

        public Statistics()
        {
            _roomsDiscovered = 0;
            _monstersDefeated = 0;
            _itemsCollected = 0;
        }

        public int RoomsDiscovered
        {
            get { return _roomsDiscovered; }
            set { _roomsDiscovered = value; }
        }
        public int MonstersDefeated
        {
            get { return _monstersDefeated; }
            set { _monstersDefeated = value; }
        }
        public int ItemsCollected
        {
            get { return _itemsCollected; }
            set { _itemsCollected = value; }
        }

        public void IncrementRoomsDiscovered()
        {
            _roomsDiscovered++;
        }
        public void IncrementMonstersDefeated()
        {
            _monstersDefeated++;
        }
        public void IncrementItemsCollected()
        {
            _itemsCollected++;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Game Statistics:");
            Console.WriteLine($"Rooms Discovered: {_roomsDiscovered}");
            Console.WriteLine($"Monsters Defeated: {_monstersDefeated}");
            Console.WriteLine($"Items Collected: {_itemsCollected}");
        }
    }
}
