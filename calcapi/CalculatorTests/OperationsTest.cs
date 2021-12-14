using CaclApi;
using Calculator.Controllers;
using NUnit.Framework;

namespace CalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumCorrect()
        {
            Sum s = new Sum();
            int result = s.Calculate(3, 2);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void SumInCorrect()
        {
            Sum s = new Sum();
            int result = s.Calculate(3, 2);
            Assert.AreNotEqual(8, result);
        }
        [Test]
        public void MultiplyCorrect()
        {
            Multiply s = new Multiply();
            int result = s.Calculate(3, 2);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void MultiplyInCorrect()
        {
            Multiply s = new Multiply();
            int result = s.Calculate(3, 2);
            Assert.AreNotEqual(8, result);
        }
        [Test]
        public void DivisionCorrect()
        {
            Division s = new Division();
            int result = s.Calculate(12, 2);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void DivisionInCorrect()
        {
            Division s = new Division();
            int result = s.Calculate(12, 2);
            Assert.AreNotEqual(8, result);
        }
        [Test]
        public void SubstractCorrect()
        {
            Substract s = new Substract();
            int result = s.Calculate(12, 2);
            Assert.AreEqual(10, result);
        }
        [Test]
        public void SubstractInCorrect()
        {
            Substract s = new Substract();
            int result = s.Calculate(12, 2);
            Assert.AreNotEqual(14, result);
        }
    }
}