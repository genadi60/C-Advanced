using System;
using System.Collections.Generic;
using System.Linq;

class NumberWars
{
    static void Main()
    {
        var firstPlayer = new Queue<string>(Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries));
        var secondPlayer = new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        var turnCounter = 0;
        bool isWinn = false;
        var winner = "";

        Func<string, int> calculateValue = s => int.Parse(s.Substring(0, s.Length - 1));
        Func<string, int> calculateLetter = s => s[s.Length - 1];

        
        while (turnCounter < 1_000_000)
        {
            var firstValue = calculateValue(firstPlayer.Peek());
            var secondValue = calculateValue(secondPlayer.Peek());
            if (firstValue > secondValue)
            {
                firstPlayer.Enqueue(firstPlayer.Dequeue());
                firstPlayer.Enqueue(secondPlayer.Dequeue());
                turnCounter++;
                if (secondPlayer.Count == 0)
                {
                    isWinn = true;
                    winner = "First";
                    break;
                }
                continue;
            }

            if (firstValue < secondValue)
            {
                secondPlayer.Enqueue(secondPlayer.Dequeue());
                secondPlayer.Enqueue(firstPlayer.Dequeue());
                turnCounter++;
                if (firstPlayer.Count == 0)
                {
                    isWinn = true;
                    winner = "Second";
                    break;
                }
                continue;
            }

            if (firstValue == secondValue)
            {
                GetDrawStrategy(firstPlayer, secondPlayer, calculateLetter, calculateValue);
                turnCounter++;
                if (secondPlayer.Count == 0 && firstPlayer.Count > 0)
                {
                    isWinn = true;
                    winner = "First";
                    break;
                }
                if (firstPlayer.Count == 0 && secondPlayer.Count > 0)
                {
                    isWinn = true;
                    winner = "Second";
                    break;
                }
                if (firstPlayer.Count == 0 && secondPlayer.Count == 0)
                {
                    break;
                }
            }
        }

        if (!isWinn && firstPlayer.Count > secondPlayer.Count)
        {
            winner = "First";
            Console.WriteLine($"{winner} player wins after {turnCounter} turns");
            return;
        }
        if(!isWinn && firstPlayer.Count < secondPlayer.Count)
        {
            winner = "Second";
            Console.WriteLine($"{winner} player wins after {turnCounter} turns");
            return;
        }

        if (isWinn)
        {
            Console.WriteLine($"{winner} player wins after {turnCounter} turns");
            return;
        }

        Console.WriteLine($"Draw after {turnCounter} turns");
    }

    private static void GetDrawStrategy(Queue<string> first, Queue<string> second, Func<string, int> calculateLetter, Func<string, int> calculateValue)
    {
        var sumFirstPlayer = 0;
        var sumSecondPlayer = 0;
        var cardFromField = new List<string> {first.Dequeue(), second.Dequeue()};
        
        
        while (true)
        {
            var cardCollect = 0;
            while (first.Count > 0 && second.Count > 0 && cardCollect < 3)
            {
                sumFirstPlayer += calculateLetter(first.Peek());
                sumSecondPlayer += calculateLetter(second.Peek());
                cardFromField.Add(first.Dequeue());
                cardFromField.Add(second.Dequeue());
                cardCollect++;
            }

           
            if (sumFirstPlayer > sumSecondPlayer)
            {
                cardFromField = cardFromField
                    .OrderByDescending(s => calculateValue(s))
                    .ToList();
                foreach (var card in cardFromField)
                {
                    first.Enqueue(card);
                }
                return;
            }

            if (sumFirstPlayer < sumSecondPlayer)
            {
                cardFromField = cardFromField
                    .OrderByDescending(s => calculateValue(s))
                    .ToList();
                foreach (var card in cardFromField)
                {
                    second.Enqueue(card);
                }
                return;
            }

            if (first.Count == 0 || second.Count == 0)
            {
                return;
            }
            sumFirstPlayer = 0;
            sumSecondPlayer = 0;
        }
    }
}
