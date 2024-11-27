namespace _10000;

public abstract class Player
{
    public string name { get; private set; }
    public int score { get; set; }

    public Player(string name)
    {
        this.name = name;
        score = 0;
    }

    public abstract void RollDice(DiceSet diceSet);
    public abstract void SaveAndRoll(DiceSet diceSet);

    public void PrintScore()
    {
        Console.WriteLine($"{name}: {score} points");
    }
    
}
