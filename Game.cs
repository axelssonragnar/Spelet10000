using System;
using System.Linq;
using System.Collections.Generic;

namespace _10000
{
    public class Game
    {
        private readonly DiceSet diceSet;
        private readonly ScoreCalculator scoreCalculator;
        private readonly Player[] players;
        public int currentPlayerIndex;
        private ScoreBoard scoreBoard; // Changed type from object to ScoreBoard
        private const int WinningScore = 10000;

        public Game()
        {
            diceSet = new DiceSet(6);
            scoreCalculator = new ScoreCalculator();
            players = new Player[2];
            currentPlayerIndex = 0;
            scoreBoard = new ScoreBoard(); // Initialize ScoreBoard
        }

        public void WelcomePlayers()
        {
            Console.WriteLine("Välkommen till 10 000!");
            Console.Write("Skriv in ditt namn: ");
            string playerName = Console.ReadLine();

            players[0] = new HumanPlayer(playerName);
            players[1] = new AIPlayer("AI-Motståndare");
        }
        public void StartGame()
        {
            WelcomePlayers();

            bool gameOver = false;

            while (!gameOver)
            {
                PlayRound(players[currentPlayerIndex]);
                gameOver = CheckGameOver();

                // Växla tur
                currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            }

            RestartGame();
        }

        public void PlayRound(Player player)
        {
            Console.SetCursorPosition(10, 10);
            Console.WriteLine($"\n{player.name}'s tur!");
            diceSet.Reset();

            while (true)
            {
                Console.SetCursorPosition(0, 1);


                DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates()); // här ritas tärningarna ut med dicegrafics


                bool validSave = false;
                while (!validSave)
                {
                    player.SaveAndRoll(diceSet);
                    bool[] savedStates = diceSet.GetSavedStates(); // kontrollerar sparade tärningar
                    if (savedStates.Any(saved => saved))
                    {
                        validSave = true;
                    }
                    else
                    {
                        Console.WriteLine("Du måste spara minst en tärning för att fortsätta kasta!");
                        Console.WriteLine("Tryck på valfri tangent för att välja igen...");
                        Console.ReadKey();

                        DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates());
                    }
                }


                if (diceSet.GetSavedStates().All(saved => saved)) // kollar ifall alla tärningar är sparade 
                {
                    Console.WriteLine("Du kan inte göra fler kast. Turen är slut.");
                    break;
                }

                // Rulla om osparade tärningar
                diceSet.SaveAndRoll();

                // Visa omrullade tärningar
                Console.WriteLine($"{player.name} rullar om resterande tärningar:");
            }


            int roundScore = scoreCalculator.CalculateScore(diceSet); // räknar ihop rundans poäng
            Console.WriteLine($"{player.name} tjänade {roundScore} poäng denna runda!");
            player.score += roundScore;
            scoreBoard.UpdateScore(player.name, player.score, currentPlayerIndex);

            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();


            diceSet.Reset(); // återställer tärningarna så dem kan rullas om
        }





        public bool CheckGameOver()
        {
            Player leader = players.OrderByDescending(p => p.score).First();

            if (leader.score >= WinningScore)
            {
                Console.WriteLine($"\n{leader.name} har nått {WinningScore} poäng!");
                Console.WriteLine("Avslutande tur ges till den andra spelaren...");

                if (currentPlayerIndex == 0) // Om mänskliga spelaren började
                {
                    PlayRound(players[1]); // AI får en sista tur
                }
                else
                {
                    PlayRound(players[0]); // Människan får en sista tur
                }

                Player winner = players.OrderByDescending(p => p.score).First();
                Console.WriteLine($"\nVinnaren är {winner.name} med {winner.score} poäng!");
                return true; // Spelet är slut
            }
            return false; // Fortsätt spela
        }

        public void RestartGame()
        {
            Console.WriteLine("\nVill du spela igen? (j/n)");
            string input = Console.ReadLine();

            if (input?.ToLower() == "j")
            {
                foreach (var player in players)
                {
                    player.score = 0; // Återställ poäng
                }
                currentPlayerIndex = 0; // Starta med första spelaren igen
                StartGame();
            }
            else
            {
                Console.WriteLine("Tack för att ni spelade 10 000!");
            }
        }
    }
}
