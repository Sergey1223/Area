using AreaCalcualtor;
using AreaCalcualtor.Figure;
using AreaCalculator;
using AreaCalculator.Figure.Template;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;

namespace Area.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void CircleAreCalculation()
        {
            List<(double, double)> cases = new List<(double, double)> {
                (0, 0),                                                         // Radius is 0
                (1, 3.14),                                                      // Radius is 1
                (1.7976931348623157E+308, 1.7976931348623157E+308)              // Radius is double maximum value
            };

            Action<(double radius, double area)> action =
                (c) => Assert.Equal(c.area, Math.Round(Calculator.Calculate(new Circle(c.radius)), 2));

            Assert.All(cases, action);
        }

        [Fact]
        public void TriangleAreCalculation()
        {
            List<(double, double, double, double)> cases = new List<(double, double, double, double)> {
                (1, 1, 1, 0.43),    // Sides length is 1, 1, 1
                (2, 2, 3, 1.98)     // Sides length is 2, 2, 3
            };

            Action<(double a, double b, double c, double area)> action =
                (c) => Assert.Equal(c.area, Math.Round(Calculator.Calculate(new Triangle(c.a, c.b, c.c)), 2));

            Assert.All(cases, action);
        }

        //public void CircleAreCalculationAtOne()
        //{
        //    Circle circle = new Circle(1);

        //    double area = Calculator.Calculate(circle);

        //    Assert.Equal(1.7976931348623157E+308, area);
        //}

        //public void CircleAreCalculationOnZero(double radius)
        //{
        //    Circle circle = new Circle(radius);

        //    double area = Calculator.Calculate(circle);

        //    Assert.Equal(0, area);
        //}

        [Theory]
        [InlineData(-1)]
        [InlineData(double.NegativeInfinity)]
        public void CircleAreCalculationExceptionThrow(double radius)
        {
            Circle circle = new Circle(radius);
            Action action = () => Calculator.Calculate(circle);

            Assert.Throws<CalculationException>(action);
        }

        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 2, 3)]
        public void TriangleAreCalculationExceptionThrow(double sideA, double sideB, double sideC)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Action action = () => Calculator.Calculate(triangle);

            Assert.Throws<CalculationException>(action);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        public void TriangleIsRightAngled(double sideA, double sideB, double sideC)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            bool isRightAngled = triangle.IsRightAngled(out _, out _);

            Assert.True(isRightAngled);
        }
    }
}
