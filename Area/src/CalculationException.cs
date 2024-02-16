namespace AreaCalculator
{
    public class CalculationException : Exception
    {
        public CalculationException() { }

        public CalculationException(string? message) : base(message) { }

        public CalculationException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}