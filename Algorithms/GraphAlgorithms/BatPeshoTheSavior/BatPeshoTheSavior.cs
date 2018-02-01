using System;
using System.Collections.Generic;

public class BatPeshoTheSavior
{
    public static void Main()
    {
        string startWord = Console.ReadLine();
        string endWord = Console.ReadLine();
        int wordLength = startWord.Length;
        var words = new HashSet<string>();

        while (true)
        {
            string currentWord = Console.ReadLine();

            if (string.IsNullOrEmpty(currentWord))
            {
                break;
            }

            words.Add(currentWord);
        }

        int numberOfTransformations = BfsTraverse(words, startWord, endWord);

        Console.WriteLine(numberOfTransformations == 0 ? "NO" : numberOfTransformations.ToString());
    }

    public static int BfsTraverse(HashSet<string> words, string startWord, string toWord)
    {
        var queue = new Queue<KeyValuePair<string, int>>();
        var usedWords = new HashSet<string>();
        queue.Enqueue(new KeyValuePair<string, int>(startWord, 0));

        while (queue.Count > 0)
        {
            var lastWord = queue.Dequeue();

            if (lastWord.Key == toWord)
            {
                return lastWord.Value;
            }

            if (usedWords.Contains(lastWord.Key))
            {
                continue;
            }

            usedWords.Add(lastWord.Key);

            var adjacentWords = FindAdjacentWords(lastWord.Key, words);
            foreach (var adjacentWord in adjacentWords)
            {
                queue.Enqueue(new KeyValuePair<string, int>(adjacentWord, lastWord.Value + 1));
            }
        }

        return 0;
    }

    private static IEnumerable<string> FindAdjacentWords(string lastWord, HashSet<string> words)
    {
        var adjacentWords = new List<string>();

        foreach (var word in words)
        {
            if (IsValidWord(lastWord, word))
            {
                adjacentWords.Add(word);
            }
        }

        return adjacentWords;
    }

    /// <summary>
    /// Accepts 2 different lowercased words and returns true if only one letter differentiates them
    /// </summary>
    public static bool IsValidWord(string fromWord, string toWord)
    {
        bool foundOneChangingCharacter = false;

        for (int i = 0; i < fromWord.Length; i++)
        {
            if (fromWord[i] != toWord[i] && !foundOneChangingCharacter)
            {
                foundOneChangingCharacter = true;
            }
            else if (fromWord[i] != toWord[i] && foundOneChangingCharacter)
            {
                return false;
            }
        }

        // If only one changing char was found will return true; else false
        return foundOneChangingCharacter;
    }
}
