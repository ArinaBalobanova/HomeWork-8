using System;

namespace Домашняя_работа__8.Classes
{
    class Transaction
    {
        public DateTime TransactionDate { get; }
        public decimal Amount { get; }

        public Transaction(decimal amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
        }
    }
}
