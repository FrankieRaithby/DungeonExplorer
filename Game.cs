using System;
using System.Collections.Generic;


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

        public Testing testing;

        public Game()
        {
            /// <summary>
            /// Intitialising player instance and multiple room instances.
            /// </summary>
            player = new Player("Username", 250, new List<string>());
            rooms = new List<Room>
            {
                new Room("The Abandoned Armory – Rusted weapons and shattered shields litter the floor, with dust thick on every surface.", new List<string>{"Dagger", "Sword", "Bow"}),
                new Room("The Old Workshop – Shelves sag under the weight of dust-covered vials, and the faint smell of chemicals lingers in the air.", new List<string>{"Torch", "Chisel"}),
                new Room("The Echoing Hall – Every step taken here repeats tenfold, bouncing off the cold stone walls.", new List<string>{"Key", "Hammer"}),
                new Room("The Crumbling Chapel – A worn altar stands beneath a faded fresco, its colors dulled by time and neglect.", new List<string>{"Shield", "Dagger"}),
                new Room("The Forgotten Tomb – Rows of stone sarcophagi line the walls, their lids slightly ajar in the dim light.", new List<string>{"Invisibility Potion", "Health Potion", "Bone"}),
                new Room("The Mirror Room – The walls are lined with tall, warped mirrors, their surfaces clouded with age.", new List<string>{"Book", "White Pearl", "Staff"}),
            };
        }
        /// <summary>
        /// This method handles main game loop.
        /// </summary>
        public void Start()
        {
            // Player Character Creation
            player.SetName();
            player.Name = "";
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
                currentRoom = rooms[RoomNumber];

                // Checks if player has gone through all rooms, otherwise escape.
                if (rooms.Count < RoomNumber)
                {
                    Console.WriteLine("Congratulations, you have escaped the dungeon!");
                    playing = false;
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
                        Console.WriteLine(player.InventoryContents());
                        break;
                    case "B":
                        Console.WriteLine("\tYou have chosen B.");
                        Console.WriteLine(player.CurrentStatus());
                        break;
                    case "C":
                        Console.WriteLine("\tYou have chosen C.");
                        // Boolean check if room has loot
                        if (currentRoom.HasLoot())
                        {
                            Dictionary<string, string> loot = new Dictionary<string, string>();

                            int i = 0;
                            foreach (string item in currentRoom.Loot)
                            {
                                char letter = (char)('A' + i);
                                loot[letter.ToString()] = item;
                                i++;
                            }

                            Console.WriteLine("Pick up an item:");
                            string weapon = player.GetChoice(loot);
                            if (loot.ContainsKey(weapon))
                            {
                                player.PickUpItem(loot[weapon], currentRoom);
                                Testing.CheckItem(player, weapon);
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