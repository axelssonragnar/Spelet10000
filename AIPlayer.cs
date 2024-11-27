namespace _10000;

public class AIPlayer : Player
{
    public AIPlayer(string name) : base(name) // skapar en mänsklig spelare med Playerklassens konstruktor
    {
    }

    public override void RollDice(DiceSet diceSet) 
    {
        Console.WriteLine($"{name} rullar tärningarna!");
        diceSet.RollAllDice();
    }

    public override void SaveAndRoll(DiceSet diceSet)
    {
        var diceToSave = new List<int>();
        int index = 0;
        foreach (var die in diceSet.Dice)
        {
            if (die.Value == 1 || die.Value == 5)
            {
                diceToSave.Add(index);
            }
            index++;
        }
        
        diceSet.SaveDices(diceToSave.ToArray());
        diceSet.SaveAndRoll();
    }
}