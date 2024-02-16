using AreaCalcualtor.Figure;

namespace AreaCalculator.Figure.Template
{
    public class Triangle : IFigureDescriptor
    {
        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public bool IsRightAngled(out double firstCathet, out double secondCathet)
        {
            if (SideA * SideA + SideB * SideB == SideC * SideC)
            {
                firstCathet = SideA;
                secondCathet = SideB;

                return true;
            }

            if (SideA * SideA + SideC * SideC == SideB * SideB)
            {
                firstCathet = SideA;
                secondCathet = SideC;

                return true;
            }

            if (SideB * SideB + SideC * SideC == SideA * SideA)
            {
                firstCathet = SideB;
                secondCathet = SideC;

                return true;
            }

            firstCathet = 0;
            secondCathet = 0;

            return false;
        }

        bool IFigureDescriptor.Validate()
        {
            return
                Validate(SideA, SideB, SideC) &&
                Validate(SideB, SideA, SideC) &&
                Validate(SideC, SideA, SideB);
        }

        double IFigureDescriptor.GetArea()
        {
            if (IsRightAngled(out double cathetA, out double cathetB))
            {
                return (cathetA * cathetB) / 2;
            }

            // Heron's formula
            double semiPerimeter = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        private static bool Validate(double firstSide, double secondSide, double thirdSide)
        {
            return firstSide > 0 && firstSide < secondSide + thirdSide;
        }
    }
}
