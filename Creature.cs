namespace DungeonExplorer
{
    public abstract class Creature
    {
        private string _name;
        private string _description;
        private int _health;
        private Room _currentRoom;

        public Creature(string name, string description, int health, Room currentRoom)
        {
            _name = name;
            _description = description;
            _health = health;
            _currentRoom = currentRoom;
        }

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

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public Room CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public string GetName()
        {
            return Name;
        }
        public string GetDescription()
        {
            return Description;
        }
        public int GetHealth()
        {
            return Health;
        }
        public Room GetCurrentRoom()
        {
            return CurrentRoom;
        }
    }
}