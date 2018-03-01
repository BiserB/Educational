using System;
using System.Collections.Generic;

public class Program
{
    private static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
    static void Main()
    {
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            string command = data[0];
            int accountId = int.Parse(data[1]);
            switch (command)
            {
                case "Create":
                    if (!accounts.ContainsKey(accountId))
                    {
                        BankAccount acc = new BankAccount();
                        acc.Id = accountId;
                        accounts[accountId] = acc;
                    }
                    else
                    {
                        Console.WriteLine("Account already exists");
                    }
                    break;
                case "Deposit":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        decimal amount = decimal.Parse(data[2]);
                        accounts[accountId].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        decimal amount = decimal.Parse(data[2]);
                        if (accounts[accountId].Balance < amount)
                        {
                            Console.WriteLine("Insufficient balance");
                            continue;
                        }
                        accounts[accountId].Withdraw(amount);
                    }
                    break;
                case "Print":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else    
                    {
                        Console.WriteLine(accounts[accountId]);
                    }          
                    break;
            }
        }

       
        
    }

    
}
    

