using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Models.Enums;
using System.Linq;

namespace P07_InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {        
        private int minDamage;
        private int maxDamage;        

        public Weapon(string name, int minDmg, int maxDmg, int socketsCount, Rareness rarity)
        {
            int modifier = (int)rarity;
            this.Name = name;
            this.MinDamage = minDmg * modifier;
            this.MaxDamage = maxDmg * modifier;
            this.Sockets = new IGem[socketsCount];
            this.Rareness = rarity;
        }

        public string Name { get; }

        public int MinDamage
        {
            get { return minDamage ; }
            private set { minDamage = value; }
        }

        public int MaxDamage
        {
            get { return maxDamage ; }
            private set { maxDamage = value; }
        }

        public IGem[] Sockets { get; }

        public Rareness Rareness { get; }

        public void AddGem(int index, IGem gem)
        {
            if (index >= 0 && index < Sockets.Length)
            {
                Sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < Sockets.Length)
            {
                Sockets[index] = null;
            }
        }

        private int AdditionToMinDamage()
        {
            int addition = 0;
            addition += StrengthSum() * 2;
            addition += AgilitySum();
            return addition;
        }

        private int AdditionToMaxDamage()
        {
            int addition = 0;
            addition += StrengthSum() * 3;
            addition += AgilitySum() * 4;            
            return addition;
        }

        private int StrengthSum()
        {
            int sum = 0;
            foreach (var gem in Sockets.Where(s => s != null))
            {
                sum += gem.Strength;
            }
            return sum;
        }

        private int AgilitySum()
        {
            int sum = 0;
            foreach (var gem in Sockets.Where(s => s != null))
            {
                sum += gem.Agility;
            }
            return sum;
        }

        private int VitalitySum()
        {
            int sum = 0;
            foreach (var gem in Sockets.Where(s => s != null))
            {
                sum += gem.Vitality;
            }
            return sum;
        }

        public override string ToString()
        {
            return $"{Name}: {MinDamage + AdditionToMinDamage()}-{MaxDamage + AdditionToMaxDamage()} Damage," +
                $" +{StrengthSum()} Strength, +{AgilitySum()} Agility, +{VitalitySum()} Vitality";
        }

    }
}
