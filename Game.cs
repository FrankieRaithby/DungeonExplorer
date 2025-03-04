﻿using System;
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
            currentRoom = rooms[1];
            rooms = new List<Room>
            {
                new Room("asd", new List<string>{"ads"}),

            };
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
            bool playing = true;
            while (playing)
            {
                int RoomNumber = 1;
                currentRoom = rooms[RoomNumber];

                currentRoom.GetDescription();

                string Choice = player.GetChoice(new Dictionary<string, string>
                {
                    { "A", "View Inventory" },
                    { "B", "View Current Status" },
                    { "C", "Scavenge Room" },
                });

                switch (Choice)
                {
                    case "A":
                        Console.WriteLine("You have chosen A.");
                        player.InventoryContents();
                        break;
                    case "B":
                        Console.WriteLine("You have chosen B.");
                        player.CurrentStatus();
                        break;
                    case "C":
                        Console.WriteLine("You have chosen C");
                        if (player.Scavenge(currentRoom))
                        {
                            Dictionary<string, string> loot = new Dictionary<string, string>();

                            foreach (string item in currentRoom.Loot)
                            {
                                for (int i = 0; i < 26; i++)
                                {
                                    char letter = (char)('A' + i);
                                    loot[letter.ToString()] = item;
                                }
                            }

                            string weapon = player.GetChoice(loot);
                            if (loot.ContainsKey(weapon))
                            {
                                player.PickUpItem(loot[weapon]);
                            }
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