using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    public class Testing
    {
        /// <summary>
        /// This method returns tests if player has item in his inventory.
        /// </summary>
        public static void CheckItem(Player player, Item item)
        {
            Debug.Assert(player.GetInventory().GetItems().Contains(item), $"{item} cannot be found in the inventory.");
        }

        /// <summary>
        /// This method returns tests if player name is not null or empty.
        /// </summary>
        public static void CheckName(Player player)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(player.Name) && !string.IsNullOrEmpty(player.Name), ("Name is null, white space or empty."));
        }
    }
}