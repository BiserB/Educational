



namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type setType = assembly.GetTypes()
                                   .FirstOrDefault(t => t.Name == type);

            if (setType == null)
            {
                throw new ArgumentException("Invalid setType!");
            }

            if (!typeof(ISet).IsAssignableFrom(setType))
            {
                throw new ArgumentException("Invalid setType!");
            }

            object[] arguments = new object[] { name };

            ISet set = (ISet)Activator.CreateInstance(setType, arguments);

            return set;
        }
	}




}
