using System;
using Домашняя_работа__8.Classes;
using static Домашняя_работа__8.Classes.BankTransactioncs;
using static Домашняя_работа__8.Classes.BankAccount;
using static Домашняя_работа__8.Classes.EnumBankAccount;
using static Домашняя_работа__8.Classes.BankAccount3;
using static Домашняя_работа__8.Classes.Song;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
        static void Task1()
        {
            /*Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить 
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию,
            создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета,
            конструктор для заполнения баланса и типа банковского счета. Каждый конструктор должен вызывать метод,
            генерирующий номер счета.*/
            Console.WriteLine("Упражнение 9.1");
            BankAccount account1 = new BankAccount(2500, AccType.Current);
            BankAccount account2 = new BankAccount(3100, AccType.Savings);
            Console.WriteLine("Информация о счетах до перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();

            account1.Transfer(account2, 500);
            Console.WriteLine("Информация о счетах после перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
        }
        static void Task2()
        {
            /*Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию о всех банковских операциях. 
            При изменении баланса счета создается новый объект класса BankTransaction, который содержит текущую дату и время,
            добавленную или снятую со счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса 
            передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа System.Collections.Queue,
            которое будет хранить объекты класса BankTransaction для данного банковского счета; изменить методы снятия со счета
            и добавления на счет так, чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в 
            переменную типа System.Collections.Queue.*/
            Console.WriteLine("Упражнение 9.2");
            BankTransactioncs account1 = new BankTransactioncs(5000, AccType.Savings);
            BankTransactioncs account2 = new BankTransactioncs(1200, AccType.Savings);
            Console.WriteLine("Информация о счетах до перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();

            account1.Deposit(200);
            account2.Withdraw(150);
            Console.WriteLine("Информация о счетах после перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            Console.WriteLine("История транзакций для первого счета:");
            // информация о транзакциях
            foreach (Transaction transaction in account1.GetTransactions())
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
            }

            Console.WriteLine("История транзакций для второго счета:");
            foreach (Transaction transaction in account2.GetTransactions())
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
            }
        }
        static void Task3()
        {
            /*Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о проводках из очереди запишет в файл.
            Не забудьте внутри метода Dispose вызвать метод GC.SuppressFinalize, который сообщает системе, что она
            не должна вызывать метод завершения для указанного объекта.*/
            Console.WriteLine("Упражнение 9.3");
            BankAccount3 account1 = new BankAccount3(2500, AccType.Current);
            BankAccount3 account2 = new BankAccount3(2500, AccType.Current);
            Console.WriteLine("Информация о счете до перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();

            account1.Deposit(200);
            account2.Withdraw(50);
            Console.WriteLine("Информация о счете после перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            Console.WriteLine("Транзакции записаны в файл.");
        }
        static void Task4()
        {
            /*Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие конструкторы: 
            1) параметры конструктора – название и автор песни, указатель на предыдущую песню инициализировать null. 
            2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main создать объект mySong.
            Возникнет ли ошибка при инициализации объекта mySong следующим образом: Song mySong = new Song(); ? 
            Исправьте ошибку, создав необходимый конструктор.*/
            Console.WriteLine("Домашнее задание 9.1");
            List<Song> songs = new List<Song>
            {
                new Song("Espresso", "Sabrina Carpenter"),
                new Song("APT", "Rose ft. Bruno Mars"),
                new Song("Rockstar", "Lisa"),
                new Song("Solo", "Jenny Kim")
            };
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }
            Song firstSong = songs[0];
            Song secondSong = songs[1];

            if (firstSong.Equals(secondSong))
            {
                Console.WriteLine("Первая и вторая песни одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }

            Song mySong = new Song("Beggin’", "Maneskin");
            Console.WriteLine($"Создана песня: {mySong.Title()}");
        }
    }
}