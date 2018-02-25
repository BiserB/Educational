using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Advanced_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new Dictionary<int,BankAccount>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split(' ');
                switch (command[0])
                {
                    case "Create":
                        Create(command, accounts);
                        break;
                    case "Deposit":
                        Deposit(command, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(command, accounts);
                        break;
                    case "Print":
                        Print(command, accounts);
                        break;
                }
                input = Console.ReadLine();
            }
        }
        public static void Create(string[] command, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(command[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.ID = id;
                acc.Balance = 0;
                accounts[id] = acc;
            }
        }

        public static void Deposit(string[] command, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(command[1]);
            decimal ammount = decimal.Parse(command[2]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[id].Deposit(ammount);
            }
        }

        public static void Withdraw(string[] command, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(command[1]);
            decimal ammount = decimal.Parse(command[2]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (ammount > accounts[id].Balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(ammount);
            }
        }
                

        public static void Print(string[] command, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(command[1]);
            var acc = accounts[id];
            Console.WriteLine(acc);
        }

    }
}
