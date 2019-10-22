using System;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class TicTacToe
    {
        public String[] Moves { get; set; } = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public Int32 IsWin()
        {
            // First row matches
            if (Moves[1] == Moves[2] && Moves[2] == Moves[3])
            {
                return 1;
            }
            
            // Second row matches
            if (Moves[4] == Moves[5] && Moves[5] == Moves[6])
            {
                return 1;
            }
            
            // Third row matches
            if (Moves[6] == Moves[7] && Moves[7] == Moves[8])
            {
                return 1;
            }

            // First column matches
            if (Moves[1] == Moves[4] && Moves[4] == Moves[7])
            {
                return 1;
            }
            
            // Second column matches
            if (Moves[2] == Moves[5] && Moves[5] == Moves[8])
            {
                return 1;
            }
            
            // Third column matches
            if (Moves[3] == Moves[6] && Moves[6] == Moves[9])
            {
                return 1;
            }

            // Top left to bottom right diagonal matches
            if (Moves[1] == Moves[5] && Moves[5] == Moves[9])
            {
                return 1;
            }
            
            // top right to bottom left diagonal matches
            if (Moves[3] == Moves[5] && Moves[5] == Moves[7])
            {
                return 1;
            }

            // All cells are filled but no row column or diagonal match. Game is a draw.
            if (Moves[1]!= "1" &&
                Moves[2]!= "2" &&
                Moves[3]!= "3" &&
                Moves[4]!= "4" &&
                Moves[5]!= "5" &&
                Moves[6]!= "6" &&
                Moves[7]!= "7" &&
                Moves[8]!= "8" &&
                Moves[9]!= "9"
            )
            {
                return -1;
            }

            // No win, or draw...keep playing.
            return 0;
        }
    }
}
