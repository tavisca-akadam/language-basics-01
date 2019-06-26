using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Test("2*3=6?",-1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            Helper helper = new Helper();
            string[] equationArray = equation.Split('*','=');   
            int operand1 = 0, operand2 = 0;
            string expectedResult = "";                   //split the equation
            //case 1: findingDigit * operand2 = result
            if(helper.IsMissingDigit(equationArray[0]))
            {
                operand1 = int.Parse(equationArray[2]);
                operand2 = int.Parse(equationArray[1]);
                expectedResult = equationArray[0];
                string calculatedResult = helper.Calculation(operand1, operand2, "/");
                return helper.FindMissingDigit(calculatedResult, expectedResult);
            }
            //case 2: operand1 * findingDigit = result
            else if(helper.IsMissingDigit(equationArray[1]))
            {
                operand1 = int.Parse(equationArray[2]);
                operand2 = int.Parse(equationArray[0]);
                expectedResult = equationArray[1];
                string calculatedResult = helper.Calculation(operand1, operand2, "/");
                return helper.FindMissingDigit(calculatedResult, expectedResult);
            }
            //case 3: operand1 * operand2 = findingResult
            else
            {
                operand1 = int.Parse(equationArray[0]);
                operand2 = int.Parse(equationArray[1]);
                expectedResult = equationArray[2];
                string calculatedResult = helper.Calculation(operand1, operand2, "*");
                if(calculatedResult.Equals("false"))
                    return -1;
                return helper.FindMissingDigit(calculatedResult, expectedResult);
            }
            throw new NotImplementedException();
        }
    }
}
