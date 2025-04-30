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

            Console.WriteLine($"\n\t{currentRoom.GetName()}\n\t{currentRoom.GetDescription()}");

            // Playing Loop
            //int RoomNumber = 0;
            //bool scavenged = false;
            bool playing = true;
            while (playing)
            {
                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine("You have died. Game Over.");
                    playing = false;
                    break;
                }
                bool allMonstersDefeated = true;

                foreach (var room in gamemap.GetRooms())
                {
                    foreach (var monster in room.GetMonsters())
                    {
                        if (monster.IsAlive())
                        {
                            allMonstersDefeated = false;
                            break;
                        }
                    }

                    if (!allMonstersDefeated)
                        break;
                }

                if (allMonstersDefeated)
                {
                    Console.WriteLine("You have defeated all enemies. Victory is yours!");
                    playing = false;
                    break;
                }

                Dictionary<string, string> primaryChoices = new Dictionary<string, string>
                {
                    { "A", "Scavenge Room" },
                    { "B", "View Player Status" },
                    { "C", "View Inventory" },
                    { "D", "View Statistics" }
                };

                //Console.WriteLine(currentRoom.Name + currentRoom.GetPuzzle());

                // Check for Monsters
                if (currentRoom.HasMonsters())
                {
                    primaryChoices["A"] = "To Battle";
                }
                else if (currentRoom.GetPuzzle() != 0)
                {
                    primaryChoices["A"] = "Decode Puzzle";
                }
                else
                {
                    primaryChoices["E"] = "Get Directions";
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
                            player.BattleMenu(player, gamemap);
                        }
                        else if (currentRoom.GetPuzzle() != 0)
                        {
                            // Puzzle Logic
                            int puzzle = currentRoom.GetPuzzle();
                            player.SolvePuzzle(puzzle);
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
                        bool finished = false;
                        while (!finished)
                        {
                            Dictionary<string, string> AttireChoices = new Dictionary<string, string>
                        {
                            { "A", "View Spare Armour" },
                            { "B", "Equip Armour" },
                            { "C", "Unequip Armour" },
                            { "D", "View Play Status" },
                            { "E", "Exit Attire Menu" },
                        };

                            string AttireChoice = player.GetChoice(AttireChoices);

                            switch (AttireChoice)
                            {
                                case "A":
                                    // View Spare Armour
                                    player.Attire.DisplaySpareArmour();
                                    break;
                                case "B":
                                    // Equip Armour
                                    player.Attire.EquipArmour(player);
                                    break;
                                case "C":
                                    // Unequip Armour
                                    player.Attire.UnequipArmour(player);
                                    break;
                                case "D":
                                    // View Player Status
                                    player.DisplayStatus();
                                    break;
                                case "E":
                                    // Exit Attire Menu
                                    finished = true;
                                    break;
                            }
                        }
                        

                        break;
                    case "C":
                        // View Inventory
                        player.Inventory.DisplayInventory();

                        bool finished2 = false;

                        // Inventory Management
                        while (!finished2)
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
                                    finished2 = true;
                                    break;
                            }
                        }
                        break;
                    case "D":
                        // View Statistics
                        player.DisplayStatistics();
                        break;
                    case "E":
                        // Get Directions
                        Room TravelRoom = gamemap.GetDirections(player);
                        gamemap.Travel(player, TravelRoom);
                        currentRoom = player.GetCurrentRoom();
                        break;
                        

                }
                























                // game loop
            }
                    















            

        }
    }
}