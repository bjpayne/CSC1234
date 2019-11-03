using System;

namespace AccountInheritanceHierarchy
{
    public abstract class Account
    {
        private Decimal balance;

        public Decimal Balance
        {
            get => balance;
            protected set
            {
                if (value < 0)
                {
                    throw new Exception("Initial balance cannot be less than 0.");
                }

                balance = value;
            }
        }

        protected Account(Decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public virtual void Credit(Decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Cannot credit an amount less than 0.");
            }

            Balance += amount;
        }

        public virtual void Debit(Decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Cannot debit an amount less 0.");
            }

            if (amount > Balance)
            {
                throw new Exception("Debit amount exceeded account balance.");
            }

            Balance -= amount;
        }
    }
}