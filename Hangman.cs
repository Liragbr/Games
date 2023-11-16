using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        HangmanGame hangmanGame = new HangmanGame();
        hangmanGame.StartGame();

        while (!hangmanGame.GameOver)
        {
            Console.Clear();
            Console.WriteLine("Hangman Game\n");
            hangmanGame.DisplayWord();
            Console.WriteLine("\nRemaining Attempts: " + hangmanGame.RemainingAttempts);
            Console.WriteLine("Used Letters: " + string.Join(", ", hangmanGame.UsedLetters));

            Console.Write("\nEnter a letter: ");
            char guess = Console.ReadKey().KeyChar;
            hangmanGame.MakeGuess(guess);
        }

        Console.Clear();
        hangmanGame.DisplayResult();
        Console.ReadLine();
    }
}

class HangmanGame
{
    private List<string> wordList = new List<string> { "elephant", "giraffe", "lion", "tiger", "zebra", "monkey", "penguin", "panda", "camel", "hyena", "rhinoceros", "cat", "dog", "bear", "horse", "parrot", "turtle", "dolphin", "crocodile","Komodo dragon", "buffalo", "eagle", "gull", "sheep" };
  
    private string secretWord;
    private char[] guessedWord;
    private HashSet<char> usedLetters;
    private int remainingAttempts;

    public bool GameOver { get; private set; }

    public int RemainingAttempts
    {
        get { return remainingAttempts; }
    }

    public HashSet<char> UsedLetters
    {
        get { return usedLetters; }
    }

    public HangmanGame()
    {
        usedLetters = new HashSet<char>();
        remainingAttempts = 6;
        secretWord = SelectRandomWord();
        guessedWord = new char[secretWord.Length];
        for (int i = 0; i < guessedWord.Length; i++)
        {
            guessedWord[i] = '_';
        }
    }

    private string SelectRandomWord()
    {
        Random random = new Random();
        int index = random.Next(wordList.Count);
        return wordList[index];
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the Hangman Game!");
        Console.WriteLine("Try to guess the animal name.");
    }

    public void DisplayWord()
    {
        Console.WriteLine(string.Join(" ", guessedWord));
    }

    public void MakeGuess(char letter)
    {
        if (Char.IsLetter(letter))
        {
            letter = Char.ToLower(letter);

            if (!usedLetters.Contains(letter))
            {
                usedLetters.Add(letter);

                if (secretWord.Contains(letter))
                {
                    UpdateGuessedWord(letter);
                }
                else
                {
                    remainingAttempts--;

                    if (remainingAttempts == 0)
                    {
                        GameOver = true;
                    }
                }

                if (guessedWord.SequenceEqual(secretWord.ToCharArray()))
                {
                    GameOver = true;
                }
            }
            else
            {
                Console.WriteLine("\nYou've already used this letter. Try another.");
            }
        }
        else
        {
            Console.WriteLine("\nPlease enter a valid letter.");
        }
    }

    private void UpdateGuessedWord(char letter)
    {
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guessedWord[i] = letter;
            }
        }
    }

    public void DisplayResult()
    {
        if (guessedWord.SequenceEqual(secretWord.ToCharArray()))
        {
            Console.WriteLine("Congratulations! You guessed the animal name: " + secretWord);
        }
        else
        {
            Console.WriteLine("You lost! The animal name was: " + secretWord);
        }
    }
}
