using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Helper
    {
        public bool IsMissingDigit(string intput)
        {
            return intput.Contains('?');
        }

        public string Calculation(int operand1, int operand2, string oprator)
        {
            int calculatedResult = -1;
            switch(oprator)
            {
                case "*" :
                    calculatedResult = operand1 * operand2;
                break;

                case "/" :
                    if(operand1 % operand2 != 0)
                        return "false";
                    calculatedResult = operand1 / operand2;
                break;
            }
            return calculatedResult.ToString();
        }

        public int FindMissingDigit(string calculatedResult, string expectedResult)
        {
            int missingDigit = -1;
            if(calculatedResult.Length != expectedResult.Length)
                return -1;
            int index = expectedResult.IndexOf('?');
            expectedResult = expectedResult.Replace('?', calculatedResult[index]);

            if(calculatedResult.Equals(expectedResult))
            {
                return int.Parse(calculatedResult[index].ToString());
            }
            return missingDigit;
        }
    }
}