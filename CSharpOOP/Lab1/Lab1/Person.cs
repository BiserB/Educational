using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;
    
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }    

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public List<BankAccount> Accounts
    {
        get { return this.accounts; }
        set { this.accounts = value; }
    }


    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.accounts = new List<BankAccount>();
    }
    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.Accounts = accounts;
    }

    public decimal GetBalance()
    {
        decimal balance = accounts.Select(a => a.Balance).Sum();
        return balance;
    }

}

