using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Models.Gems;
using P07_InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Data
{
    public class WeaponRepository : IRepository
    {
        private Dictionary<string, IWeapon> armory ;

        public WeaponRepository()
        {
            this.armory = new Dictionary<string, IWeapon>();
        }

        public void AddGem(string weaponName, int index, IGem gem)
        {
            if (armory.ContainsKey(weaponName))
            {
                armory[weaponName].AddGem(index, gem);
            }                
        }

        public void AddWeapon(IWeapon weapon, string weaponName)
        {            
            armory[weaponName] = weapon;
        }

        public void RemoveGem(string weaponName, int index)
        {
            armory[weaponName].RemoveGem(index);
        }

        public string Print(string weaponName)
        {
            string result = armory[weaponName].ToString();

            return result;
        }

        //public string PrintAll()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var weapon in armory.Values)
        //    {
        //        sb.AppendLine(weapon.ToString());
        //    }

        //    return sb.ToString();
        //}
    }
}
