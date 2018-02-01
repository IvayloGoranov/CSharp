using System;
using System.Collections.Generic;

public class PrefixComparer : Comparer<string>
{
    public override int Compare(string firstString, string secondString)
    {
        int minLegth = Math.Min(firstString.Length, secondString.Length);
        for (int i = 0; i < minLegth; i++)
        {
            if (firstString[i] > secondString[i])
            {
                return 1;
            }
            else if (firstString[i] < secondString[i])
            {
                return -1;
            }
        }

        if (firstString.Length > secondString.Length)
        {
            return 1;
        }
        else if (firstString.Length < secondString.Length)
        {
            return -1;
        }

        return 0;
    }
}
