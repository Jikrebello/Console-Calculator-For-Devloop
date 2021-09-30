using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console_Calculator_For_Devloop
{
    class Calculator
    {
        bool isFinished = false;

        public Calculator()
        {
            Console.WriteLine("--- CONSOLE CALCULATOR ---");
            Console.WriteLine("Input a single Addition, Subtraction, Multiplication or Division expression.");
            Console.WriteLine("e.g. \"2 + 2\"");
            Console.WriteLine("Input \"end\" to exit the program.");
            while (!isFinished)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                    break;
                else
                {
                    string cleanString = IsExpressionValid(input);
                    //Console.WriteLine(cleanString);

                    EvaluateExpression(cleanString);
                }
            }
        }

        /// <summary>
        /// Removes all invalid characters from the string.
        /// Valid characters are * \ + - and numbers 0 to 9.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>A arithmetic expression ready for evaluation.</returns>
        private string IsExpressionValid(string _input)
        {
            // Take the input string and remove all junk values that aren’t valid.
            string cleanstring = new string(_input.Where(c => char.IsDigit(c) || c == '+' || c == '-' || c == '\\' || c == '*' 
                                                                              || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' 
                                                                              || c == '5' || c == '6' || c == '7' || c == '8' || c == '9').ToArray());
            return cleanstring;
        }

        private void EvaluateExpression(string _cleanString)
        {
            string leftsideValue = "";
            string rightsideValue = "";
            int operatorPosition = -1;
            char arithmeticOperator = 'U'; // U for undefined

            // loop for the first value the type of operator, and its position in the string.
            for (int i = 0; i < _cleanString.Length; i++)
            {
                leftsideValue += _cleanString[i];
                if (_cleanString[i] == '+')
                {
                    arithmeticOperator = _cleanString[i];
                    operatorPosition = _cleanString[i];
                }
                else if (_cleanString[i] == '-')
                {
                    arithmeticOperator = _cleanString[i];
                    operatorPosition = _cleanString[i];
                }
                else if (_cleanString[i] == '*')
                {
                    arithmeticOperator = _cleanString[i];
                    operatorPosition = _cleanString[i];
                }
                else if (_cleanString[i] == '/')
                {
                    arithmeticOperator = _cleanString[i];
                    operatorPosition = _cleanString[i];
                }
            }

            // clean up the left side value.
            leftsideValue.TrimEnd('+', '-', '\\', '*');

            // loop for the right hand side value, from the position of the operator + 1
            for (int i = operatorPosition; i < _cleanString.Length; i++)
            {
                rightsideValue += _cleanString[i];
            }

            Console.WriteLine("Left side value: " + leftsideValue);
            Console.WriteLine("Operator value: " + arithmeticOperator);
            Console.WriteLine("Right side value: " + rightsideValue);
        }



    }
}
