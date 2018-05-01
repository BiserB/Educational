using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private IMissionController missionController;
    private ISoldierFactory soldierFactory;

    public GameController(IMissionController missionController, ISoldierFactory soldierFactory)
    {
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
    }

    public string ProcessCommand(string[] args)
    {
        string commandName = args[0] + "Command";

        Assembly assembly = Assembly.GetExecutingAssembly();

        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(commandName));

        if (commandType == null)
        {
            throw new ArgumentException($"{commandName} is not a type!");
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new ArgumentException($"{commandName} is not a valid command!");
        }

        object[] arguments = new object[] { this.missionController, args.Skip(1).ToList() };

        ICommand command = (ICommand)Activator.CreateInstance(commandType, arguments);

        string result = command.Execute();

        return result;
    }
}









//    public Dictionary<string, List<Soldier>> Army
//    {
//        get { return army; }
//        set { army = value; }
//    }

//    public Dictionary<string, List<Ammunition>> WearHouse
//    {
//        get { return wearHouse; }
//        set { wearHouse = value; }
//    }

//    public MissionController MissionControllerField
//    {
//        get { return missionControllerField; }
//        set { missionControllerField = value; }
//    }

//    public void GiveInputToGameController(string input)
//    {
//        var data = input.Split();

//        if (data[0].Equals("Soldier"))
//        {
//            string type = string.Empty;
//            string name = string.Empty;
//            int age = 0;
//            int experience = 0;
//            double speed = 0d;
//            double endurance = 0d;
//            double motivation = 0;
//            double maxWeight = 0d;

//            if (data.Length == 3)
//            {
//                type = data[1];
//                name = data[2];
//            }
//            else
//            {
//                type = data[1];
//                name = data[2];
//                age = int.Parse(data[3]);
//                experience = int.Parse(data[4]);
//                speed = double.Parse(data[5]);
//                endurance = double.Parse(data[6]);
//                motivation = double.Parse(data[7]);
//                maxWeight = double.Parse(data[8]);
//            }

//            switch (type)
//            {
//                case "Ranker":
//                    var ranker = SoldiersFactory.GenerateRanker(name, age, experience, speed, endurance,
//                        motivation, maxWeight);
//                    AddSoldierToArmy(ranker, type);
//                    break;
//                case "Corporal":
//                    var corporal = SoldiersFactory.GenerateCorporal(name, age, experience, speed, endurance,
//                        motivation, maxWeight);
//                    AddSoldierToArmy(corporal, type);
//                    break;
//                case "Special-Force":
//                    var specialForce = SoldiersFactory.GenerateSpecialForce(name, age, experience, speed, endurance,
//                        motivation, maxWeight);
//                    AddSoldierToArmy(specialForce, type);
//                    break;
//                case "Regenerate":
//                    SoldierController.TeamRegenerate(army, name);
//                    break;
//                case "Vacation":
//                    SoldierController.TeamGoesOnVacation(army, name);
//                    break;
//                case "Bonus":
//                    SoldierController.TeamGetBonus(army, name);
//                    break;
//            }

//        }
//        else if (data[0].Equals("WearHouse"))
//        {
//            string name = data[1];
//            int number = int.Parse(data[2]);

//            AddAmmunitions(AmmunitionFactory.CreateAmmunitions(name, number));
//        }
//        else if (data[0].Equals("Mission"))
//        {
//            this.MissionControllerField.PerformMission(new Easy());
//        }
//    }

//    public string RequestResult()
//    {
//        return Output.GiveOutput(result, army, wearHouse, this.MissionControllerField.MissionQueue.Count);
//    }

//    private void AddAmmunitions(Ammunition ammunition)
//    {
//        if (!this.WearHouse.ContainsKey(ammunition.Name))
//        {
//            this.WearHouse[ammunition.Name] = new List<Ammunition>();
//            this.WearHouse[ammunition.Name].Add(ammunition);
//        }
//        else
//        {
//            this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
//        }
//    }

//    private void AddSoldierToArmy(Soldier soldier, string type)
//    {
//        if (!soldier.CheckIfSoldierCanJoinTeam())
//        {
//            throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
//        }

//        if (!this.Army.ContainsKey(type))
//        {
//            this.Army[type] = new List<Soldier>();
//        }
//        this.Army[type].Add(soldier);
//    }
//}