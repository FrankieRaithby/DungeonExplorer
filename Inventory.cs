using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    internal class Inventory
    {
        private List<Item> _items;
        public Inventory(List<Item> items)
        {
            _items = items;
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




    }
}