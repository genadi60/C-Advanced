using System;
using System.Collections.Generic;
using System.Linq;

class PredicateParty
{
    static void Main()
    {
        var members = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var partyMembers = new List<string>();
        partyMembers = members.ToList();
        while (true)
        {
            var input = Console.ReadLine();
            if ("Party!".Equals(input))
            {
                break;
            }

            var commandData = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var command = commandData[0];
            var commandCondition = commandData[1];
            var commandValue = commandData[2];
            switch (command)
            {
                case "Remove":
                    partyMembers = partyMembers
                        .Where(s => !CreatePredicate(commandCondition, commandValue)(s))
                        .ToList();
                break;
                case "Double":
                    var counter = partyMembers.Count;
                    for (int i = 0; i < counter; i++)
                    {
                        if (CreatePredicate(commandCondition, commandValue)(partyMembers[i]))
                        {
                            partyMembers.Insert(i, partyMembers[i]);
                            i++;
                            counter++;
                        }
                    }
                break;
            }
        }

        if (partyMembers.Count > 0)
        {
            var result = string.Join(", ", partyMembers);
            Console.WriteLine($"{result} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    static Predicate<string> CreatePredicate(string commandCondition, string commandValue)
    {
        switch (commandCondition)
        {
            case "StartsWith":
                return s => s.StartsWith(commandValue);
            case "EndsWith":
                return s => s.EndsWith(commandValue);
            default:
                return s => s.Length == int.Parse(commandValue);
        }
    }
}