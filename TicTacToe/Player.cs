using System;

namespace TicTacToe
{
    public class Player
    {
        public String Symbol { get; set; }

        public String DisplayName { get; set; }

        public Player(String symbol, String displayName)
        {
            Symbol = symbol;

            DisplayName = displayName;
        }
    }
}