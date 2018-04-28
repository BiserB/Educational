using System;
using System.Collections.Generic;
using System.Text;
using t02_KingsGambit.Models;

namespace t02_KingsGambit.Contracts
{
    public interface IKillable : IUnit
    {
        bool IsAlive { get; }

        void Die();
    }
}
