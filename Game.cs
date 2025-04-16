using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace DungeonExplorer
{
    /// <summary>
    /// This class utilises player and room objects to control game loop.
    /// </summary>
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Room> rooms;

        private Item item;
        private Inventory inventory;
        private GameMap gamemap;

        public Game()
        {
            /// <summary>
            /// Intitialising player instance and multiple room instances.
            /// </summary>
            Inventory inventory = new Inventory(new List<Item>(), 150);
            player = new Player("Username", "asd", 250, inventory);
        }

        public string Player
        {
            get { return player.Name; }
            set { player.Name = value; }
        }


        /// <summary>
        /// This method handles main game loop.
        /// </summary>
        public void Start()
        {
            // Player Character Creation
            player.SetName();
            Testing.CheckName(player);

            // Rules
            Console.WriteLine("RULES:");
            Console.WriteLine("You are trapped within the dungeon and must traverse each room.");
            Console.WriteLine("There may be items in a room, but you are only allowed to pick one, so choose wisely.");
            Console.WriteLine("You only have 250 health, so always check your health.");
            Console.WriteLine("Some items are one use, so ensure you use them at the correct time.");

            // Playing Loop
            int RoomNumber = 0;
            bool scavenged = false;
            bool playing = true;
            while (playing)
            {
                Console.WriteLine(RoomNumber);
                // Checks if player has gone through all rooms, otherwise escape.
                if (RoomNumber+1 > rooms.Count)
                {
                    Console.WriteLine("Congratulations, you have escaped the dungeon!");
                    playing = false;
                    break;
                }
                else
                {
                    currentRoom = rooms[RoomNumber];
                }

                // Room description
                Console.WriteLine($"\n{currentRoom.GetDescription()}");

                // Default Choices
                Dictionary<string, string> choices = new Dictionary<string, string>
                {
                    { "A", "View Inventory" },
                    { "B", "View Current Status" },
                    { "C", "Scavenge Room" },
                };

                // Changes choice [C] if room has been looted.
                if (scavenged)
                {
                    choices["C"] = "Next Room";
                }

                // Gets user input for their choice
                string Choice = player.GetChoice(choices);
                // Functions for each choice
                switch (Choice)
                {
                    case "A":
                        Console.WriteLine("\tYou have chosen A.");
                        Console.WriteLine(Player.InventoryContents());
                        break;
                    case "B":
                        Console.WriteLine("\tYou have chosen B.");
                        Console.WriteLine(Player.CurrentStatus());
                        break;
                    case "C":
                        Console.WriteLine("\tYou have chosen C.");
                        // Boolean check if room has loot
                        if (currentRoom.HasLoot())
                        {
                            Dictionary<string, string> loot = new Dictionary<string, string>();

                            int i = 0;
                            foreach (Item item in currentRoom.Loot)
                            {
                                char letter = (char)('A' + i);
                                loot[letter.ToString()] = item.GetName();
                                i++;
                            }

                            Console.WriteLine("Pick up an item:");
                            string weapon = player.GetChoice(loot);
                            if (loot.ContainsKey(weapon))
                            {
                                Player.PickUpItem(loot[weapon], currentRoom);
                                Testing.CheckItem(player, loot[weapon]);
                            }
                        }
                        scavenged = true;
                        if (choices["C"] == "Next Room")
                        {
                            Console.WriteLine("You proceed to the next room.");
                            scavenged = false;
                            RoomNumber++;
                        }
                        break;
                }
            }
        }
    }
}