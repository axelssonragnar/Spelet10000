using System;
using System.Collections.Generic;
namespace _10000;

public class Program
{
    public static void Main(string[] args)
    {
        DiceSet diceSet = new DiceSet(6);
        diceSet.RollAllDice();
        Console.WriteLine("Tärningarna efter att alla rullats:");
        DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates());
        ScoreCalculator roll = new ScoreCalculator();
        int initialScore = roll.CalculateScore(diceSet);
        Console.WriteLine($"Poäng för första kastet: {initialScore}");
        Console.WriteLine("Välj dem tärningar du vill spara separerade med ',' ");
        var input = Console.ReadLine();
        var indices = input.Split(',').Select(int.Parse).ToArray();
        Console.Clear();
        diceSet.SaveDices(indices);
        diceSet.RollAllDice();
        Console.WriteLine("osparade tärningar rullas om");
        DiceGrafics.DrawDice(diceSet.GetValues(), diceSet.GetSavedStates());
        int newScore = roll.CalculateScore(diceSet);
        Console.WriteLine($"Poäng efter omlottning: {newScore}");
        Console.WriteLine("hallå");
    }
}