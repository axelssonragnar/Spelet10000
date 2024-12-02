using System;
using System.Collections.Generic;
namespace _10000;

public class Program
{
    static void Main(string[] args)
    {
        
       
        Sound PlaySound = new Sound();
        PlaySound.PlaySound("intro");
                
        Game game = new Game();
        game.StartGame();

    }
}