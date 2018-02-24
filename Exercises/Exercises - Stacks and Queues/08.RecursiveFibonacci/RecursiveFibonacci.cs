using System;

class RecursiveFibonacci
{
    private static long[] calculatedFibonacci;
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        calculatedFibonacci = new long[n];
        Console.WriteLine(GetFibonacci(n));
    }

    private static long GetFibonacci(int n)
    {
        if (n <= 2)
        {
            return 1;
        }

        if (calculatedFibonacci[n - 1] != 0)
        {
            return calculatedFibonacci[n - 1];
        }
        return calculatedFibonacci[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
    }
}