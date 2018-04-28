using System;
using System.Collections.Generic;
using System.Text;

namespace t04_WorkForce.Contracts
{
    public interface IJob
    {
        string Name { get; }

        double HoursReqired { get; }

        void Update();
        
    }
}
