using System;


public class Program
{
    static void Main()
    {
        ICalculationStrategy calcStartegy = new AdditionStrategy();
        PrimitiveCalculator calculator = new PrimitiveCalculator(calcStartegy);        

        string input = "";

        while ((input = Console.ReadLine()) != "End")
        {
            string[] args = input.Split();

            if (args[0] == "mode")
            {
                ICalculationStrategy calculationStrategy = null;

                switch (args[1])
                {
                    case "+":
                        calculationStrategy = new AdditionStrategy();
                        break;

                    case "-":
                        calculationStrategy = new SubtractionStrategy();
                        break;

                    case "*":
                        calculationStrategy = new MultiplicationStrategy();
                        break;

                    case "/":
                        calculationStrategy = new DivisionStrategy();
                        break;                    
                }

                if (calculationStrategy != null)
                {
                    calculator.ChangeStrategy(calculationStrategy);
                }
            }
            else
            {
                int firstOperand = int.Parse(args[0]);
                int secondOperand = int.Parse(args[1]);
                int result = calculator.PerformCalculation(firstOperand, secondOperand);
                Console.WriteLine(result);
            }
        }
    }
}
