using System;
using System.Text.RegularExpressions;

namespace P2ReplaceTag
{
    class ReplaceTag
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string ahrefPattern = "<a href=(\"|')";
            string endHrefPattern = "(\"|'>)";
            string endAPattern = "</a>";

            Regex regex = new Regex(ahrefPattern);
            Match match = regex.Match(text);
            string ahrefReplacement = "[URL=";
            text = regex.Replace(text, ahrefReplacement);

            regex = new Regex(endHrefPattern);
            match = regex.Match(text);
            string endHrefReplacement = "]";
            text = regex.Replace(text, endHrefReplacement);

            regex = new Regex(endAPattern);
            match = regex.Match(text);
            string endAReplacement = "[/URL]";
            text = regex.Replace(text, endAReplacement);

            Console.WriteLine(text);
        }
    }
}
