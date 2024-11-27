namespace _10000

{
    public class ScoreCalculator
    {
        // Metod för att beräkna poäng
        public int CalculateScore(DiceSet diceSet)
        {
            int[] diceRolls = diceSet.GetValues();
            // Kontrollera om det är en stege (1-6)
            if (diceRolls.Distinct().Count() == 6 /* && diceRolls.OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 })*/)
            {
                return 1500;
            }

            // Kontrollera om det är tre par
            var groupedDice = diceRolls.GroupBy(x => x).ToArray();
            if (groupedDice.Length == 3 && groupedDice.All(g => g.Count() == 2))
            {
                return 1000;
            }

            int score = 0;

            // Poäng för antal av samma siffra
            foreach (var group in groupedDice)
            {
                int value = group.Key;
                int count = group.Count();

                switch (value)
                {
                    case 1:
                        score += count switch
                        {
                            3 => 1000,
                            4 => 2000,
                            5 => 4000,
                            6 => 8000,
                            _ => count * 100 // 1:or = 100 poäng vardera
                        };
                        break;

                    case 5:
                        score += count switch
                        {
                            3 => 500,
                            4 => 1000,
                            5 => 2000,
                            6 => 4000,
                            _ => count * 50 // 5:or = 50 poäng vardera
                        };
                        break;

                    case 6:
                        score += count switch
                        {
                            3 => 600,
                            4 => 1200,
                            5 => 2400,
                            6 => 4800,
                            _ => 0
                        };
                        break;

                    case 4:
                        score += count switch
                        {
                            3 => 400,
                            4 => 800,
                            5 => 1600,
                            6 => 3200,
                            _ => 0
                        };
                        break;

                    case 3:
                        score += count switch
                        {
                            3 => 300,
                            4 => 600,
                            5 => 1200,
                            6 => 2400,
                            _ => 0
                        };
                        break;

                    case 2:
                        score += count switch
                        {
                            3 => 200,
                            4 => 400,
                            5 => 800,
                            6 => 1600,
                            _ => 0
                        };
                        break;
                }
            }

            return score;
        }

    }
}
