using System;
using System.Collections.Generic;
using System.Linq;

class GroupNumbers
{
    static void Main()
    {
        var rowElements = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        var firstQueue = new Queue<int>();
        var secondQueue = new Queue<int>();
        var thirdQueue = new Queue<int>();

        foreach (var number in rowElements)
        {
            var remainder = number % 3;
            switch (Math.Abs(remainder))
            {
                case 0:
                    firstQueue.Enqueue(number);
                    break;
                case 1:
                    secondQueue.Enqueue(number);
                    break;
                default:
                    thirdQueue.Enqueue(number);
                    break;
            }
        }

        Console.WriteLine(String.Join(" ", firstQueue));
        Console.WriteLine(String.Join(" ", secondQueue));
        Console.WriteLine(String.Join(" ", thirdQueue));

    }
}