namespace _10000;

public class Rules
{
    public void DisplayRules()
    {
        int x = 50;
        int y = 7;
        Console.SetCursorPosition(x, y);
        Console.Write("        ------REGLER------");
        Console.SetCursorPosition(x, y+1);
        Console.Write("Spelarna turas om att slå sex tärningar.");
        Console.SetCursorPosition(x, y+2);
        Console.Write("För att kasta om resterande tärningar måste minst en tärning sparas");
        Console.SetCursorPosition(x, y+3);
        Console.Write("Spelaren fortsätter slå tills alla tärningar är sparade.");
        Console.SetCursorPosition(x, y+4);
        Console.Write("Målet är att nå minst 10 000 poäng för att vinna.");


    }

    public void DisplayCombinations()
    {
        int x = 85 ; // starting x-position
        int y = 1;  // starting y-position
    
        string[] combinations = {
            "En 1:a = 100 poäng",
            "En 5:a = 50 poäng",
            "En stege 1-6 = 1500 poäng",
            "Tre par = 1000 poäng",
            "3 st 6:or = 600 poäng",
            "4 st sexor = 1,200 poäng",
            "5 st sexor = 2,400 poäng",
            "6 st sexor = 4,800 poäng",
            "3 st femmor = 500 poäng",
            "4 st femmor = 1,000 poäng",
            "5 st femmor = 2,000 poäng",
            "6 st femmor = 4,000 poäng",
            "3 st fyror = 400 poäng",
            "4 st fyror = 800 poäng",
            "5 st fyror = 1,600 poäng",
            "6 st fyror = 3,200 poäng",
            "3 st treor = 300 poäng",
            "4 st treor = 600 poäng",
            "5 st treor = 1,200 poäng",
            "6 st treor = 2,400 poäng",
            "3 st tvåor = 200 poäng",
            "4 st tvåor = 400 poäng",
            "5 st tvåor = 800 poäng",
            "6 st tvåor = 1,600 poäng",
            "3 st ettor = 1,000 poäng",
            "4 st ettor = 2,000 poäng",
            "5 st ettor = 4,000 poäng",
            "6 st ettor = 8,000 poäng"
        };

        for (int i = 0; i < combinations.Length; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.WriteLine(combinations[i]);
        }
    }
}