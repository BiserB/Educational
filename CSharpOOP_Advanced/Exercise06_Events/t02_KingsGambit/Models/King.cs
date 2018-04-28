using System;
using System.Collections.Generic;
using System.Text;
using t02_KingsGambit.Contracts;

namespace t02_KingsGambit.Models
{
    public class King : IAttackable
    {
        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void OnAttack(object sender, KingAttackedEventArgs args)
        {
            Console.WriteLine($"King {Name} is under attack!");
        }
        
    }
}
