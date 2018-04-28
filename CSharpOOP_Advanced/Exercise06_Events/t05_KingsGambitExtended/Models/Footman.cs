using System;

public class Footman : IKillable, IAttackable
{
    private readonly int ENDURANCE = 2;

    public Footman(string name)
    {
        this.Name = name;
        IsAlive = true;
        this.AttackCount = 0;
    }

    public bool IsAlive { get; private set; }

    public string Name { get; }

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
        Console.WriteLine($"Footman {Name} is panicking!");
    }
}
