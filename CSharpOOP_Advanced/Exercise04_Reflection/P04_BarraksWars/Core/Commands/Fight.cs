using _03BarracksFactory.Contracts;
using System;

namespace _03BarracksFactory.Core.Commands
{
    public class Fight : Command
    {
        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        { }

        public override string Execute()
        {
            Environment.Exit(0);
            return "";
        }
    }
}