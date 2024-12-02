namespace _10000
{
    public class Game
    {
        private readonly DiceSet diceSet;
        private readonly ScoreCalculator scoreCalculator;
        private readonly Player[] players;
        private int currentPlayerIndex;
        private ScoreBoard scoreBoard; 
        private const int WinningScore = 10000;

        public Game()
        {
            diceSet = new DiceSet(6);
            scoreCalculator = new ScoreCalculator(diceSet);  
            players = new Player[2];
            currentPlayerIndex = 0;
            scoreBoard = new ScoreBoard(); 
        }

        public void WelcomePlayers()
        {
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Välkommen till 10 000!");
            Console.SetCursorPosition(15, 11);
            Console.Write("Skriv in ditt namn: ");
            string playerName = Console.ReadLine();
            Console.Clear();
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
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("                                                                      ");
                currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            }

            RestartGame();
        }

        public void PlayRound(Player player)
        {
            Console.SetCursorPosition(10, 10);
            Console.WriteLine($"\n{player.name}'s tur!                      ");
            diceSet.Reset();

            while (true)
            {
                Console.SetCursorPosition(0, 2);
                
                int numDice = 6;
                int scrambleTimes = 10;
                int delay = 100;
                bool[] savedStates = diceSet.GetSavedStates();
                Rules combo = new Rules();
                combo.DisplayCombinations();
                DiceGrafics.ScrambleDice(numDice, savedStates, scrambleTimes, delay, diceSet);
                Console.SetCursorPosition(0, 0);
                DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates()); // här ritas tärningarna ut med dicegrafics


                bool validSave = false;
                while (!validSave)
                {
                    player.SaveAndRoll(diceSet);
                    savedStates = diceSet.GetSavedStates(); // kontrollerar sparade tärningar
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
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("                                    ");
                    break;
                }

                // Rulla om osparade tärningar
                diceSet.SaveAndRoll();
            }

            // Här använder vi den nya Score-egenskapen istället för den gamla CalculateScore-metoden
            int roundScore = scoreCalculator.Score; // Den nya metoden för att beräkna poängen
            Console.SetCursorPosition(10, 15);
            Console.WriteLine($"{player.name} tjänade {roundScore} poäng denna runda!");
            Console.ReadKey();
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("                                                                       ");
            player.score += roundScore;
            scoreBoard.UpdateScore(player.name, player.score, currentPlayerIndex);

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
                Sound PlaySound = new Sound();
                PlaySound.PlaySound("Winning");
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
                Console.Clear();
                StartGame();
            }
            else
            {
                Console.WriteLine("Tack för att ni spelade 10 000!");
            }
        }
    }
}
