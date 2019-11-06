using NUnit.Framework;

namespace CalculatorTests
{
    public class Tests
    {
        readonly Calculator.Operations calc = new Calculator.Operations();

        [Test]
        public void Pow_WithoutIm()
        {
            var actual = calc.Pow(new ComplexNum(3, 0), 0);
            var expected = new ComplexNum(1, 0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pow_ReAndIm()
        {
            var actual = calc.Pow(new ComplexNum(5, -6), 2);
            var expected = new ComplexNum(-11, -60);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pow_WithoutRe()
        {
            var actual = calc.Pow(new ComplexNum(0, -7), 5);
            var expected = new ComplexNum(0, -16807);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prod_PosAndNeg()
        {
            var actual = calc.Prod(new ComplexNum(5, -6), new ComplexNum(5, -6));
            var expected = new ComplexNum(-11, -60);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prod_Negative()
        {
            var actual = calc.Prod(new ComplexNum(-5, -5), new ComplexNum(-1, -6));
            var expected = new ComplexNum(-25, 35);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prod_Positive()
        {
            var actual = calc.Prod(new ComplexNum(10, 9), new ComplexNum(7, 15));
            var expected = new ComplexNum(-65, 213);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sum()
        {
            var actual = calc.Sum(new ComplexNum(4, -9), new ComplexNum(-5, 12));
            var expected = new ComplexNum(-1, 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dif()
        {
            var actual = calc.Dif(new ComplexNum(9, 10), new ComplexNum(-9, 1));
            var expected = new ComplexNum(18, 9);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals()
        {
            var num = new ComplexNum(4, 6);
            var actual = num.Equals(new ComplexNum(4, 6));
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void NotEquals()
        {
            var num = new ComplexNum(-4, 6);
            var actual = num.Equals(new ComplexNum(4, -6));
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Div_ReAndIm()
        {
            var actual = calc.Div(new ComplexNum(-2, 1), new ComplexNum(1, -1));
            var expected = new ComplexNum(-1.5, -0.5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Div_WithoutIm()
        {
            var actual = calc.Div(new ComplexNum(18, 10), new ComplexNum(2, 0));
            var expected = new ComplexNum(9, 5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Div_WithoutRe()
        {
            var actual = calc.Div(new ComplexNum(12, 4), new ComplexNum(0, 4));
            var expected = new ComplexNum(1, -3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Div_Wholly()
        {
            var actual = calc.Div(new ComplexNum(16, 8), new ComplexNum(8, 4));
            var expected = new ComplexNum(2, 0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Div_ReByRe()
        {
            var actual = calc.Div(new ComplexNum(20, 0), new ComplexNum(5, 0));
            var expected = new ComplexNum(4, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}