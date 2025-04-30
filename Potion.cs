using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        private string _variant;
        private int _bonus;
        public Potion(string name, string description, int weight, string variant, int bonus) : base(name, description, weight)
        {
            _variant = variant;
            _bonus = bonus;
        }
        public string Variant
        {
            get { return _variant; }
            set { _variant = value; }
        }
        public int Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }

        public string GetVariant()
        {
            return Variant;
        }
        public int GetBonus()
        {
            return Bonus;
        }

        public override void UseItem(Player player)
        {
            if (Variant == "Health")
            {
                player.Health += Bonus;
                Console.WriteLine($"{player.Name} used {Name} and restored {Bonus} health.");
                this.DeleteItem(player);
            }
            else if (Variant == "Points")
            {
                player.Score += Bonus;
                Console.WriteLine($"{player.Name} used {Name} and gained {Bonus} points.");
                this.DeleteItem(player);
            }
            else
            {
                Console.WriteLine($"{player.Name} used {Name}, but nothing happened.");
            }
        }
    }
}
