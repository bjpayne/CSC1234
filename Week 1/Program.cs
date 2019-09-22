using System;

namespace AccountTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Ben Payne");

            account.DetermineUserAction();
        }

    }

}
