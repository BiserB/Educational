using System.Collections.Generic;

public interface IMissionController
{
    Queue<IMission> Missions { get; }

    string PerformMission(IMission mission); 

    void FailMissionsOnHold();
}