namespace Hangman;

public class Hangman
{
    private const int MaxAttempts = 5;
    private int remainingAttempts;
    private HashSet<char> usedChars = new();

    public void NewGame()
    {
        remainingAttempts = MaxAttempts;
        usedChars.Clear();

        PrintWithColor("Selecting word...", ConsoleColor.Green);
        Thread.Sleep(500);

        var word = SelectRandomWord();
        var revealed = new string('_', word.Length).ToCharArray();

        RunGame(word, revealed);
    }

    private string SelectRandomWord()
    {
        string[] words = { "apple", "chair", "house", "water", "music", "paper", "pizza", "green", "table", "mouse" };
        return words[new Random().Next(words.Length)];
    }

    private void RunGame(string word, char[] revealed)
    {
        while (remainingAttempts > 0 && revealed.Contains('_'))
        {
            PrintWithColor("Guess: " + new string(revealed), ConsoleColor.Gray);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                PrintWithColor("Enter a valid single letter.", ConsoleColor.Red);
                continue;
            }

            char guess = char.ToLower(input[0]);

            if (!usedChars.Add(guess))
            {
                PrintWithColor("You already used that letter.", ConsoleColor.Red);
                continue;
            }

            if (word.Contains(guess))
            {
                for (int i = 0; i < word.Length; i++)
                    if (word[i] == guess)
                        revealed[i] = guess;

                continue;
            }

            remainingAttempts--;
            PrintWithColor($"Wrong. Attempts left: {remainingAttempts}", ConsoleColor.Red);
        }

        if (revealed.Contains('_'))
            PrintWithColor($"You lost! The word was: {word}", ConsoleColor.Red);
        else
            PrintWithColor("Congrats! You guessed the word!", ConsoleColor.Green);
    }

    private static void PrintWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
