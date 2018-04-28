using System;
using System.Collections.Generic;
using System.Text;
using t02_KingsGambit.Contracts;

namespace t02_KingsGambit.Models
{
    public class RoyalGuard : IKillable, IAttackable
    {
        public RoyalGuard(string name)
        {
            this.Name = name;
            IsAlive = true;
        }

        public string Name { get; }

        public bool IsAlive { get; private set; }

        public void Die()
        {
            IsAlive = false;
        }

        public void OnAttack(object sender, KingAttackedEventArgs args)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }

        
    }
}
