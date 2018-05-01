
using System.Collections.Generic;

public class SoldierCommand : Command
{
    private IList<string> args;

    public SoldierCommand(IMissionController missionController, IList<string> args)
        : base(missionController, args)
    { }

    public override string Execute()
    {      
        
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            int experience = 0;
            double speed = 0d;
            double endurance = 0d;
            double motivation = 0;
            double maxWeight = 0d;

            if (args.Count == 2)
            {
                type = args[0];
                name = args[1];
            }
            else
            {
                type = args[0];
                name = args[1];
                age = int.Parse(args[2]);
                experience = int.Parse(args[3]);
                endurance = double.Parse(args[4]);

            var factory = this.soldierFactory;

            ISoldier soldier = factory.CreateSoldier(type, name, age, experience, endurance);

            this.missionController
        }

        

            //switch (type)
            //{
            //    case "Ranker":
            //        var ranker = SoldiersFactory.GenerateRanker(name, age, experience, speed, endurance,
            //            motivation, maxWeight);
            //        AddSoldierToArmy(ranker, type);
            //        break;
            //    case "Corporal":
            //        var corporal = SoldiersFactory.GenerateCorporal(name, age, experience, speed, endurance,
            //            motivation, maxWeight);
            //        AddSoldierToArmy(corporal, type);
            //        break;
            //    case "Special-Force":
            //        var specialForce = SoldiersFactory.GenerateSpecialForce(name, age, experience, speed, endurance,
            //            motivation, maxWeight);
            //        AddSoldierToArmy(specialForce, type);
            //        break;
            //    case "Regenerate":
            //        SoldierController.TeamRegenerate(army, name);
            //        break;
            //    case "Vacation":
            //        SoldierController.TeamGoesOnVacation(army, name);
            //        break;
            //    case "Bonus":
            //        SoldierController.TeamGetBonus(army, name);
            //        break;
            //}      
    }
}
