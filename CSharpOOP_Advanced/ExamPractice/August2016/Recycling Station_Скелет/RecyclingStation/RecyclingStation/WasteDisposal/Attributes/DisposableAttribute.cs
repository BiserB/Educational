
using System;



[AttributeUsage(AttributeTargets.Class)]
public class DisposableAttribute : Attribute
{
    public DisposableAttribute(Type corespondingStrategyType)
    {
        this.CorespondingStrategyType = corespondingStrategyType;
    }

    public Type CorespondingStrategyType { get; }
}