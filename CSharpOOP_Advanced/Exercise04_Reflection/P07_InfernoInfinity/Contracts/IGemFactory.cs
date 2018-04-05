using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem Create(string gemType, string clarity);
    }
}
