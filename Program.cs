namespace _10000;

public class Program
{
    static void Main(string[] args)
    {
        Sound PlaySound = new Sound();
        PlaySound.PlaySound("intro");
        
        Rules rules = new Rules();
        rules.DisplayRules();
        
        Game game = new Game();
        game.StartGame();
    }
}