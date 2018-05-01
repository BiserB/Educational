
using System.Collections.Generic;

public interface IWareHouse
{
    List<IAmmunition> Content { get; }

    void EquipArmy(IArmy army);
}
