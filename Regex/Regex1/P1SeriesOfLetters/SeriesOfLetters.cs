using System;
using System.Text;

namespace P1SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            output.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == text[i - 1])
                {
                    continue;
                }

                output.Append(text[i]);
            }

            Console.WriteLine(output);
        }
    }
}
