using System;
namespace CaclApi
{
    public class Sum : ICalculate
    {
        public Sum()
        {
        }

        public int Calculate(int? firstNumber, int? secondNumber)
        {
            return (int)firstNumber + (int)secondNumber;
        }
    }
}
