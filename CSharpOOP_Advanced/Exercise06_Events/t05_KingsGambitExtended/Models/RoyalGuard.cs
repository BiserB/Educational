using System;

public class RoyalGuard : IKillable, IAttackable
{
    private readonly int ENDURANCE = 3;

    public RoyalGuard(string name)
    {
        this.Name = name;
        IsAlive = true;
        this.AttackCount = 0;
    }

    public string Name { get; }

    public bool IsAlive { get; private set; }

    public int AttackCount { get; private set; }

    public void ReceiveAttack()
    {
        AttackCount++;
        if (AttackCount >= ENDURANCE)
        {
            IsAlive = false;
        }
    }

    public void OnAttack(object sender, KingAttackedEventArgs args)
    {
        Console.WriteLine($"Royal Guard {Name} is defending!");
    }
}