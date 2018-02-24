using System;
using System.Collections.Generic;
using System.Linq;

class HitList
{
    static void Main()
    {
        var infoIndex = int.Parse(Console.ReadLine());
        var people = new Dictionary<string, Dictionary<string, string>>();
        while (true)
        {
            var input = Console.ReadLine();
            if ("end transmissions".Equals(input))
            {
                break;
            }

            var inputItems = input.Split('=');
            var name = inputItems[0];
            var items = inputItems[1].Split(';').ToList();
            for (int i = 0; i < items.Count; i++)
            {
                var kvp = items[i].Split(':');
                var key = kvp[0];
                var value = kvp[1];
                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }
                people[name][key] = value;
            }
             
            
        }

        var info = 0;
        var command = Console.ReadLine().Split(' ');
        Console.WriteLine($"Info on {command[1]}:");
        foreach (var items in people[command[1]].OrderBy(x => x.Key))
        {
            info += items.Key.Length + items.Value.Length;
            Console.WriteLine($"---{items.Key}: {items.Value}");
        }

        Console.WriteLine($"Info index: {info}");
        if (info < infoIndex)
        {
            Console.WriteLine($"Need {infoIndex - info} more info.");
        }
        else
        {
            Console.WriteLine($"Proceed");
        }
    }
}