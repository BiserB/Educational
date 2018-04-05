using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Models.Enums;
using P07_InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P07_InfernoInfinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem Create(string gemType, string clarity)
        {
            Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .First(t => t.Name.ToLower().Contains( gemType.ToLower()));

            Clarity cl;

            if (!Enum.TryParse(clarity, out cl))
            {
                return null;
            }

            object[] args = new object[] { cl };

            IGem gem = (IGem)Activator.CreateInstance(type, args);

            return gem;
        }
    }
}
