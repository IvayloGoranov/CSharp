using System;

namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type:text/html\r\n\r\n");
            Console.WriteLine("<form action=\"Calculator.exe\" method=\"post\">");
            Console.WriteLine("<input type=\"text\" name=\"operandOne\"/>");
            Console.WriteLine("<input type=\"text\" name=\"sign\"/>");
            Console.WriteLine("<input type=\"text\" name=\"operandTwo\"/>");
            Console.WriteLine("<input type=\"submit\"value=\"Calculate\"/>");
            Console.WriteLine("</form>");

            string post = Console.ReadLine();
            if (post != null)
            {
                string[] paramPairs = post.Split(new char[] { '&', '=' }, StringSplitOptions.RemoveEmptyEntries);
                double operandOne = double.Parse(paramPairs[1]);
                string sign = paramPairs[3];
                double operandTwo = double.Parse(paramPairs[5]);
                switch (sign)
                {
                    case "%2B": // + sign
                        Console.WriteLine("Result: " + (operandOne + operandTwo));
                        break;
                    case "-": // - sign
                        Console.WriteLine("Result: " + (operandOne - operandTwo));
                        break;
                    case "*": // * sign
                        Console.WriteLine("Result: " + (operandOne * operandTwo));
                        break;
                    case "%2F": // / sign
                        Console.WriteLine("Result: " + (operandOne / operandTwo));
                        break;
                    default:
                        Console.WriteLine("Invalid sign!");
                        break;
                }
            }
        }
    }
}
