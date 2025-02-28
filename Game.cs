using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("", 250, new List<string>());
            currentRoom = new Room("description bla bla bla", new List<string>());
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
            
            
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                
                // options A B C D etc

                // Current Status
                // View Inventory

                // reminders CRG
                // player attributes, different rooms, items
                // C# style guide
                // testing class using debug.assert
                // XML documenting comments
                
                
                // Code your playing logic here
            }
        }
    }
}