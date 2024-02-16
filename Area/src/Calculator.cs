using AreaCalcualtor.Figure;
using AreaCalculator;

namespace AreaCalcualtor
{
    public static class Calculator
    {
        public static double Calculate(IFigureDescriptor figure)
        {
            if (!figure.Validate())
            {
                throw new CalculationException("Incorrect figure properties value.");
            }

            return figure.GetArea();
        }
    }
}
