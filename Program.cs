namespace _10000;

public class Program
{
    static void Main(string[] args)
    {
        Sound playSound = new Sound();
        DiceSet diceSet = new DiceSet(6);
        ScoreCalculator scoreCalculator = new ScoreCalculator(diceSet);
        ScoreBoard scoreBoard = new ScoreBoard();
        Player player1 = new HumanPlayer("Human");
        Player player2 = new AIPlayer("AI-Motståndare");
        Game game = new Game(diceSet, scoreCalculator, scoreBoard, player1, player2);
        Rules rules = new Rules();
        rules.DisplayRules();
        playSound.PlaySound("intro");
        game.StartGame();
    }
}