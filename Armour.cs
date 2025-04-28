using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Armour : Item
    {
        private string _variant;
        private int _defence;
        
        public Armour(string name, string description, int weight, string type, int defence) : base(name, description, weight)
        {
            _variant = type; // Helmet, Chestplate, Leggings, Boots
            _defence = defence;
        }

        public string Variant
        {
            get { return _variant; }
            set { _variant = value; }
        }

        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }

        public string GetVariant()
        {
            return Variant;
        }
        public int GetDefence()
        {
            return Defence;
        }


    }
}
