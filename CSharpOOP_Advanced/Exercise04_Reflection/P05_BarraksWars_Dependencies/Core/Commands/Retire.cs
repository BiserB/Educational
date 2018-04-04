
namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get; private set; }

        public override string Execute()
        {
            string unitType = Data[1];

            this.Repository.RemoveUnit(unitType);

            return ($"{unitType} retired!");
        }
    }
}