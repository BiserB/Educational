

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon Create(string weaponType, string weaponName, string rarity);
    }
}
