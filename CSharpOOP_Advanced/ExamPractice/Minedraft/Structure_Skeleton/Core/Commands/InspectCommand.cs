
using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    { }

    public override string Execute()
    {
        int id = int.Parse(Arguments[0]);

        string result = "";


        var entity = ((ProviderController)this.ProviderController)
                        .Entities
                        .FirstOrDefault(e => e.ID == id);

        if (entity == null)
        {
            entity = ((HarvesterController)this.HarvesterController)
                        .Entities
                        .FirstOrDefault(e => e.ID == id);
        }        

        if (entity != null)
        {
            result = entity.GetType().Name;
            result += Environment.NewLine;
            result += string.Format(Constants.Durability, entity.Durability);
            return result;
        }
        else
        {
            result = string.Format(Constants.NoEntity, id);
        }        

        return result;
    }
}