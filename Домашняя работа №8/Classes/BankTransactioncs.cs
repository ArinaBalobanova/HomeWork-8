using System;
using static Домашняя_работа__8.Classes.EnumBankAccount;

namespace Домашняя_работа__8.Classes
{
    class BankTransactioncs
    {
        private static Random random = new Random();
        private static int accountNumberCounter = 0;
        private string accountNumber;
        private decimal balance;
        private AccType accountType;
        private Queue<Transaction> transactions;

        public BankTransactioncs() : this(0, AccType.Current) { }
        public BankTransactioncs(decimal balance) : this(balance, AccType.Current) { }
        public BankTransactioncs(AccType accountType) : this(0, accountType) { }
        public BankTransactioncs(decimal balance, AccType accountType)
        {
            this.balance = balance;
            this.accountType = accountType;
            this.accountNumber = UnicAccountNumber();
            this.transactions = new Queue<Transaction>();
        }
        private string UnicAccountNumber()
        {
            int randomPart = random.Next(1000, 1000000);
            accountNumberCounter++;
            return $"AC{randomPart}-{accountNumberCounter:0000}";
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
            transactions.Enqueue(new Transaction(amount));
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
            transactions.Enqueue(new Transaction(amount));
        }
        public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }
        public Queue<Transaction> GetTransactions()
        {
            return transactions;
        }
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }


    }
}
