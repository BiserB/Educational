

using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Models.Enums;
using P07_InfernoInfinity.Models.Weapons;
using System;
using System.Linq;
using System.Reflection;

namespace P07_InfernoInfinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(string weaponType, string weaponName, string rarity)
        {
            Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .First(t => t.Name.ToLower().Contains(weaponType.ToLower()));

            Rareness rareness;

            if (!Enum.TryParse(rarity, out rareness))
            {
                return null;
            }

            object[] args = new object[] { weaponName, rareness };

            IWeapon weapon = (IWeapon)Activator.CreateInstance(type, args);

            return weapon;
        }
    }
}
