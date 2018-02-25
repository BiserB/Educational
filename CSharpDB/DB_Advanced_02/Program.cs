using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Advanced_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount();
            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);

            Console.WriteLine($"Account {acc.ID}, balance = {acc.Balance:f2}.");
        }
    }
}
