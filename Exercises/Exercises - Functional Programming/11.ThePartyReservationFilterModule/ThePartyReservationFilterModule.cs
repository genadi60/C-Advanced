using System;
using System.Collections.Generic;
using System.Linq;

class ThePartyReservationFilterModule
{
    static void Main()
    {
        var members = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var partyMembers = new List<string>();
        partyMembers = members.ToList();
        var predicates = new List<string>();
        while (true)
        {
            var input = Console.ReadLine();
            if ("Print".Equals(input))
            {
                break;
            }

            var commandData = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var command = commandData[0];
            var commandCondition = commandData[1];
            var commandValue = commandData[2];
            switch (command)
            {
                case "Remove filter":
                    if (predicates.Contains(commandCondition + ";" + commandValue))
                    {
                        predicates.Remove(commandCondition + ";" + commandValue);
                    }
                    break;
                case "Add filter":
                    predicates.Add(commandCondition + ";" + commandValue);
                    break;
            }
        }


        if (partyMembers.Count > 0)
        {
            foreach (var item in predicates)
            {
                var conditionValuePair = item.Split(new[] {";"}, StringSplitOptions.None);
                var condition = conditionValuePair[0];
                var value = conditionValuePair[1];

                partyMembers = partyMembers
                    .Where(s => !CreatePredicate(condition, value)(s))
                    .ToList();
            }
            var result = string.Join(" ", partyMembers);
            Console.WriteLine(result);
        }
    }

    static Predicate<string> CreatePredicate(string commandCondition, string commandValue)
    {
        switch (commandCondition)
        {
            case "Starts with":
                return s => s.StartsWith(commandValue);
            case "Ends with":
                return s => s.EndsWith(commandValue);
            case "Contains":
                return s => s.Contains(commandValue);
            default:
                return s => s.Length == int.Parse(commandValue);
        }
    }
}