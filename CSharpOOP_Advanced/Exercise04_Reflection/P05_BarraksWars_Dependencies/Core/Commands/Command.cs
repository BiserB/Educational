
namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {   
        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; private set; }

        public abstract string Execute();
    }
}