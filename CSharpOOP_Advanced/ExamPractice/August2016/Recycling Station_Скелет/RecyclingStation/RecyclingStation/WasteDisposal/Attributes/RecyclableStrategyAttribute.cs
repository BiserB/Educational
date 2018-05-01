
using System;

public class RecyclableStrategyAttribute : DisposableAttribute
{
    public RecyclableStrategyAttribute(Type corespondingStrategyType) 
        : base(corespondingStrategyType)
    {

    }
}
