namespace _03BarracksFactory.Core.Factories
{
    using _03BarracksFactory.Models.Units;
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string targetName = typeof(Unit).Namespace + $".{unitType}";

            Type typeOfUnit = Type.GetType(targetName);

            object newUnit = Activator.CreateInstance(typeOfUnit, new object[] { });

            //var ctorInfo = typeOfUnit.GetConstructors(BindingFlags.CreateInstance | BindingFlags.Public)[0];

            //var newUnit = (IUnit)ctorInfo.Invoke(new object[] { });

            return (IUnit)newUnit;
        }
    }
}