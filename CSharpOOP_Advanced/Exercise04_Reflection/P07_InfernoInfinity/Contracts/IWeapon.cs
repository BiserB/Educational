using P07_InfernoInfinity.Models.Enums;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int MaxDamage { get; }

        int MinDamage { get; }        

        Rareness Rareness { get; }

        IGem[] Sockets { get; }

        void AddGem(int index, IGem gem);

        void RemoveGem(int index);        
    }
}