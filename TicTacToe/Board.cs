using System;

namespace TicTacToe
{
    public class Board
    {
        public String[] Cells { get; set; } = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public void Display()
        {
            Console.Clear();
            
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Cells[1], Cells[2], Cells[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Cells[4], Cells[5], Cells[6]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Cells[7], Cells[8], Cells[9]);
            Console.WriteLine("     |     |     ");
        }
    }
}