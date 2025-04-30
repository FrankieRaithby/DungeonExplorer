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
        private Room currentRoom;

        public Game()
        {
            gamemap = new GameMap();
            currentRoom = gamemap.GetRoomByName("Entrance");
            player = new Player("Username", "Human Player", 250, currentRoom);
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

            Console.WriteLine($"\n\t{player.CurrentRoom.GetName()}\n\t{player.CurrentRoom.GetDescription()}");

            // Playing Loop
            //int RoomNumber = 0;
            //bool scavenged = false;
            bool playing = true;
            while (playing)
            {
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
                else if (currentRoom.GetPuzzle() != 0)
                {
                    int puzzleIndex = currentRoom.GetPuzzle();

                    if (puzzleIndex == 1)
                    {
                        Puzzle.UpsideDownPuzzle();
                    }
                    else if (puzzleIndex == 2)
                    {
                        Puzzle.TileOrderPuzzle();
                    }
                    else
                    {
                        Puzzle.NumberCodePuzzle();
                    }
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
                                player.Inventory.PickUpItemMenu(player);

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
                        while (!finished)
                        {
                            Dictionary<string, string> InventoryChoices = new Dictionary<string, string>
                            {
                                { "A", "Drop Item" },
                                { "B", "Use Item" },
                                { "C", "View Inventory" },
                                { "D", "Exit Inventory Menu" },
                            };

                            string InventoryChoice = player.GetChoice(InventoryChoices);

                            switch (InventoryChoice)
                            {
                                case "A":
                                    player.Inventory.DropItemMenu(player);
                                    break;
                                case "B":
                                    // Use Item
                                    player.Inventory.UseItemMenu(player);
                                    break;
                                case "C":
                                    // View Inventory
                                    player.Inventory.DisplayInventory();
                                    break;
                                case "D":
                                    // Exit Inventory Menu
                                    finished = true;
                                    break;
                            }
                        }
                        break;

                    case "D":
                            // Get Directions
                            Room TravelRoom = gamemap.GetDirections(player);
                            gamemap.Travel(player, TravelRoom);
                            break;
                        

                }
                























                // game loop
            }
                    















            

        }
    }
}