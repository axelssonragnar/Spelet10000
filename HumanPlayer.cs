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
        Console.WriteLine("Välj de tärningar du vill spara, separerade med ',");

        while (true)
        {
            try
            {
                // Läs in och justera indexen för att matcha tärningarnas index i listan
                var input = Console.ReadLine();
                var indices = input.Split(',')
                    .Select(num => int.Parse(num.Trim()) - 1) 
                    .ToArray();

                var diceArray = diceSet.Dice.ToArray();

                // Kontrollera att alla valda index är giltiga
                if (!indices.All(i => i >= 0 && i < diceArray.Length))
                {
                    Console.WriteLine("Ogiltiga index! Välj tärningar mellan 1 och {0}.", diceArray.Length);
                    continue;
                }

                // Kontrollera att minst en tärning som inte är sparad väljs
                if (!indices.Any(i => !diceArray[i].IsSaved))
                {
                    Console.WriteLine("Du måste välja minst en tärning som inte är sparad. Försök igen!");
                    continue;
                }

                // Kontrollera om spelaren försöker spara en redan sparad tärning
                if (indices.Any(i => diceArray[i].IsSaved))
                {
                    Console.WriteLine("Du kan inte välja en tärning som redan är sparad. Försök igen!");
                    continue;
                }

                // Om allt är korrekt, spara tärningarna och avsluta
                diceSet.SaveDices(indices);
                break;
            }
            catch
            {
                Console.WriteLine(
                    "Ogiltigt format! Försök igen!");
            }
        }
    }
}