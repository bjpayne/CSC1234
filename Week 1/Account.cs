using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTest
{
    class Account
    {
        private String Name {get; set;}

        private Decimal balance;

        private String defaultError = "An error occurred, and your request could not be completed. Please try again.";

        public Account()
        {
            Console.WriteLine("Welcome to AcmeBank. What is your Name?");

            this.Name = Console.ReadLine();

            this.balance = 0.0m;
        }


        public Account(string accountName)
        {
            this.Name = accountName;

            this.balance = 0.0m;
        }

        public void DetermineUserAction()
        {
            Console.WriteLine($"\n{this.Name}'s balance: {this.balance:C}");

            Console.WriteLine("\n1: View Balance\n2: Deposit Money\n3: Withdraw Money\n4: Exit");

            Console.Write("What you like to do?: ");

            String action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    this.DetermineUserAction();
                    break;
                case "2":
                    this.Deposit();
                    break;
                case "3":
                    this.Withdraw();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    this.DetermineUserAction();
                    break;
            }
        }

        private void Deposit()
        {
            try {
                Console.Write("How much would you like to deposit?: ");

                Decimal depositAmount = Decimal.Parse(Console.ReadLine());

                if (depositAmount < 0.0m)
                {
                    throw new InvalidDepositAmountException("\nPlease enter a valid amount.");
                }

                this.balance = balance + depositAmount;

                this.DetermineUserAction();
            } catch (InvalidDepositAmountException e) {
                Console.WriteLine(e.Message);

                this.Deposit();
            } catch (Exception) {
                Console.WriteLine(this.defaultError);

                this.DetermineUserAction();
            }
        }

        private void Withdraw()
        {
            try {
                if (this.balance == 0.0m) {
                    this.NoFundsInAccount();

                    return;
                }

                Console.Write("How much would you like withdraw?: ");

                Decimal withdrawAmount = Decimal.Parse(Console.ReadLine());

                if (withdrawAmount > this.balance) {
                    throw new InvalidWithdrawAmountException("\nWithdrawal amount exceeds the balance.");
                }

                if (withdrawAmount < 0.0m) {
                    throw new InvalidWithdrawAmountException("\nPlease enter a valid amount.");
                }

                this.balance = balance - withdrawAmount;

                this.DetermineUserAction();
            } catch (InvalidWithdrawAmountException e) {
                Console.WriteLine(e.Message);

                this.Withdraw();
            } catch (Exception) {
                Console.WriteLine("An error has occured and your request could not be completed.");

                this.DetermineUserAction();
            }
        }

        private void NoFundsInAccount()
        {
            try {
                Console.Write("You have $0 left in your account. Would you like to deposit some funds now? (yes / no): ");

                String action = Console.ReadLine();

                if (action.ToLower().Equals("yes")) {
                    this.Deposit();

                    return;
                }

                this.DetermineUserAction();
            } catch (Exception) {
                this.DetermineUserAction();
            }
        }
    }
}
