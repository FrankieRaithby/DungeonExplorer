using System;

namespace DungeonExplorer
{
    public class Item
    {
        /// <summary>
        /// Private Fields.
        /// </summary>
        private string _name;
        private string _description;
        private int _weight;

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Item(string name, string description, int weight)
        {
            _name = name;
            _description = description;
            _weight = weight;
        }

        /// <summary>
        /// Public properties for accessing private fields.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /// <summary>
        /// Returns name of Item instance.
        /// </summary>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Returns description of Item instance.
        /// </summary>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// Returns description of Item instance.
        /// </summary>
        public int GetWeight()
        {
            return Weight;
        }

        public virtual void UseItem()
        {
            Console.WriteLine("Using item: " + Name);
        }
    }
}