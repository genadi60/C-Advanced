using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var wordCount = new Dictionary<string, int>();
        var wordsList = new List<string>();

        using (var targetStream = new FileStream("./words.txt", FileMode.Open, FileAccess.Read))
        {
            using (var target = new StreamReader(targetStream))
            {
                string line = "";
                while (null != (line = target.ReadLine()))
                {
                    if (!wordCount.ContainsKey(line))
                    {
                        wordCount[line] = 0;
                        wordsList.Add(line);
                    }
                }
            }
        }

        using (var sourceStream = new FileStream("../text.txt", FileMode.Open, FileAccess.Read))
        {
            using (var stream = new StreamReader(sourceStream))
            {
                string line = "";
                while (null != (line = stream.ReadLine()))
                {
                    foreach (var word in wordsList)
                    {
                        var pattern = $"[^a-z]{word.ToLower()}[^a-z]";
                        Regex regex = new Regex(pattern);
                        MatchCollection match = regex.Matches(line.ToLower());
                        wordCount[word] += match.Count;
                    }
                }
            }
        }

        using (var writeStream = new FileStream("./result.txt", FileMode.Create, FileAccess.Write))
        {
            using (var writer = new StreamWriter(writeStream))
            {
                foreach (KeyValuePair<string, int> item in wordCount.OrderByDescending(kvp => kvp.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}