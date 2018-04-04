using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        { }

        public override string Execute()
        {
            string unitType = Data[1];

            Repository.RemoveUnit(unitType);

            return ($"{unitType} retired!");
        }
    }
}