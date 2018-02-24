using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CryptoBlockchain
{
    static void Main()
    {
        var pattern = @"\[\D*(?<first>(\d{3})+)\D*\]|\{\D*(?<second>(\d{3})+)\D*\}";
        Regex regex = new Regex(pattern);

        var numbers = int.Parse(Console.ReadLine());
        var criptoString = "";

        for (int i = 0; i < numbers; i++)
        {
            criptoString += Console.ReadLine().Trim();
        }

        MatchCollection matches = regex.Matches(criptoString);
        var digitGroups = new List<int>();
        foreach (Match match in matches)
        {
            var size = match.Length;
            var first = match.Groups["first"];
            var second = match.Groups["second"];
            var forAdd = (first.Success ? first : second).ToString();

            for (int i = 0; i < forAdd.Length; i += 3)
            {
                digitGroups.Add(int.Parse(forAdd.Substring(i, 3)));
            }

            foreach (var digit in digitGroups)
            {
                var symbol = (char)(digit - size);
                Console.Write(symbol);
            }
            digitGroups.Clear();
        }

        Console.WriteLine();
    }
}