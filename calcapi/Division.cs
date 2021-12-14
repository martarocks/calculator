using System;
namespace CaclApi
{
    public class Division : ICalculate
    {
        public Division()
        {
        }

        public int Calculate(int? firstNumber, int? secondNumber)
        {
           
                if (secondNumber > 0)
                {
                    return (int)firstNumber / (int)secondNumber;
                }

            throw new Exception("Cannot divide by zero");
            
        }
    }
}
