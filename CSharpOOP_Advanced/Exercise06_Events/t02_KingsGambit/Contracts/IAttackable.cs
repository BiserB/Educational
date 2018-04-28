using System;
using System.Collections.Generic;
using System.Text;
using t02_KingsGambit.Models;

namespace t02_KingsGambit.Contracts
{
    public interface IAttackable : IUnit
    {   
        void OnAttack(object sender, KingAttackedEventArgs args);
    }
}
