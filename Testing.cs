using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    public class Testing
    {
        /// <summary>
        /// This method returns tests if player has item in his inventory.
        /// </summary>
        public static void CheckItemInInventory(List<Item> items, Item item)
        {
            Debug.Assert(items.Contains(item), $"{item} cannot be found in the inventory.");
        }

        public static void CheckItemInRoom(Room room, Item item)
        {
            Debug.Assert(room.Loot.Contains(item), $"{item} cannot be found in the room.");
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