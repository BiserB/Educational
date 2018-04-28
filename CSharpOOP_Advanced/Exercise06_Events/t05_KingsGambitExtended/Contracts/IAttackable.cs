

public interface IAttackable : IUnit
{
    void OnAttack(object sender, KingAttackedEventArgs args);
}
