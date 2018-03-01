
using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    List<IMission> Missions { get; set; }

    void CompleteMission(Mission mission);
}
