

public interface IKillable : IUnit
{
    bool IsAlive { get; }

    int AttackCount { get; }

    void ReceiveAttack();
}
