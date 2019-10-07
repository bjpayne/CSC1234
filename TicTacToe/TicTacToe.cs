using System;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class TicTacToe
    {
        private readonly Int32[,] gameBoard;

        private String[,] moves;

        public TicTacToe()
        {
            this.gameBoard = new Int32[,] {
				{0, 1, 2},
				{3, 4, 5},
				{6, 7, 8},
				{0, 3, 6},
				{1, 4, 7},
				{2, 5, 8},
				{0, 4, 8},
				{2, 4, 6},
			};
        }

        public void Move(Int32 iPosition, Int32 jPosition, Player player)
        {
            this.moves[iPosition, jPosition] = player.Symbol;
        }

        public Boolean IsWin(Player player)
        {
            Boolean isWin = false;
            
            for (Int32 i = 0; i < 8; i++)
            {
                Int32 cell1 = gameBoard[i, 0];
                Int32 cell2 = gameBoard[i, 1];
                Int32 cell3 = gameBoard[i, 2];

                if (moves[i, 0] == "" || moves[i, 1] == "" || moves[i, 2] == "")
                {
                    continue;
                }

                if (moves[i, 0] == player.Symbol && 
                    moves[i, 1] == player.Symbol && 
                    moves[i, 2] == player.Symbol)
                {
                    isWin = true;

                    break;
                }
            }

            return isWin;
        }
    }
}
