namespace _10000
{
    public class ScoreCalculator
    {
        // Privat fält för DiceSet
        private DiceSet DiceSet { get; }

        // Konstruktor som tar ett DiceSet
        public ScoreCalculator(DiceSet diceSet)
        {
            DiceSet = diceSet ?? throw new ArgumentNullException(nameof(diceSet));
        }

        // Computed property för beräknad poäng
        public int Score
        {
            get
            {
                int[] diceRolls = DiceSet.GetValues();

                // stege (1-6)
                if (diceRolls.Distinct().Count() == 6)
                {
                    return 1500;
                }

                // tre par
                var groupedDice = diceRolls.GroupBy(x => x).ToArray();
                if (groupedDice.Length == 3 && groupedDice.All(g => g.Count() == 2))
                {
                    return 1000;
                }

                int score = 0;

                // kollar triss, 4-, 5- och 6-tal
                foreach (var group in groupedDice)
                {
                    int value = group.Key;
                    int count = group.Count();

                    score += value switch
                    {
                        1 => count switch
                        {
                            3 => 1000,
                            4 => 2000,
                            5 => 4000,
                            6 => 8000,
                            _ => count * 100 // 1:or = 100 poäng vardera
                        },
                        5 => count switch
                        {
                            3 => 500,
                            4 => 1000,
                            5 => 2000,
                            6 => 4000,
                            _ => count * 50 // 5:or = 50 poäng vardera
                        },
                        6 => count switch
                        {
                            3 => 600,
                            4 => 1200,
                            5 => 2400,
                            6 => 4800,
                            _ => 0
                        },
                        4 => count switch
                        {
                            3 => 400,
                            4 => 800,
                            5 => 1600,
                            6 => 3200,
                            _ => 0
                        },
                        3 => count switch
                        {
                            3 => 300,
                            4 => 600,
                            5 => 1200,
                            6 => 2400,
                            _ => 0
                        },
                        2 => count switch
                        {
                            3 => 200,
                            4 => 400,
                            5 => 800,
                            6 => 1600,
                            _ => 0
                        },
                        _ => 0
                    };
                }

                return score;
            }
        }
    }
}
