using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Puzzle
    {




        public static void NumberCodePuzzle()
        {
            //Console.WriteLine("This room requires a puzzle to be solved to scavenge...");
            Console.WriteLine("A chest requires a 3-digit code.");
            Console.WriteLine("Clue: Keep the first. Add five to the second. The last is minus one.");
            Console.WriteLine("Number: Square root of 9.");
            string answer = Console.ReadLine();

            if (answer == "382")
            {
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                NumberCodePuzzle();
            }
        }


        public static void TileOrderPuzzle() // alalal
        {
            
            Console.WriteLine("You find 4 pressure plates: Red, Blue, Green & Yellow. Step on them in the correct order.");
            Console.WriteLine("Clue: Sunlight over ocean, then leaves, then blood.");
            string answer = Console.ReadLine();

            if (answer == "382")
            {
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                TileOrderPuzzle();
            }
        }

        public static void UpsideDownPuzzle()
        {

            Console.WriteLine("Speak the secret code that is written upside down on the wall.");
            Console.WriteLine("Clue: ˙ƃuᴉɯɯɐɹƃoɹd sᴉ ǝpoɔ ʇǝɹɔǝs ǝɥ┴");
            string answer = Console.ReadLine().ToLower();

            if (answer == "programming")
            {
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                UpsideDownPuzzle();
            }
        }




    }
}
