using System;

public class BurnableStrategyAttribute : DisposableAttribute
{
    public BurnableStrategyAttribute(Type corespondingStrategyType) 
        : base(corespondingStrategyType)
    {

    }
}
