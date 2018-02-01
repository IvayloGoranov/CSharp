using System;
using System.Text;

public class Parenthesis
{
    private static readonly StringBuilder result = new StringBuilder();
    private static int n;
    private static int openingCount;
    private static int closingCount;
    private static char[] output;

    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        output = new char[n * 2];
        output[0] = '(';
        openingCount++;

        GenerateParenthesis(1);
        Console.Write(result);
    }

    private static void GenerateParenthesis(int index)
    {
        if (index == output.Length)
        {
            result.AppendLine(string.Join("", output));
            return;
        }

        if (openingCount < n)
        {
            output[index] = '(';
            openingCount++;
            GenerateParenthesis(index + 1);
            openingCount--;
        }

        if (closingCount < openingCount)
        {
            output[index] = ')';
            closingCount++;
            GenerateParenthesis(index + 1);
            closingCount--;
        }
    }
}
