
using System;

public class StorableStrategyAttribute : DisposableAttribute
{
    public StorableStrategyAttribute(Type corespondingStrategyType) 
        : base(corespondingStrategyType)
    {

    }
}