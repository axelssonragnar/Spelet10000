using System;
using System.Collections.Generic;
namespace _10000;

public class Program
{
    static void Main(string[] args)
    {
        Sound winningSound = new Sound();
        winningSound.WinningSound();
        Thread.Sleep(5000);  // Wait for sound to finish. Behövs här eftersom ljuden ligger direkt efter varandra
        Sound diceThrowSound = new Sound();
        diceThrowSound.DiceThrowSound();
        Game game = new Game();
        game.StartGame();
    }
}