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
            string[] input = equation.Split('*','=');                      //split the equation
            int counter;
            int num1, num2, formNumber;

            //check input1 and input2 and missing digit number
            //case 1: number * number = missing digit number
            if(Int32.TryParse(input[0], out counter) && Int32.TryParse(input[1], out counter)) 
            {
                num1 = Int32.Parse(input[0]);
                num2 = Int32.Parse(input[1]);
                string result = (num1*num2).ToString();
                //checking Invalid Input values
                if(result.Length != input[2].Length)
                {
                    return -1;
                }
                else
                {
                    int index = input[2].IndexOf('?');

                    //Check valid equation with extra ?
                    if(index > result.Length)
                        return -1;

                    formNumber = Int32.Parse(input[2].Replace('?',result[index]));

                    //check final result
                    if(num1 * num2 == formNumber)
                        return Int32.Parse(result[index].ToString());
                    return -1;
                }
            }

            //case 2: missing digit number * number = number
            else if(Int32.TryParse(input[1], out counter) && Int32.TryParse(input[2], out counter))
            {
                num1 = Int32.Parse(input[1]);
                num2 = Int32.Parse(input[2]);
                string result = (num2/num1).ToString();
                //checking Invalid Input values
                if(result.Length < input[0].Length)
                {
                    return -1;
                }
                else
                {
                    int index = input[0].IndexOf('?');

                    //Check valid equation with extra ?
                    if(index > result.Length)
                        return -1;

                    formNumber = Int32.Parse(input[0].Replace('?',result[index]));

                    //check final result
                    if(num2 / num1 == formNumber)
                        return Int32.Parse(result[index].ToString());
                    return -1;
                }
            }

            //case 3: number * missing digit number = number
            else
            {
                num1 = Int32.Parse(input[0]);
                num2 = Int32.Parse(input[2]);
                string result = (num2/num1).ToString();
                //checking Invalid Input values
                if(result.Length < input[1].Length)
                {
                    return -1;
                }
                else
                {
                    int index = input[1].IndexOf('?');

                    //Check valid equation with extra ?
                    if(index > result.Length)
                        return -1;

                    formNumber = Int32.Parse(input[1].Replace('?',result[index]));

                    //check final result
                    if(num1 * formNumber == num2)
                        return Int32.Parse(result[index].ToString());
                    return -1;
                }
            }
            throw new NotImplementedException();
        }
    }
}
