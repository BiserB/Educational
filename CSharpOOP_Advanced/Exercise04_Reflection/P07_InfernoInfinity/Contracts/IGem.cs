using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IGem
    {
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
    }
}
