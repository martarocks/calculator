using System;
namespace CaclApi
{
    public class Multiply : ICalculate
    {
        public Multiply()
        {
        }

        public int Calculate(int? firstNumber, int? secondNumber)
        {

            return (int)firstNumber * (int)secondNumber;
        }
    }
}