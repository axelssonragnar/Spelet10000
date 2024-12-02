namespace _10000;

public static class DiceGrafics
{
    private static readonly string[][] Dots = new string[][]
    {
        new[] { "╔═════════╗", "║         ║", "║    o    ║", "║         ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║    o    ║", "║         ║", "║    o    ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║    o    ║", "║    o    ║", "║    o    ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  o   o  ║", "║         ║", "║  o   o  ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  o   o  ║", "║    o    ║", "║  o   o  ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  o   o  ║", "║  o   o  ║", "║  o   o  ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║         ║", "║    ?    ║", "║         ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║    ?    ║", "║         ║", "║    ?    ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║    ?    ║", "║    ?    ║", "║    ?    ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  ?   ?  ║", "║         ║", "║  ?   ?  ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  ?   ?  ║", "║    ?    ║", "║  ?   ?  ║", "╚═════════╝" },
        new[] { "╔═════════╗", "║  ?   ?  ║", "║  ?   ?  ║", "║  ?   ?  ║", "╚═════════╝" }
    };

    public static void ScrambleDice(int numDice, bool[] savedDice, int scrambleTimes, int delay, DiceSet diceSet)
    {
        Sound PlaySound = new Sound();
        PlaySound.PlaySound("DiceThrow");
       
        Random random = new Random();
        for (int t = 0; t < scrambleTimes; t++)
        {
         
            Console.SetCursorPosition(0, 1);
            for (int row = 0; row < 5; row++)
            {
                var diceValues = diceSet.GetValues();
                for (int i = 0; i < numDice; i++)
                {
                    if (savedDice[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        int savedValue = diceValues[i] - 1;
                        Console.Write(Dots[savedValue][row] + "  "); // Visa korrekt när sparad (exempel med första grafik)
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        int randomIndex = random.Next(6, 12); // Rätt intervall för frågor
                        Console.Write(Dots[randomIndex][row] + "  ");
                    }
                }
                Console.WriteLine();
            }
            Thread.Sleep(delay);
        }
    }

    public static void DrawDice(int[] diceValues, bool[] savedDice)
    {
        Console.WriteLine(string.Join("     ", Enumerable.Range(1, diceValues.Length).Select(i => $"   ({i})  ")));

        for (int row = 0; row < 5; row++)
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
                Console.Write(Dots[diceValues[i] - 1][row] + "  ");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}