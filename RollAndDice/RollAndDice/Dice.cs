namespace RollAndDice;

public class Dice
{
    private static int _diceSize = 6;
    private static int _dicesToRoll = 1;

    public static void Setup()
    {
        PrintWithColor("=== Dice Roller ===", ConsoleColor.Green);

        PrintWithColor("Choose dice type (4, 6, 8, 10, 12, 20) [default is 6]", ConsoleColor.Gray);
        HandleDiceType();

        PrintWithColor("How many dices do you want to roll? (default is 1)", ConsoleColor.Gray);
        HandleDicesAmount();

        PrintWithColor("Enable rules? (y/n)", ConsoleColor.Gray);
        SetupDiceRules();

    }
    private static List<int> Roll(int maxValue, int amountOfDices, int diceRule)
    {
        List<int> diceResult = [];
        Random random = new();

        for (int i = 0; i < amountOfDices; i++)
        {
            diceResult.Add(random.Next(1, maxValue + 1));
        }

        switch (diceRule)
        {
            case 1:
                for (int i = 0; i < diceResult.Count; i++)
                {
                    while (diceResult[i] == 1)
                    {
                        PrintWithColor($"REROLLING THE {i + 1}th DICE!", ConsoleColor.Red);

                        var newRoll = random.Next(1, maxValue + 1);
                        diceResult[i] = newRoll;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < diceResult.Count; i++)
                {
                    while (diceResult[i] >= maxValue)
                    {
                        PrintWithColor($"EXPLODING THE {i + 1}th DICE!", ConsoleColor.Red);

                        var extra = random.Next(1, maxValue + 1);
                        diceResult[i] += extra;

                        if (extra < maxValue)
                            break; // 
                    }
                }
                break;
        }

        PrintWithColor("Results: " + string.Join(", ", diceResult), ConsoleColor.Green);

        return diceResult;
    }
    private static void HandleDiceType()
    {
        var input = Console.ReadLine();
        int diceSize;

        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out diceSize)) _diceSize = diceSize;

        HashSet<int> avaliableDiceSizes = [4, 6, 8, 10, 12, 20]; 
        if (!avaliableDiceSizes.Contains(_diceSize))
        {
            PrintError("Size of the dice received is not avaliable. Please, use: 4, 6, 8, 10, 12, 20");
            Console.Clear();
            Setup();

            return;
        }
    }
    private static void HandleDicesAmount()
    {
        var input = Console.ReadLine();
        int dicesToRoll;

        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out dicesToRoll)) _dicesToRoll = dicesToRoll;
    }
    private static void SetupDiceRules()
    {
        var input = Console.ReadLine();

        switch (input)
        {
            case "y" or "Y":
                PrintWithColor("Which rule?", ConsoleColor.Gray);
                PrintWithColor("1. Reroll 1s (replace)", ConsoleColor.Red);
                PrintWithColor("2. Exploding when the max value was rolled up (add)", ConsoleColor.Red);

                HandleDiceRules();
                break;
            case "n" or "N":
                Roll(_diceSize, _dicesToRoll, 0);
                break;
            default:
                Console.Clear();
                PrintError("This wasn't a option.");
                Setup();
                break;
        }
    }
    private static void HandleDiceRules() 
    {
        var input = Console.ReadLine();

        switch (input) 
        {
            case "1":
                Roll(_diceSize, _dicesToRoll, 1);
                break;
            case "2":
                Roll(_diceSize, _dicesToRoll, 2);
                break;
            default:
                Roll(_diceSize, _dicesToRoll, 1);
                break;
        }
    }
    private static void PrintWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    private static void PrintError(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
