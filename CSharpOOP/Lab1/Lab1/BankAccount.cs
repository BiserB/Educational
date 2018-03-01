using System;
using System.Collections.Generic;
using System.Text;


public class BankAccount
{
    private int id;

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }


}

