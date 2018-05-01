
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }
    [Inject]
    public IHarvesterController HarvesterController { get; }
    [Inject]
    public IProviderController ProviderController { get; }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        // Get all entities
        var entities = new List<IEntity>();
        GetProviders(entities);
        GetHarvesters(entities);

        // Search in entities
        foreach (var entity in entities)
        {
            if (entity.ID == id)
            {
                var result = new StringBuilder();
                result.AppendLine(entity.GetType().Name);
                result.AppendLine(string.Format(Constants.Durability, entity.Durability));

                return result.ToString().Trim();
            }
        }

        return string.Format(Constants.NoEntity, id);
    }

    private void GetHarvesters(List<IEntity> entities)
    {
        var harvesterEntitites = this.HarvesterController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name == "Entities");

        var harvesters = (IReadOnlyCollection<IEntity>)harvesterEntitites.GetValue(this.HarvesterController);

        entities.AddRange(harvesters);
    }

    private void GetProviders(List<IEntity> entities)
    {
        var providerEntitites = this.ProviderController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name == "Entities");

        var providers = (IReadOnlyCollection<IEntity>)providerEntitites.GetValue(this.ProviderController);

        entities.AddRange(providers);
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class InspectCommand : Command
//{
//    public InspectCommand(IList<string> arguments,
//       IHarvesterController harvesterController, IProviderController providerController)
//        : base(arguments, harvesterController, providerController)
//    { }

//    public override string Execute()
//    {   
//        int id = int.Parse(Arguments[0]);

//        string result = "";


//        var provider = ((ProviderController)this.ProviderController)
//                        .Entities
//                        .FirstOrDefault(e => e.ID == id);

//        if (provider != null)
//        {
//            result = provider.GetType().Name;
//            result += Environment.NewLine;
//            result += string.Format(Constants.Durability, provider.Durability);
//            return result;
//        }

//        var harvester = ((HarvesterController)this.HarvesterController)
//                        .Entities
//                        .FirstOrDefault(e => e.ID == id);

//        if (harvester != null)
//        {
//            result = harvester.GetType().Name;
//            result += Environment.NewLine;
//            result += string.Format(Constants.Durability, harvester.Durability);
//            return result;
//        }

//        result = string.Format(Constants.NoEntity, id);

//        return result;
//    }
//}