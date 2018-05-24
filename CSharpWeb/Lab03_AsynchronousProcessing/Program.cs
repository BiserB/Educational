using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(10);

        Thread.CurrentThread.Name = "main";
        List<Thread> threads = new List<Thread>();        

        for (int i = 0; i < 15; i++)
        {
            Thread t = new Thread(new ThreadStart(account.TestWithdraw));
            t.Name = "th " + i.ToString();
            threads.Add(t);
        }
        
        Console.WriteLine("Started " + Thread.CurrentThread.Name);
        account.TestWithdraw();

        foreach (var t in threads)
        {
            Console.WriteLine("Started " + t.Name);
            t.Start();
        }        
    }  
}

public class BankAccount
{
    public BankAccount(decimal amount)
    {
        this.Balance = amount;
        this.ObjLocker = new object();
    }

    public object  ObjLocker { get; set; }

    public decimal Balance { get; private set; }

   public void Withdraw(decimal amount)
    {
        if (this.Balance < amount)
        {
            Console.WriteLine( "Unsufficient balance!");
            return;
        }

        lock (ObjLocker)
        {
            if (this.Balance >= amount)
            {
                Balance -= amount;                
            }
        }
        Console.WriteLine($"New Balance is {this.Balance}");
    }

    public void TestWithdraw()
    {
        Withdraw(1);
    }    
}
