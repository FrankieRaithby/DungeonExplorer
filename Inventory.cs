using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    internal class Inventory
    {
        private List<Item> _items;
        private int _maxWeight;
        private int _currentWeight;

        public Inventory(List<Item> items, int maxWeight)
        {
            _items = items;
            _maxWeight = maxWeight;
            _currentWeight = CalculateCurrentWeight();
        }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public bool ItemExists(string name)
        {
            return Items.Exists(item => item.Name == name);
        }

        private int CalculateCurrentWeight()
        {
            return Items.Sum(item => item.Weight);
        }

    }
}