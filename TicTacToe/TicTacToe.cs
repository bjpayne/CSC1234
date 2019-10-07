using System;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class TicTacToe
    {
        private readonly String[,] gameBoard;

        public TicTacToe()
        {
            this.gameBoard = new String[,] {{"", "", ""}, {"", "", ""}, {"", "", ""}};
        }

        public void Move(Int32 iPosition, Int32 jPosition, Player player)
        {
            this.gameBoard[iPosition, jPosition] = player.Symbol;
        }

        public Boolean IsWin(Player player)
        {
            for (Int32 i = 0; i <= 2; i++)
            {
                for (Int32 j = 0; j <= 2; j++)
                {
                    if (player.Symbol.Equals(this.gameBoard[i,j]))
                    {
                        player.Hits++;
                    }
                }
            }
            
            return player.Hits == 3;
        }
    }
}
