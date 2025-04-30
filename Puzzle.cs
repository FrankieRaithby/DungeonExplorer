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
            Console.WriteLine("Example: RGBY");
            string answer = Console.ReadLine().ToLower();

            if (answer == "ybgr")
            {
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                TileOrderPuzzle();
            }
        }

        public static void BinaryCodePuzzle()
        {

            Console.WriteLine("Speak the secret code that is written as 1s and 0s.");
            Console.WriteLine("Clue: 01010100 01101000 01100101 00100000 01110011 01100101 01100011 01110010 01100101 01110100 00100000 01100011 01101111 01100100 01100101 00100000 01101001 01110011 00100000 01110000 01110010 01101111 01100111 01110010 01100001 01101101 01101101 01101001 01101110 01100111");
            string answer = Console.ReadLine().ToLower();

            if (answer == "programming")
            {
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                BinaryCodePuzzle();
            }
        }




    }
}
