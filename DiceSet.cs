namespace _10000;

public class DiceSet
{
    private List<Dice> dice; 
    
    // KRAV 4:
// 1: Objektkomposition.
// 2: Vi har valt att låta DiceSet bestå av en lista med Dice-objekt.
// 3: Det ger ökad modifierbarhet.

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
    public void SaveAndRoll() //kollar vilka tärningar som är osparade och rullar resten igen
    {
        foreach (var die in dice)
        {
            if (!die.IsSaved)
            {
                die.Roll();
            }
        }
    }
    public void Reset()
    {
        foreach (var die in dice)
        {
            die.IsSaved = false; // Återställer tärningarna från sparad status
            die.Roll(); // Rulla tärningen så att nya värden skapas
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