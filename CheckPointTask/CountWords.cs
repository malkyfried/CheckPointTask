using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CheckPointTask
{
    internal class CountWords
    {
        public static Dictionary<string, int> Count(string filePath)
        {
            Dictionary<string, int> wordCount = [];

            using (StreamReader sr = new(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Remove punctuation marks and split line into words
                    string[] words = Regex.Replace(line, @"[^\w\s]", "").Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        string normalizedWord = word.ToLower(); // Normalize word to lowercase
                        if (wordCount.TryGetValue(normalizedWord, out int value))
                            wordCount[normalizedWord] = ++value;
                        else
                            wordCount[normalizedWord] = 1;
                    }
                }
            }

            return wordCount;
        }
    }
}
