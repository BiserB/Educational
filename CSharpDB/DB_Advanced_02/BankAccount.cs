﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Advanced_02
{
    class BankAccount
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal ammount)
        {
            Balance += ammount;
        }
        public void Withdraw(decimal ammount)
        {
            Balance -= ammount;
        }
    }
}
