using System;
using System.Collections.Generic;
using System.Linq;

class InfernoIII
{
    static void Main()
    {
        var userStrings = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        var numbers = userStrings
            .Select(int.Parse)
            .ToList();
        var conditions = new List<string>();
        var filteredNumbersIndexes = new List<int>();
        while (true)
        {
            var input = Console.ReadLine();
            if ("Forge".Equals(input))
            {
                break;
            }

            var commandData = input.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
            var command = commandData[0];
            var commandCondition = commandData[1];
            var commandValue = commandData[2];
            switch (command)
            {
                case "Reverse":
                    if (conditions.Contains(commandCondition + ":" + commandValue))
                    {
                        conditions.Remove(commandCondition + ":" + commandValue);
                    }

                    break;
                case "Exclude":
                    conditions.Add(commandCondition + ":" + commandValue);
                    break;
            }
        }

        if (conditions.Count > 0)
        {
            foreach (var condition in conditions)
            {
                var commandData = condition.Split(new[] {":"}, StringSplitOptions.None);
                var command = commandData[0];
                var commandValue = int.Parse(commandData[1]);
                var sum = 0L;
                for (int counter = 0; counter < numbers.Count; counter++)
                {
                    switch (command)
                    {
                        case "Sum Left":
                            sum = counter > 0 ? numbers[counter] + numbers[counter - 1] : numbers[counter];
                            if (sum == commandValue)
                            {
                                filteredNumbersIndexes.Add(counter);
                                sum = 0;
                            }
                            break;
                        case "Sum Right":
                            sum = counter < numbers.Count - 1 ? numbers[counter] + numbers[counter + 1] : numbers[counter];

                            if (sum == commandValue)
                            {
                                filteredNumbersIndexes.Add(counter);
                                sum = 0;
                            }
                            break;
                        case "Sum Left Right":
                            sum = counter > 0 ? numbers[counter] + numbers[counter - 1] : numbers[counter];
                            sum += counter < numbers.Count - 1 ? numbers[counter + 1] : 0;
                            if (sum == commandValue)
                            {
                                filteredNumbersIndexes.Add(counter);
                                sum = 0;
                            }
                            break;
                    }
                }
            }
        }
        numbers = numbers
            .Where(n => !filteredNumbersIndexes.Contains(numbers.IndexOf(n)))
            .ToList();
        Console.WriteLine(string.Join(" ", numbers));
    }
}