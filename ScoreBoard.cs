namespace _10000
{
    public class ScoreBoard
    {
        private const int WinningScore = 10000;

        // Metod som kontrollerar om någon spelare har vunnit
        /*public string CheckWinner(int player1Score, int player2Score)
        {
            Console.WriteLine($"Player1 {player1Score}     Player2 {player2Score}");

            if (player1Score >= WinningScore || player2Score >= WinningScore)
            {
                if (player1Score == player2Score)
                {
                    return "Båda spelarna har nått samma poäng. Det är oavgjort!";
                }
                else if (player1Score > player2Score)
                {
                    return "Spelare 1 har vunnit!";
                }
                else if (player1Score < player2Score)
                {
                    return "Spelare 2 har vunnit!";
                }
                else
                {
                    return "Ingen spelare har nått 10 000 poäng ännu.";
                }
            }
        }*/
        public void UpdateScore(Player player, int score, int currentPlayerIndex)
        {
            player.score += score;
            Console.SetCursorPosition(10, currentPlayerIndex + 20);
            Console.Write($"{player.name} har nu {player.score} poäng.");
        }
    } }

