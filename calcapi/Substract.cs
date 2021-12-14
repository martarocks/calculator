using System;
namespace CaclApi
{
    public class Substract : ICalculate
    {
        public Substract()
        {

        }

        public int Calculate(int? firstNumber, int? secondNumber)
        {
            return (int)firstNumber - (int)secondNumber;
        }
    }
}
