using System;
using System.Collections.Generic;
using System.Text;

namespace t02_KingsGambit.Models
{
    public class KingAttackedEventArgs : EventArgs
    {
        public KingAttackedEventArgs(King king)
        {
            this.King = king;
        }

        public King King { get; private set; }
    }
}
