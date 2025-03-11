using FractionCalculator.Core;
using Xunit;

namespace FractionCalculator.Tests
{
    public class FractionTests
    {
        [Fact]
        public void Add_TwoFractions_ReturnsCorrectSum()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var result = Fraction.Add(f1, f2);
            Assert.Equal("5/6", result.ToString());
        }

        [Fact]
        public void Subtract_TwoFractions_ReturnsCorrectDifference()
        {
            var f1 = new Fraction(3, 4);
            var f2 = new Fraction(1, 2);
            var result = Fraction.Subtract(f1, f2);
            Assert.Equal("1/4", result.ToString());
        }

        [Fact]
        public void Multiply_TwoFractions_ReturnsCorrectProduct()
        {
            var f1 = new Fraction(2, 3);
            var f2 = new Fraction(3, 5);
            var result = Fraction.Multiply(f1, f2);
            Assert.Equal("2/5", result.ToString());
        }

        [Fact]
        public void Divide_TwoFractions_ReturnsCorrectQuotient()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 4);
            var result = Fraction.Divide(f1, f2);
            Assert.Equal("2/1", result.ToString());
        }

        [Fact]
        public void Constructor_ZeroDenominator_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Fraction(1, 0));
            Assert.Equal("Знаменник не може бути нульовим.", exception.Message);
        }

        [Fact]
        public void Divide_ByZeroFraction_ThrowsException()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(0, 1);
            var exception = Assert.Throws<DivideByZeroException>(() => Fraction.Divide(f1, f2));
            Assert.Equal("Неможливо ділити на нульовий дріб.", exception.Message);
        }

        [Fact]
        public void Simplify_NegativeDenominator_CorrectlyAdjusted()
        {
            var fraction = new Fraction(1, -2);
            Assert.Equal("-1/2", fraction.ToString());
        }
    }
}