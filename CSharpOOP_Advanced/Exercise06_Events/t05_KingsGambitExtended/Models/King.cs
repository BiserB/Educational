using System;
using System.Collections.Generic;
using System.Text;

public class King : IAttackable
{
    public King(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public void OnAttack(object sender, KingAttackedEventArgs args)
    {
        Console.WriteLine($"King {Name} is under attack!");
    }

}