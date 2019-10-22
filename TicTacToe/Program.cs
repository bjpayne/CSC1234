using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();

            Player player1 = new Player {Symbol = "X", DisplayName = "Player 1"};
            
            Player player2 = new Player {Symbol = "O", DisplayName = "Player 2"};
            
            Board board = new Board();
            
            Console.WriteLine(
                "{0} is {1} and {2} is {3}",
                player1.DisplayName,
                player1.Symbol,
                player2.DisplayName,
                player2.Symbol
            );
            
            Int32 nextPlayer = 1;

            Player player;
                
            Int32 isWin = 0;
            
            do
            {
                // Use odd / even counter to determine next player
                player = nextPlayer % 2 == 1 ? player1 : player2;

                String choice = "";

                Int32 cell = 0;

                do
                {
                    board.Display();
            
                    Console.Write("{0}, choose a cell: ", player.DisplayName);

                    choice = Console.ReadLine();
                } while (String.IsNullOrEmpty(choice) || ! Int32.TryParse(choice, out cell));

                cell = Int32.Parse(choice);

                // Set the game cell
                game.Moves[cell] = player.Symbol;
                
                // Set the UI cell
                board.Cells[cell] = game.Moves[cell];
                
                board.Display();
                
                nextPlayer++;
                
                isWin = game.IsWin();
            } while (isWin == 0);

            Console.WriteLine(isWin == 1 ? "{0} has won!" : "Draw!", player.DisplayName);
            Console.Write("Play again? (y/n) ");

            String playAgain = Console.ReadLine();

            if (playAgain.ToLower() != "y")
            {
                Console.WriteLine("Goodbye!");
                
                Environment.Exit(0);
            }

            Main(args);
        }
    }
}
