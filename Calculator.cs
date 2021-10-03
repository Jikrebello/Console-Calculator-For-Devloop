using System;
using System.Collections.Generic;
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
            Console.WriteLine("Type \"end\" to exit the program.");
            while (!isFinished)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                    break;
                else
                {
                    string cleanString = IsExpressionValid(input);
                    //EvaluateExpression(ref cleanString);
                    EvaluateMultiExpressions(ref cleanString);
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
            // Take the input string and remove all junk values (non numeric chars except + - / *) --- ADDED ( AND ) FOR MULTI EXPRESSIONS ---
            string cleanstring = new string(_input.Where(c => char.IsDigit(c) || c == '+' || c == '-' || c == '/' || c == '*' || c == '(' || c == ')').ToArray());
            return cleanstring;
        }

        /// <summary>
        /// Breaks the string into a left hand side, middle operator and a right hand side.
        /// </summary>
        /// <param name="_cleanString"></param>
        void EvaluateExpression(ref string _cleanString)
        {
            int leftSide = 0;
            int rightSide = 0;
            int operatorPosition;
            char operatorValue = ' ';

            for (int i = 0; i < _cleanString.Length; i++)
            {
                // True for the first non numeric number in the string.
                if (!char.IsDigit(_cleanString[i]))
                {
                    // 1) Get the operator in the string.
                    operatorValue = _cleanString[i];
                    // 2) Get the 0 indexed position of the operator in the string.
                    operatorPosition = _cleanString.IndexOf(operatorValue);
                    // 3) Use the position to subString the left and right hand sides of the expression.
                    leftSide = Convert.ToInt32(_cleanString.Substring(0, operatorPosition));
                    rightSide = Convert.ToInt32(_cleanString.Substring(operatorPosition + 1));
                    break;
                }
            }
            SolveExpressionAndDisplay(leftSide, rightSide, operatorValue);
        }

        void EvaluateMultiExpressions(ref string _cleanString)
        {
            // Holds the indexed positions of where the opening and closing brackets are.
            List<Tuple<int, int>> bracketPositions = new List<Tuple<int, int>>();
            // Holds the index of an arithmetic operator and the type it is.
            Dictionary<int, char> operatorPositions = new Dictionary<int, char>();


            for (int expression = 0; expression < _cleanString.Length; expression++)
            {
                int openBracketPosition;
                int closeBracketPosition;

                for (int i = 0; i < _cleanString.Length; i++)
                {
                    if (_cleanString[i] == '(')
                        openBracketPosition = i;
                    else if (_cleanString[i] == ')')
                        closeBracketPosition = i;


                }
            }



            for (int i = 0; i < _cleanString.Length; i++)
            {
                // Get the indexes of all non-numeric values in the (multi) expression.
                switch (_cleanString[i])
                {
                    case '(': // ---OPEN BRACKET---


                        break;
                    case ')': // ---CLOSED BRACKET---
                        bracketPositions.Add(i);
                        break;
                    case '/': // ---DIVISION OPERATOR---
                        operatorPositions.Add(i, '/');
                        break;
                    case '*': // ---MULTIPLICATION OPERATOR---
                        operatorPositions.Add(i, '*');
                        break;
                    case '+': // ---ADDITION OPERATOR---
                        operatorPositions.Add(i, '+');
                        break;
                    case '-': // ---SUBTRACTION OPERATOR---
                        operatorPositions.Add(i, '-');
                        break;
                }
            }

            // check that we always have 2 pairs of brackets
            if (bracketPositions.Count % 2 != 0)
            {
                Console.WriteLine("Missing a bracket");
                return;
            }

            SolveBrackets(bracketPositions, ref _cleanString);


        }

        void SolveBrackets(List<int> _bracketPositions, ref string _expression)
        {
            for (int i = _bracketPositions[0]; i < _bracketPositions[1]; i++)
            {

            }

        }

        /// <summary>
        /// Solves the expression based on the value of _operatorValue
        /// </summary>
        /// <param name="_leftSide">The left hand side value of the expression</param>
        /// <param name="_rightSide">The right hand side value of the expression</param>
        /// <param name="_operatorValue">The arithmetic operator that effects the left and right hand side of the expression.</param>
        void SolveExpressionAndDisplay(int _leftSide, int _rightSide, char _operatorValue)
        {
            int result;

            switch (_operatorValue)
            {

                case '+': // ---ADDITION---
                    result = _leftSide + _rightSide;
                    Console.WriteLine(_leftSide + " + " + _rightSide + " = " + result);
                    break;


                case '-': // ---SUBTRACTION---
                    result = _leftSide - _rightSide;
                    Console.WriteLine(_leftSide + " - " + _rightSide + " = " + result);
                    break;


                case '*': // ---MULTIPLICATION---
                    result = _leftSide * _rightSide;
                    Console.WriteLine(_leftSide + " * " + _rightSide + " = " + result);
                    break;

                case '/': // ---DIVISION---
                    result = _leftSide / _rightSide;
                    Console.WriteLine(_leftSide + " / " + _rightSide + " = " + result);
                    break;


                default:// --- EMPTY INPUT ---
                    Console.WriteLine("Please enter a valid expression.");
                    break;
            }
        }

    }
}
