using System;
using System.Collections.Generic;
using System.Text;
using t02_KingsGambit.Contracts;

namespace t02_KingsGambit.Models
{
    public class Footman : IKillable, IAttackable
    {
        public Footman(string name)
        {
            this.Name = name;
            IsAlive = true;
        }

        public bool IsAlive { get; private set; }

        public string Name { get; }

        public void Die()
        {
            IsAlive = false;
        }

        public void OnAttack(object sender, KingAttackedEventArgs args)
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }        
    }
}
