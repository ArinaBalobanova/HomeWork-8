using System;
using static Домашняя_работа__8.Classes.EnumBankAccount;

namespace Домашняя_работа__8.Classes
{
    class BankAccount
    {
        private static Random random = new Random();
        private static int accountNumberCounter = 0;
        private string accountNumber;
        private decimal balance;
        private AccType accountType;

        public BankAccount() : this(0, AccType.Current) { } // пустой конструктор 
        public BankAccount(decimal balance) : this(balance, AccType.Current) { } // конструктор для баланса
        public BankAccount(AccType accountType) : this(0, accountType) { } // Конструктор  типа банковского счета
        public BankAccount(decimal balance, AccType accountType) // конструктор для баланиса и типа банковского счета
        {
            this.balance = balance;
            this.accountType = accountType;
            this.accountNumber = UnicAccountNumber();
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
        }
        public void Transfer(BankAccount destinationAccount, decimal amount)
        {
            Withdraw(amount);
            destinationAccount.Deposit(amount);
            Console.WriteLine($"Переведено {amount} на счет {destinationAccount.accountNumber}.");
        }
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
    }
}
