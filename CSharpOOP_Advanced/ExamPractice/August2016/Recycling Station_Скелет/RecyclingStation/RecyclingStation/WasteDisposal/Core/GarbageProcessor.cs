
    using System;
    using System.Linq;
    

public class GarbageProcessor : IGarbageProcessor
{
    public GarbageProcessor(IStrategyHolder strategyHolder)
    {
        this.StrategyHolder = strategyHolder;
    }

    public GarbageProcessor() : this(new StrategyHolder())
    {
    }

    public IStrategyHolder StrategyHolder { get; private set; }

    public IProcessingData ProcessWaste(IWaste garbage)
    {
        Type type = garbage.GetType();
        DisposableAttribute disposalAttribute = (DisposableAttribute)type
                                                .GetCustomAttributes(typeof(DisposableAttribute), true)
                                                .FirstOrDefault();

        Type typeOfAttribute = disposalAttribute.GetType();

        if (disposalAttribute == null )
        {
            throw new ArgumentException(
                "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
        }

        if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute))
        {
            Type typeOfCorespondingStrategy = disposalAttribute.CorespondingStrategyType;

            IGarbageDisposalStrategy newStrategy = (IGarbageDisposalStrategy)Activator
                                                   .CreateInstance(typeOfCorespondingStrategy);

            this.StrategyHolder.AddStrategy(typeOfAttribute, newStrategy);
        }

        IGarbageDisposalStrategy currentStrategy = this.StrategyHolder.GetDisposalStrategies[typeOfAttribute];

        return currentStrategy.ProcessGarbage(garbage);
    }
}

