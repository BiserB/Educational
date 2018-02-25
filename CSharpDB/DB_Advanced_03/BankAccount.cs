using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Advanced_03
{
    class BankAccount
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }   

        public void Deposit(decimal ammount)
        {
            this.Balance += ammount;
        }
        public void Withdraw(decimal ammount)
        {
            this.Balance -= ammount;
        }

        public override string ToString()
        {
            return $"Account ID {this.ID}, balance = {this.Balance:f2}";
        }

    }
}
