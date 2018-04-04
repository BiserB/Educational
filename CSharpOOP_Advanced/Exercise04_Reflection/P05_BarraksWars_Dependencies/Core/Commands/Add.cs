
namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class Add : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public Add(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository { get ; private set; }
        public IUnitFactory UnitFactory { get; private set; }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string result = unitType + " added!";
            return result;
        }
    }
}