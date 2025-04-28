using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Armour : Item
    {
        private string _type;
        private int _defence;
        
        public Armour(string name, string description, int weight, string type, int defence) : base(name, description, weight)
        {
            _type = type;
            _defence = defence;
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }
    }
}
