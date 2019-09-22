using System;

namespace AccountTest
{
    [Serializable]
    class InvalidWithdrawAmountException : Exception
    {
        public InvalidWithdrawAmountException()
        {
        }

        public InvalidWithdrawAmountException(String message) : base (message)
        {
        }
    }
}
