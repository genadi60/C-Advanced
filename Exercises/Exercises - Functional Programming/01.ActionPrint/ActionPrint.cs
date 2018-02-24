using System;
using System.Runtime.InteropServices;

class ActionPrint
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        Action<string> print = x => Console.WriteLine(x);
        foreach (var item in input)
        {
            print(item);
        }
    }
}