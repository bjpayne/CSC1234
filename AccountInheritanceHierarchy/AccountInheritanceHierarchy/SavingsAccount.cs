using System;

namespace AccountInheritanceHierarchy
{
    public sealed class SavingsAccount : Account
    {
        private Decimal interestRate;

        private Decimal InterestRate
        {
            get => interestRate;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Interest rate cannot less than or equal to 0.");
                }

                interestRate = value;
            }
        }

        public SavingsAccount(Decimal initialBalance, Decimal interestRate) : base (initialBalance)
        {
            InterestRate = (interestRate / 100);
        }

        public Decimal CalculateInterest()
        {
            return InterestRate * Balance;
        }
    }
}