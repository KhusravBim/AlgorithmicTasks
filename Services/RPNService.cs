using System.Text;

namespace AlgorithmicTasks.Services;

public class RPNService
{
    public static double GetRPNResult(string input)
    {
        double result = 0;
        var temp = new Stack<double>();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                var a = string.Empty;

                while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                {
                    a += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                temp.Push(double.Parse(a));
                i--;
            }
            else if (IsOperator(input[i]))
            {
                var a = temp.Pop();
                var b = temp.Pop();

                switch (input[i])
                {
                    case '+': result = b + a; break;
                    case '-': result = b - a; break;
                    case '*': result = b * a; break;
                    case '/': result = b / a; break;
                    case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                }
                temp.Push(result);
            }
        }
        return temp.Peek();
    }

    static private bool IsDelimeter(char c)
    {
        if ((" =".IndexOf(c) != -1))
            return true;
        return false;
    }

    public static string ConvertFromRPN(string input)
    {
        var stack = new Stack<char>();
        var str = input.Replace(" ", string.Empty);
        var expression = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            var x = str[i];
            if (x == '(')
                stack.Push(x);
            else if (x == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                    expression.Append(stack.Pop());
                stack.Pop();
            }
            else if (IsOperandus(x))
            {
                expression.Append(x);
            }
            else if (IsOperator(x))
            {
                while (stack.Count > 0 && stack.Peek() != '(' && Prior(x) <= Prior(stack.Peek()))
                    expression.Append(stack.Pop());
                stack.Push(x);
            }
            else
            {
                var y = stack.Pop();
                if (y != '(')
                    expression.Append(y);
            }
        }
        while (stack.Count > 0)
        {
            expression.Append(stack.Pop());
        }
        return expression.ToString();
    }

    static bool IsOperator(char c) => (c == '-' || c == '+' || c == '*' || c == '/');

    static bool IsOperandus(char c) => (c >= '0' && c <= '9' || c == '.');
    static int Prior(char c)
    {
        switch (c)
        {
            case '=':
                return 1;
            case '+':
                return 2;
            case '-':
                return 2;
            case '*':
                return 3;
            case '/':
                return 3;
            case '^':
                return 4;
            default:
                throw new ArgumentException("Rossz parameter");
        }
    }
}