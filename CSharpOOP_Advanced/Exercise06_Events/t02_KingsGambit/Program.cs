using System;
using t02_KingsGambit.Contracts;
using t02_KingsGambit.Core;

namespace t02_KingsGambit
{
    public class Program
    {
        static void Main()
        {
            GameManager gm = new GameManager();

            RegisterUnits(gm);

            gm.KingAttacked += gm.King.OnAttack;

            foreach (var guard in gm.RoyalGuards)
            {
                gm.KingAttacked += guard.OnAttack;
            }

            foreach (var footman in gm.Footmans)
            {
                gm.KingAttacked += footman.OnAttack;
            }

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();
                string command = args[0];
                string name = args[1];

                switch (command)
                {
                    case "Attack":
                        gm.AttackKing();
                        break;

                    case "Kill":
                        IAttackable result = gm.KillUnit(name);
                        if (result != null)
                        {
                            gm.KingAttacked -= result.OnAttack;
                        }
                        break;
                }
            }

        }

        static void RegisterUnits(GameManager gm)
        {
            string input = Console.ReadLine();

            gm.RegisterKing(input);

            input = Console.ReadLine();

            gm.RegisterRoyalGuard(input);

            input = Console.ReadLine();

            gm.RegisterFootman(input);            
        }
    }
}
