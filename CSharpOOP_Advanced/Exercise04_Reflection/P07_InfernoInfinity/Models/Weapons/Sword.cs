using P07_InfernoInfinity.Models.Enums;


namespace P07_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {        
        private const int minDamage = 4;
        private const int maxDamage = 6;
        private const int socketsCount = 3;

        public Sword(string name, Rareness rarity)
            : base(name, minDamage, maxDamage, socketsCount, rarity)
        { }
    }
}
