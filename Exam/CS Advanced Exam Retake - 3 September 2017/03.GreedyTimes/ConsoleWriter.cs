using System;

public class ConsoleWriter
{
    public ConsoleWriter()
    {
    }

    public void WriteLine(object input)
    {
        Console.WriteLine(input);
    }

    public void Write(object input)
    {
        Console.Write(input);
    }
}