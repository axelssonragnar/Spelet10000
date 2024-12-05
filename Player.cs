namespace _10000;

// KRAV 6:
// 1: Subtypspolymorfism.
// 2: Vi har valt att använda två sub-klasser till den abstrakta klassen Player.
// 3: Vi vill att olika spelar-typer ska kunna göra ungefär samma saker men på lite olika sätt.

public abstract class Player
{
    public string name { get; private set; }
    public int score { get; set; }

    public Player(string name)
    {
        this.name = name;
        score = 0;
    }
// KRAV 2:
// 1: Overloading av Konstruktor.
// 2: Vi har valt att overloada Player klassens konstruktor.
// 3: Det ger möjlighet att ställa in eventuellt handikapp för den spelare som önskas.
    public Player(string name, int initialScore)
    {
        this.name = name;
        score = initialScore;
    }

    public abstract void RollDice(DiceSet diceSet);
    public abstract void SaveAndRoll(DiceSet diceSet);

    public void PrintScore()
    {
        Console.WriteLine($"{name}: {score} points");
    }
    
}
