using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Room> rooms;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Username", 250, new List<string>());
            rooms = new List<Room>
            {
                new Room("Room1", new List<string>{"Health Potion", "Sword", "Bow"}),
                new Room("Room2", new List<string>{"Torch", "Chisel"}),
                new Room("Room3", new List<string>{"Key", "Hammer"}),
                new Room("Room4", new List<string>{"ads"}),
                new Room("Room5", new List<string>{"ads"}),
                new Room("Room6", new List<string>{"ads"}),

            };
            currentRoom = rooms[0];
        }
        public void Start()
        {
            // Player Character Creation
            bool characterCreated = false;
            while (!characterCreated)
            {
                try
                {
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        throw new ArgumentNullException(nameof(username));
                    }
                    player.Name = username;
                    Console.WriteLine($"Username set to {username}.");
                    Console.WriteLine("Character successfuly created!");
                    // Exit loop on successful creation
                    characterCreated = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Username cannot be empty.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Rules
            // readkey to start game
            // Rooms, Items, Monsters, etc etc

            // Change the playing logic into true and populate the while loop
            int RoomNumber = 0;
            bool scavenged = false;
            bool playing = true;
            while (playing)
            {
                currentRoom = rooms[RoomNumber];
                Console.WriteLine(currentRoom.GetDescription());

                Dictionary<string, string> choices = new Dictionary<string, string>
                {
                    { "A", "View Inventory" },
                    { "B", "View Current Status" },
                    { "C", "Scavenge Room" },
                };

                if (scavenged)
                {
                    choices["C"] = "Next Room";
                }

                string Choice = player.GetChoice(choices);

                switch (Choice)
                {
                    case "A":
                        Console.WriteLine("You have chosen A.");
                        Console.WriteLine(player.InventoryContents());
                        break;
                    case "B":
                        Console.WriteLine("You have chosen B.");
                        Console.WriteLine(player.CurrentStatus());
                        break;
                    case "C":
                        Console.WriteLine("You have chosen C");
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
                                currentRoom.Loot.Clear();
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
                    
                    // options A B C D etc

                    // Current Status
                    // View Inventory

                    // reminders CRG
                    // player attributes, different rooms, items
                    // C# style guide
                    // testing class using debug.assert
                    // XML documenting comments


                    
                }


            }
        }
        public void PlayTurn()
        {

        }
    }
}