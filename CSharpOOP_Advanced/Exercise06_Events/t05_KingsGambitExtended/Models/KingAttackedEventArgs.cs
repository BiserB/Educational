using System;


public class KingAttackedEventArgs : EventArgs
{
    public KingAttackedEventArgs(King king)
    {
        this.King = king;
    }

    public King King { get; private set; }
}
