using System;
using System.Collections.Generic;
using System.Linq;

class CryptoMaster
{
    static void Main()
    {
        var listOfNumbers = new List<int>(Console.ReadLine()
            .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        
        var maxSequence = 1;
        var numersCount = listOfNumbers.Count;

        for (int step = 1; step < numersCount; step++)
        {
            for (int index = 0; index < numersCount; index++)
            {
                var sequenceCounter = 1;
                var currentIndex = index;
                var nextIndex = (currentIndex + step) % numersCount;
                while (listOfNumbers[currentIndex] < listOfNumbers[nextIndex])
                {
                    currentIndex = nextIndex;
                    nextIndex = (nextIndex + step) % numersCount;
                    sequenceCounter++;
                }

                if (maxSequence < sequenceCounter)
                {
                    maxSequence = sequenceCounter;
                }
            }
        }
        Console.WriteLine(maxSequence);
    }
}