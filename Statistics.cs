using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Statistics
    {
        private int _monstersKilled;
        private int _itemsCollected;
        private int _roomsDiscovered;

        public Statistics()
        {
            _monstersKilled = 0;
            _itemsCollected = 0;
            _roomsDiscovered = 0;
        }
        public int MonstersKilled
        {
            get { return _monstersKilled; }
            set { _monstersKilled = value; }
        }
        public int ItemsCollected
        {
            get { return _itemsCollected; }
            set { _itemsCollected = value; }
        }
        public int RoomsDiscovered
        {
            get { return _roomsDiscovered; }
            set { _roomsDiscovered = value; }
        }
        public void IncrementMonstersKilled()
        {
            MonstersKilled++;
        }
        public void IncrementItemsCollected()
        {
            ItemsCollected++;
        }
        public void IncrementRoomsDiscovered()
        {
            RoomsDiscovered++;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Game Statistics:");
            Console.WriteLine($"Monsters Killed: {MonstersKilled}");
            Console.WriteLine($"Items Collected: {ItemsCollected}");
            Console.WriteLine($"Rooms Discovered: {RoomsDiscovered}");
        }
    }
}
