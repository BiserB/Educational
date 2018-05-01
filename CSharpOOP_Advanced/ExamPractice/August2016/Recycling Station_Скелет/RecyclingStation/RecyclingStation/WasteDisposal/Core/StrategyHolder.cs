
    using System;
    using System.Collections.Generic;
    

internal class StrategyHolder : IStrategyHolder
{
    private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

    public StrategyHolder()
    {
        this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
    }

    public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
    {
        get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
    }

    public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
    {
        if (!this.strategies.ContainsKey(disposableAttribute))
        {
            strategies[disposableAttribute] = strategy;
            return true;
        }
        return false;
    }

    public bool RemoveStrategy(Type disposableAttribute)
    {
        if (this.strategies.ContainsKey(disposableAttribute))
        {
            this.strategies.Remove(disposableAttribute);
            return true;
        }        
        return false;
    }
}
