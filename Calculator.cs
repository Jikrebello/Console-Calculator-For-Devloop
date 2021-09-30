using System;
using System.Linq;

namespace Console_Calculator_For_Devloop
{
    class Calculator
    {
        readonly bool isFinished = false;

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
            string cleanstring = new string(_input.Where(c => char.IsDigit(c) || c == '+' || c == '-' || c == '/' || c == '*').ToArray());
            return cleanstring;
        }

        private void EvaluateExpression(string _cleanString)
        {
            //char operatorValue = ' ';
            int operatorPosition;
            string rightSideValue;
            string leftSideValue;

            if (_cleanString.Contains('+'))
            {
                operatorPosition = _cleanString.IndexOf('+');
                leftSideValue = _cleanString.Substring(0, operatorPosition);
                //operatorValue = _cleanString[operatorPosition];
                rightSideValue = _cleanString.Substring(operatorPosition + 1);
                Addition(Convert.ToInt32(leftSideValue), Convert.ToInt32(rightSideValue));
            }
            else if (_cleanString.Contains('-'))
            {
                operatorPosition = _cleanString.IndexOf('-');
                leftSideValue = _cleanString.Substring(0, operatorPosition);
                //operatorValue = _cleanString[operatorPosition];
                rightSideValue = _cleanString.Substring(operatorPosition + 1);
                Subtraction(Convert.ToInt32(leftSideValue), Convert.ToInt32(rightSideValue));
            }
            else if (_cleanString.Contains('*'))
            {
                operatorPosition = _cleanString.IndexOf('*');
                leftSideValue = _cleanString.Substring(0, operatorPosition);
                //operatorValue = _cleanString[operatorPosition];
                rightSideValue = _cleanString.Substring(operatorPosition + 1);
                Multiplication(Convert.ToInt32(leftSideValue), Convert.ToInt32(rightSideValue));
            }
            else if (_cleanString.Contains('/'))
            {
                operatorPosition = _cleanString.IndexOf('/');
                leftSideValue = _cleanString.Substring(0, operatorPosition);
                //operatorValue = _cleanString[operatorPosition];
                rightSideValue = _cleanString.Substring(operatorPosition + 1);
                Division(Convert.ToInt32(leftSideValue), Convert.ToInt32(rightSideValue));
            }
        }

        void Addition(int _leftSide, int _rightSide)
        {
            int result = _leftSide + _rightSide;
            Console.WriteLine(_leftSide + " + " + _rightSide + " = " + result);
        }

        void Subtraction(int _leftSide, int _rightSide)
        {
            int result = _leftSide - _rightSide;
            Console.WriteLine(_leftSide + " - " + _rightSide + " = " + result);
        }

        void Multiplication(int _leftSide, int _rightSide)
        {
            int result = _leftSide * _rightSide;
            Console.WriteLine(_leftSide + " * " + _rightSide + " = " + result);
        }

        void Division(int _leftSide, int _rightSide)
        {
            int result = _leftSide / _rightSide;
            Console.WriteLine(_leftSide + " / " + _rightSide + " = " + result);
        }

    }
}
