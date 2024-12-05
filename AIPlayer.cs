namespace _10000;

public class AIPlayer : Player
{
    public AIPlayer(string name) : base(name) // skapar en AI-spelare med Playerklassens konstruktor
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
        var diceArray = diceSet.Dice.ToArray();


        foreach (var die in diceArray)
        {
            if (!die.IsSaved && (die.Value == 1 || die.Value == 5))
            {
                Thread.Sleep(1000);
                diceToSave.Add(index);
            }
            index++;
        }
        
        if (!diceToSave.Any())
        {
            index = 0;
            foreach (var die in diceArray)
            {
                if (!die.IsSaved)
                {
                    diceToSave.Add(index);
                    break;
                }
                index++;
            }
        }
        
        if (!diceToSave.Any())
        {
            Console.WriteLine($"{name} är färdig med sin tur.");
            return;
        }
        diceSet.SaveDices(diceToSave.ToArray());
        diceSet.SaveAndRoll();
    }
}