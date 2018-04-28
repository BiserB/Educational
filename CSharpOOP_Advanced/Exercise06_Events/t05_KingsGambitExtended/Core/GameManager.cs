
using System.Collections.Generic;
using System.Linq;


public class GameManager
{
    public delegate void KingAttackedEventHandler(object sender, KingAttackedEventArgs args);

    public event KingAttackedEventHandler KingAttacked;

    public GameManager()
    {
        this.Footmans = new List<Footman>();
        this.RoyalGuards = new List<RoyalGuard>();
    }

    public King King { get; private set; }

    public List<Footman> Footmans { get; private set; }

    public List<RoyalGuard> RoyalGuards { get; private set; }

    public void RegisterKing(string name)
    {
        this.King = new King(name);
    }

    public void RegisterFootman(string input)
    {
        string[] names = input.Split();
        foreach (var name in names)
        {
            this.Footmans.Add(new Footman(name));
        }
    }

    public void RegisterRoyalGuard(string input)
    {
        string[] names = input.Split();
        foreach (var name in names)
        {
            this.RoyalGuards.Add(new RoyalGuard(name));
        }
    }

    public void AttackKing()
    {
        OnKingAttacked(this.King);
    }

    public IAttackable AttackUnit(string name)
    {
        RoyalGuard guard = RoyalGuards.FirstOrDefault(g => g.Name == name);

        if (guard != null)
        {
            guard.ReceiveAttack();
            if (!guard.IsAlive)
            {
                return guard;
            }
            return null;
        }

        Footman footman = Footmans.FirstOrDefault(g => g.Name == name);
        if (footman != null)
        {
            footman.ReceiveAttack();
            if (!footman.IsAlive)
            {
                return footman;
            }            
        }
        return null;
    }

    protected virtual void OnKingAttacked(King king)
    {
        if (this.KingAttacked != null)
        {
            KingAttacked(this, new KingAttackedEventArgs(king));
        }
    }
}