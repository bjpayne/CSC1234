using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            
            Player player1 = new Player("X", "Player 1");
            
            Player player2 = new Player("O", "Player 2");
            
            Board board = new Board();
            
            board.Display();
            
            Console.WriteLine("Player 1 is X and Player 2 is O");
            
            Int32 nextPlayer = 1;

            Player player;
                
            Int32 isWin = 0;
            
            do
            {
                player = nextPlayer % 2 == 1 ? player1 : player2;
                
                Console.Write("{0}, choose a cell: ", player.DisplayName);

                String choice = Console.ReadLine();

                Int32 cell = Int32.Parse(choice);

                game.Move(cell, player);
                
                board.SetCell(player, cell);
                
                board.Display();
                
                nextPlayer++;
                
                isWin = game.IsWin();
            } while (isWin == 0);

            Console.WriteLine(isWin == 1 ? "{0} has won!" : "Draw!", player.DisplayName);
            Console.Write("Play again? (y/n) ");

            String playAgain = Console.ReadLine();

            if (playAgain.ToLower() != "y")
            {
                Environment.Exit(0);
            }

            Main(args);
        }
    }
}
