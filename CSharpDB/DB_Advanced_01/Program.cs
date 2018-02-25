using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Advanced_01
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();
            acc.ID = 1;
            acc.Balance = 15;
            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
    
}
