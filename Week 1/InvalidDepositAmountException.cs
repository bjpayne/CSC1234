using System;

namespace AccountTest
{

    [Serializable]
    class InvalidDepositAmountException : Exception
    {
        public InvalidDepositAmountException()
        {
        }

        public InvalidDepositAmountException(String message) : base(message)
        {
        }
    }
}
