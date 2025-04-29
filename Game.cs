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
        private GameMap gamemap;

        private Inventory inventory;
        private Attire attire;
        private Room currentRoom;
        private int score;

        public Game()
        {
            /// <summary>
            /// Intitialising player instance and multiple room instances.
            /// </summary>
            Inventory inventory = new Inventory(new List<Item>(), 150);
            Attire attire = new Attire(null, null, null, null);
            Room currentRoom = gamemap.GetRoom("Entrance");
            int score = 0;

            player = new Player("Username", "Human Player", 100, currentRoom, inventory, attire, score);
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
            //int RoomNumber = 0;
            //bool scavenged = false;
            bool playing = true;
            while (playing)
            {
                //Console.WriteLine(RoomNumber);
                // Checks if player has gone through all rooms, otherwise escape.
                //if (RoomNumber+1 > rooms.Count)
                //{
                //    Console.WriteLine("Congratulations, you have escaped the dungeon!");
                //    playing = false;
                //    break;
                //}
                //else
                //{
                //   currentRoom = rooms[RoomNumber];
                //}

                // Room description

                // Default Choices
                Dictionary<string, string> primaryChoices = new Dictionary<string, string>
                {
                    { "A", "Scavenge Room" },
                    { "B", "View Player Status" },
                    { "C", "View Inventory" },
                };

                // Check for Monsters
                if (currentRoom.HasMonsters())
                {
                    primaryChoices["A"] = "To Battle";
                }
                else
                {
                    primaryChoices["D"] = "Get Directions";
                }

                // Gets user input for their choice
                string Choice = player.GetChoice(primaryChoices);
                // Functions for each choice

                Console.WriteLine($"\nYou have chosen {Choice}.");

                switch (Choice)
                {
                    case "A":
                        if (currentRoom.HasMonsters())
                        {
                            // Battle Logic
                            List<Monster> monsters = currentRoom.GetMonsters();
                        }
                        else
                        {
                            // Scavenge
                            if (currentRoom.HasLoot())
                            {
                                // If room has loot

                            }
                        }
                        break;
                    case "B":
                        // View Player Status
                        player.DisplayStatus();

                        // Attire Management
                        Dictionary<string, string> AttireChoices = new Dictionary<string, string>
                        {
                            { "A", "View Spare Armour" },
                            { "B", "Equip Armour" },
                            { "C", "Unequip Armour" },
                            { "D", "View Play Status" },
                            { "E", "Exit Attire Menu" },
                        };


                        break;
                    case "C":
                        // View Inventory
                        player.Inventory.DisplayInventory();

                        bool finished = false;

                        // Inventory Management
                        if (!finished)
                        {
                            Dictionary<string, string> InventoryChoices = new Dictionary<string, string>
                            {
                                { "A", "Drop Item" },
                                { "B", "Use Item" },
                                { "C", "View Inventory" },
                                { "D", "Exit Inventory Menu" },
                            };
                        }
                        break;
                    case "D":
                        // Get Directions
                        gamemap.GetDirections(player);
                        break;
                }























                    // game loop
                }
                    

















        }
    }
}