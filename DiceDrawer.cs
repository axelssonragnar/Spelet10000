using System;
using System.Linq;

namespace _10000
{
    public static class DiceGrafics
    {
        private static readonly string[][] Dots = new string[][]
        {
            new[] { "╔═════════╗", "║         ║", "║    o    ║", "║         ║", "╚═════════╝" },
            new[] { "╔═════════╗", "║    o    ║", "║         ║", "║    o    ║", "╚═════════╝" },
            new[] { "╔═════════╗", "║    o    ║", "║    o    ║", "║    o    ║", "╚═════════╝" },
            new[] { "╔═════════╗", "║  o   o  ║", "║         ║", "║  o   o  ║", "╚═════════╝" },
            new[] { "╔═════════╗", "║  o   o  ║", "║    o    ║", "║  o   o  ║", "╚═════════╝" },
            new[] { "╔═════════╗", "║  o   o  ║", "║  o   o  ║", "║  o   o  ║", "╚═════════╝" }
        };

        public static void DrawDice(int[] diceValues, bool[] savedDice)
        {
            
            Console.WriteLine(string.Join("     ", Enumerable.Range(1, diceValues.Length).Select(i => $"   ({i})  "))); // visar nummer över tärningarna

            for (int row = 0; row < 5; row++) // loopar genom och skriver ut varje rad 
            {
                for (int i = 0; i < diceValues.Length; i++)
                {
                    if (savedDice[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(Dots[diceValues[i] - 1][row] + "  "); // mellanrummet mellan tärningar

                }

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}