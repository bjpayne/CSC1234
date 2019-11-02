using System;
using System.Reflection;
using System.Threading;

namespace AccountInheritanceHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String quit = "n";

                do
                {
                    Console.WriteLine("Welcome to XYZ Bank! Please select one of the following options:");

                    String account = "0";
                    
                    while (account != "1" && account != "2")
                    {
                        Console.WriteLine("1: Checking Account");
                        Console.WriteLine("2: Savings Account");
                            
                        account = Console.ReadLine();
                    }

                    switch (account)
                    {
                        case "1":
                            CheckingAccountServices();
                            break;
                        case "2":
                            SavingsAccountServices();
                            break;
                        default:
                            Console.WriteLine("All set? (y/N)");
                            break;
                    }

                    quit = Console.ReadLine();

                    if (quit.Length == 0)
                    {
                        quit = "n";
                    }
                } while (quit.ToLower() != "y");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void CheckingAccountServices()
        {
            String done = "n";

            while (done.ToLower() == "n")
            {
                try
                {
                    CheckingAccount checkingAccount = new CheckingAccount(2500m, 12m);
                    
                    Console.WriteLine($"Your checking account balance is {checkingAccount.Balance}.");
                    Console.WriteLine("How can we help you?");

                    String action = "0";

                    while (action != "1" && action != "2")
                    {
                        Console.WriteLine(new String('-', 12));
                        Console.WriteLine("1. Deposit Funds");
                        Console.WriteLine("2. Withdraw Funds");

                        action = Console.ReadLine();
                    }

                    if (action == "1")
                    {
                        Console.WriteLine("How much would you like to deposit?");

                        String userAmount = Console.ReadLine();

                        if (Decimal.TryParse(userAmount, out Decimal amount))
                        {
                            checkingAccount.Credit(amount);
                        }
                    }

                    if (action == "2")
                    {
                         Console.WriteLine("How much would you like to withdraw?");
 
                         String userAmount = Console.ReadLine();
 
                         if (Decimal.TryParse(userAmount, out Decimal amount))
                         {
                             checkingAccount.Debit(amount);
                         }                       
                    }
                    
                    Console.WriteLine("All set with your checking account? (n/Y)");

                    done = Console.ReadLine();

                    if (done.Length == 0)
                    {
                        done = "y";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                    Thread.Sleep(3000);
                             
                    CheckingAccountServices();
                }   
            }
        }

        private static void SavingsAccountServices()
        {
             String done = "n";
 
             while (done.ToLower() == "n")
             {
                 try
                 {
                     SavingsAccount savingsAccount = new SavingsAccount(2500m, 1.25m);
                     
                     Console.WriteLine($"Your savings account balance is {savingsAccount.Balance}.");
                     Console.WriteLine("How can we help you?");
 
                     String action = "0";
 
                     while (action != "1" && action != "2")
                     {
                         Console.WriteLine(new String('-', 12));
                         Console.WriteLine("1. Deposit Funds");
                         Console.WriteLine("2. Withdraw Funds");
 
                         action = Console.ReadLine();
                     }
 
                     if (action == "1")
                     {
                         Console.WriteLine("How much would you like to deposit?");
 
                         String userAmount = Console.ReadLine();
 
                         if (Decimal.TryParse(userAmount, out Decimal amount))
                         {
                             Decimal interest = savingsAccount.CalculateInterest();

                             amount += interest;
                             
                             savingsAccount.Credit(amount);
                         }
                     }
 
                     if (action == "2")
                     {
                          Console.WriteLine("How much would you like to withdraw?");
  
                          String userAmount = Console.ReadLine();
  
                          if (Decimal.TryParse(userAmount, out Decimal amount))
                          {
                              savingsAccount.Debit(amount);
                          }                       
                     }
                     
                     Console.WriteLine("All set with your savings account? (n/Y)");
 
                     done = Console.ReadLine();
 
                     if (done.Length == 0)
                     {
                         done = "y";
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     
                     Thread.Sleep(3000);
                              
                     CheckingAccountServices();
                 }   
             }           
        }
    }
}