
public class PrimitiveCalculator
{    
    private ICalculationStrategy _calcStrategy;

    public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
    {
        this._calcStrategy = calculationStrategy;
    }

    public void ChangeStrategy(ICalculationStrategy calculationStrategy)
    {
        this._calcStrategy = calculationStrategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        int result = this._calcStrategy.Calculate(firstOperand, secondOperand);

        return result;
    }
}
