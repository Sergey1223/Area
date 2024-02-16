using AreaCalcualtor.Figure;

namespace AreaCalculator.Figure.Template
{
    public class Circle : IFigureDescriptor
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        bool IFigureDescriptor.Validate()
        {
            return Radius >= 0;
        }

        double IFigureDescriptor.GetArea()
        {
            double area = Math.PI* Math.Abs(Radius * Radius);

            if (area > double.MaxValue)
            {
                return double.MaxValue;
            }

            return area;
        }
    }
}
