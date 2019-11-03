using System;
using System.Collections.Generic;
using System.Threading;

namespace AccountInheritanceHierarchy
{
    class Program
    {
        private static readonly CheckingAccount CheckingAccount = new CheckingAccount(
            1200m, 
            10m
        );
        
        private static readonly SavingsAccount SavingsAccount = new SavingsAccount(
            15000m,
            1.25m
        );

        static void Main(String[] args)
        {
            try
            {
                String action = "0";

                String[] actions = {"1", "2", "3"};

                String[] prompts = {"1: Checking Account", "2: Savings Account", "3: Exit"};

                while (! Array.Exists(actions, element => element == action.ToLower()))
                {
                    Console.Clear();

                    Console.WriteLine("Welcome to XYZ Bank! Please choose which account you'd like to manage:");

                    RequestUserInput(prompts);

                    action = Console.ReadLine();
                }

                switch (action)
                {
                    case "1":
                        CheckingAccountServices();

                        break;
                    case "2":
                        SavingsAccountServices();

                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        
                        Console.Clear();

                        Environment.Exit(0);

                        break;
                    default:
                        Environment.Exit(1);

                        break;
                }

                Environment.Exit(2);
            }
            catch (Exception)
            {
                Console.WriteLine("Your request could not be completed. Please try again.");

                Main(args);
            }
        }

        private static void CheckingAccountServices()
        {
            while (true)
            {
                try
                {
                    String action = PromptForAccountAction(CheckingAccount, "checking");

                    Boolean actionSucceeded = false;

                    while (!actionSucceeded)
                    {
                        try
                        {
                            PerformAccountAction(CheckingAccount, action);

                            if (action == "1" || action == "2")
                            {
                                Console.WriteLine($"You were assessed a {CheckingAccount.AccountFee:C} for this transaction.");
                                
                                Thread.Sleep(1500);
                            }

                            actionSucceeded = true;
                        }
                        catch (Exception e)
                        {
                            HandleActionException(e);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Your request could not be completed. Please try again.");
                }   
            }
        }

        private static void SavingsAccountServices()
        {
            while (true)
            {
                try
                {
                    String action = PromptForAccountAction(SavingsAccount, "savings");
                    
                    Boolean actionSucceeded = false;
                    
                    while (!actionSucceeded)
                    {
                        try
                        {
                            PerformAccountAction(SavingsAccount, action);
                            
                            /**
                             * When depositing into the savings account check if the user would like to deposit their
                             * monthly interest. 
                             */
                            if (action == "1")
                            {
                                String response = "";

                                String[] responses = {"y", "n"};
                                                
                                while (! Array.Exists(responses, element => element == response.ToLower()))
                                {
                                    RequestUserInput("Would you like to deposit your monthly interest? (y/n)");
                                    
                                    response = Console.ReadLine();
                                };

                                if (response == "y")
                                {
                                    Decimal interest = SavingsAccount.CalculateInterest();
                                    
                                    SavingsAccount.Credit(interest);
                                    
                                    Console.WriteLine($"You've earned {interest:C} in interest.");
                                
                                    Thread.Sleep(2000);
                                }
                            }
                    
                            actionSucceeded = true;
                        }
                        catch (Exception e)
                        {
                            HandleActionException(e);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Your request could not be completed. Please try again.");
                }
            }
        }

        private static void HandleActionException(Exception e)
        {
            Console.WriteLine(e.Message);

            Thread.Sleep(1500); // Pause so the user has time to see the error.
        }

        private static void DisplayInitialAccountDetails(Account account, String accountType, Int32 initialDisplay)
        {
            Console.Clear();
            
            Console.WriteLine($"Your {accountType} account balance is {account.Balance:C}.");

            if (initialDisplay == 0)
            {
                // Give user time to see the account balance.
                
                Thread.Sleep(1500);   
            }

            Console.WriteLine("How can we help you?");
            
            Console.WriteLine(new String('-', 20));
        }

        private static String PromptForAccountAction(Account account, String accountType)
        {
            String[] actions = { "1", "2", "3" };
            
            String[] prompts = {"1. Deposit Funds", "2. Withdraw Funds", "3. Go back"};
            
            String action = "0";

            Int32 initialDisplay = 0;
                
            while (! Array.Exists(actions, element => element == action))
            {
                DisplayInitialAccountDetails(account, accountType, initialDisplay);

                initialDisplay++;
                
                RequestUserInput(prompts);

                action = Console.ReadLine();
            }

            return action;
        }

        private static void PerformAccountAction(Account account, String action)
        {
            switch (action)
            {
                case "1":
                    CreditAccount(account);
                    
                    break;
                case "2":
                    DebitAccount(account);
                    
                    break;
                case "3":
                    Console.Clear();

                    String[] args = {};
                    
                    Main(args);

                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    
                    break;
            }
        }

        private static void DebitAccount(Account account)
        {
            String userAmount;
             
            Decimal amount;
            
            do
            {
                RequestUserInput("How much would you like to withdraw?");
             
                userAmount = Console.ReadLine();
            } while (!Decimal.TryParse(userAmount, out amount));
             
            account.Debit(amount);
        }

        private static void CreditAccount(Account account)
        {
            String userAmount;
            
            Decimal amount;
                                    
            do
            {
                RequestUserInput("How much would you like to deposit?");
            
                userAmount = Console.ReadLine();
            } while (!Decimal.TryParse(userAmount, out amount));
            
            account.Credit(amount);
        }

        /**
         * Default handler for requesting user input
         */
        private static void RequestUserInput(String prompt)
        {
            Console.WriteLine(prompt);
            
            Console.Write("> ");
        }

        /**
         * Default handler for requesting user input w/ multiple lines of text
         */
        private static void RequestUserInput(IEnumerable<String> prompts)
        {
            foreach (String prompt in prompts)
            {
                Console.WriteLine(prompt);
            }
            
            Console.Write("> ");
        }
    }
}