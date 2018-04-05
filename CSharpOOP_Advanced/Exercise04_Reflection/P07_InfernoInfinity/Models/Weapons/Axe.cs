
using P07_InfernoInfinity.Models.Enums;


namespace P07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {        
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int socketsCount = 4;

        public Axe(string name, Rareness rarity)
            : base(name, minDamage, maxDamage, socketsCount, rarity)
        { }

    }
}
