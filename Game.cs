using System;
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
            player = new Player("", 0);
            currentRoom = new Room("description bla bla bla");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Player Creation
                Console.WriteLine("Enter your username: ");
                string username = Console.ReadLine();
                player.Name = username;
                player.Health = 250;
                
                
                // Code your playing logic here
            }
        }
    }
}