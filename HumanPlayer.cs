namespace _10000;

public class HumanPlayer : Player
{
    
    public HumanPlayer(string name) : base(name) // skapar en mänsklig spelare med Playerklassens konstruktor
    {
    }

    public override void RollDice(DiceSet diceSet) 
    {
        Console.WriteLine($"{name} rullar tärningarna!");
        diceSet.RollAllDice();
    }

    public override void SaveAndRoll(DiceSet diceSet)
    {
        Console.WriteLine("Välj dem tärningar du vill spara separerade med ',' ");
        var input = Console.ReadLine();
        var indices = input.Split(',').Select(int.Parse).ToArray();
        diceSet.SaveDices(indices);
    }
}