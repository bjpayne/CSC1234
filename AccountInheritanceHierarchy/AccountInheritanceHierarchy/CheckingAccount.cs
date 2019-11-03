using System;
using System.ComponentModel;

namespace AccountInheritanceHierarchy
{
    public sealed class CheckingAccount : Account
    {
        private Decimal accountFee;

        public Decimal AccountFee
        {
            get => accountFee;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Account fee cannot be less than or equal to 0.");
                }

                accountFee = value;
            }
        }

        public CheckingAccount(Decimal initialBalance, Decimal accountFee) : base(initialBalance)
        {
            AccountFee = accountFee;
        }

        public override void Credit(Decimal amount)
        {
            base.Credit(amount);

            Balance -= AccountFee;
        }

        public override void Debit(Decimal amount)
        {
            if ((amount + AccountFee) > Balance)
            {
                throw new Exception("Debit amount plus transaction fee exceeds the account balance.");
            }
            
            base.Debit(amount);

            Balance -= AccountFee;
        }
    }
}