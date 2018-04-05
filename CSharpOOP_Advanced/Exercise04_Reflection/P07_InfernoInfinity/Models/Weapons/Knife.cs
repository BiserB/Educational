using P07_InfernoInfinity.Models.Enums;


namespace P07_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int socketsCount = 2;

        public Knife(string name, Rareness rarity)
            : base(name, minDamage, maxDamage , socketsCount, rarity)
        { }
    }
}
