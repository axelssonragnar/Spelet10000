using System;
using System.Collections.Generic;
namespace _10000;

public class Program
{
    public static void Main(string[] args)
    {
        bool istrue = true;
        while (istrue)
        {
            
        DiceSet diceSet = new DiceSet(6);
        diceSet.RollAllDice();
        Console.WriteLine("Tärningarna efter att alla rullats:");
        DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates());
        ScoreCalculator roll = new ScoreCalculator();
        int initialScore = roll.CalculateScore(diceSet);
        Console.WriteLine($"Poäng för första kastet: {initialScore}");
        Console.ReadKey();
        Console.Clear();
        }
}
}