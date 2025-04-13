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

        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        public Item(string name, string description)
        {
            _name = name;
            _description = description;
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

        public virtual void UseItem()
        {
            Console.WriteLine("Using item: " + Name);
        }
    }
}