
namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get; private set; }

        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }
}