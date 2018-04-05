

namespace P07_InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon, string weaponName);

        string Print(string weaponName);

        void AddGem(string weaponName, int index, IGem gem);

        void RemoveGem(string weaponName, int index);
        
    }
}
