using System;

namespace TicTacToe
{
    public class Player
    {
        private String symbol;

        private Int32 hits;

        public String Symbol { get; set; }

        public Int32 Hits { get; set; }

        public Player(String symbol)
        {
            this.symbol = symbol;

            this.hits = 0;
        }
    }
}