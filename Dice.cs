namespace _10000;
public class Dice
{
    private static Random random = new Random();
    public int Value { get; private set; } = 1; 
    public bool IsSaved { get; set; }  // Bestämmer om tärningen är sparad eller inte
    public void Roll()
    {
        if (!IsSaved)
            Value = random.Next(1, 7);
    }
}