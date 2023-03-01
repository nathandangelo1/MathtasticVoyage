
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

internal class MathProblem
{
    private string _probInfix = null;
    private double _answer = 0;
    private double _userAns = 0;
    private bool _isCorrect = false;

    public string ProbInfix 
    { 
        get
        {
            return _probInfix;
        }
        set
        {
            _probInfix= value;
        } 
    }

    public double Answer 
    { 
        get
        {
            return _answer;
        } 
        set
        {
            _answer = value;
        } 
    }

    public double UserAns 
    {
        get
        {
            return _userAns;
        }
        set
        {
            _userAns = value;
        }
    }

    public bool IsCorrect 
    { 
        get
        {
            if ( _userAns == _answer) 
            {
                _isCorrect = true;
                return true;
            }
            else
            {
                _isCorrect = false;
                return false;
            }
        }
    }




    /* c# implementation to convert
    infix expression to postfix*/
    // Note that here we use Stack
    // class for Stack operations

    // A utility function to return
    // precedence of a given operator
    // Higher returned value means higher precedence
    internal static int Prec(char ch)
    {
        switch (ch)
        {
            case '+':
            case '-':
                return 1;

            case '*':
            case '/':
                return 2;

            case '^':
                return 3;
        }
        return -1;
    }

    // The main method that converts given infix expression
    // to postfix expression.
    public static string infixToPostfix(string exp)
    {
        // initializing empty String for result
        string result = "";

        // initializing empty stack
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < exp.Length; ++i)
        {
            char c = exp[i];

            // If the scanned character is an
            // operand, add it to output.
            if (char.IsLetterOrDigit(c))
            {
                if(i+1 != exp.Length)
                {
                    char cPlus = exp[i + 1];
                    if (char.IsLetterOrDigit(cPlus))
                    {
                        result += c;
                    }
                    else
                    {
                        result += c + " ";
                    }
                }
                else
                {
                    result += c + " ";
                }
                
            }

            // If the scanned character is an '(',
            // push it to the stack.
            else if (c == '(')
            {
                stack.Push(c);
            }

            // If the scanned character is an ')',
            // pop and output from the stack
            // until an '(' is encountered.
            else if (c == ')')
            {
                while (stack.Count > 0
                    && stack.Peek() != '(')
                {
                    result += stack.Pop() + " ";
                }

                if (stack.Count > 0
                    && stack.Peek() != '(')
                {
                    return "Invalid Expression"; // invalid
                                                 // expression
                }
                else
                {
                    stack.Pop();
                }
            }
            else // an operator is encountered
            {
                if (c != ' ')
                {
                    while (stack.Count > 0
                        && Prec(c) <= Prec(stack.Peek()))
                    {
                        result += stack.Pop() + " ";
                    }
                    stack.Push(c);
                }
            }
        }

        // pop all the operators from the stack
        while (stack.Count > 0)
        {
            result += stack.Pop() + " ";
        }

        return result;
    }

    // Evaluates Post-Fix Notated Equations using a Stack
    public static double PostFixEvaluator(string expression)
    {
        double number;
        Stack<double> expStack = new Stack<double>();
        string exp = expression;

        exp = exp.TrimEnd();

        // split expression on space
        string[] expArr = exp.Split(" ");

        // Loop through each item in expression
        foreach (string item in expArr)
        {
            // If the item is a number
            if (double.TryParse(item, out number))
            {
                // Push to stack
                expStack.Push(number);
            }
            else // If not a number,
            {
                // Pop two from the stack
                double op2 = expStack.Pop();
                double op1 = expStack.Pop();

                // Conduct operations
                if (item == "+")
                {
                    double sum = Add(op1, op2);
                    expStack.Push(sum);
                }
                if (item == "-")
                {
                    double diff = Subtract(op1, op2);
                    expStack.Push(diff);
                }
                if (item == "*" || item == "x")
                {
                    double product = Multiply(op1, op2);
                    expStack.Push(product);
                }
                if (item == "/" || item == "÷" || item == "\\")
                {
                    double quotient = Divide(op1, op2);
                    expStack.Push(quotient);
                }
            }
        }

        // Update the text box txtResult's text field
        return expStack.Pop();

    }// End Evaluator
    private static double Add(double op1, double op2)
    {
        return op1 + op2;
    }
    private static double Subtract(double op1, double op2)
    {
        return op1 - op2;
    }
    private static double Multiply(double op1, double op2)
    {
        return op1 * op2;
    }
    private static double Divide(double op1, double op2)
    {
        return op1 / op2;
    }

}



