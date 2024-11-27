namespace _10000;

public class DiceSet
{
    private List<Dice> dice;

    public DiceSet(int count)
    {
        dice = new List<Dice>();
        for (int i = 0; i < count; i++)
        {
            dice.Add(new Dice());
        }
    }
    public int[] GetValues()   // hämtar värdena på tärningarna och returnerar dem som en array
    {
        List<int> values = new List<int>(); 
    
        foreach (var dice in dice)
        {
            values.Add(dice.Value);
        }
    
        return values.ToArray();
    }
    public void RollAllDice() // metod som ska rulla alla tärningar i början av turen
    {
        foreach (var die in dice)
        {
            die.Roll();
        }
    }
    public void SaveDices(int[] indices) // metod för att spara tärningar 
    {
        foreach (int i in indices)
        {
            dice[i].IsSaved = true;
        }
    }
    public void SaveAndRoll() // metod som kollar vilka tärningar som är sparade och rullar sedan resten
    {
        var unsavedDice = new List<Dice>();
        foreach (var dice in dice)
        {
            if (!dice.IsSaved) 
            {
                unsavedDice.Add(dice);
            }
        }
        foreach (var dice in unsavedDice)
        {
            dice.Roll();
        }
    }
    public bool[] GetSavedStates() // lägger till denna metod
    {
        return dice.Select(d => d.IsSaved).ToArray();
    }
    public IEnumerable<Dice> Dice
    {
        get
        {
            return dice;
        }
    }
}