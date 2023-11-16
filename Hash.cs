using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1;
    static int choice;

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");
            if (playerTurn % 2 == 0)
            {
                Console.WriteLine("Player 2's turn");
            }
            else
            {
                Console.WriteLine("Player 1's turn");
            }
            Console.WriteLine("\n \n");
            Board();

            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                validInput = Int32.TryParse(input, out choice);

                if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    validInput = false;
                }
            }

            if (playerTurn % 2 == 0)
            {
                board[choice - 1] = 'O';
            }
            else
            {
                board[choice - 1] = 'X';
            }

            playerTurn++;
        }
        while (!CheckForWinner() && !CheckForTie());

        Console.Clear();
        Board();

        if (CheckForWinner())
        {
            if (playerTurn % 2 == 0)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }

        Console.ReadLine();
    }

    static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}");
        Console.WriteLine("     |     |      ");
    }

    static bool CheckForWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2]) ||
                (board[i] == board[i + 3] && board[i + 3] == board[i + 6]))
            {
                return true;
            }
        }

        if ((board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6]))
        {
            return true;
        }

        return false;
    }

    static bool CheckForTie()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
