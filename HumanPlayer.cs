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
        Console.WriteLine("Välj de tärningar du vill spara, separerade med ','");
    
        while (true)
        {
            try
            {
                // Läs in och justera indexen för att matcha tärningarnas index i listan
                var input = Console.ReadLine();
                var indices = input.Split(',')
                    .Select(num => int.Parse(num.Trim()) - 1) // Justera för 0-baserad indexering
                    .ToArray();

                // Kontrollera att valda index är giltiga
                if (indices.All(i => i >= 0 && i < diceSet.Dice.Count()))
                {
                    diceSet.SaveDices(indices);
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val! Försök igen!");
                }
            }
            catch
            {
                Console.WriteLine("Välj vilka tärningar du vill spara separerade med ','");
            }
        }
    }

}