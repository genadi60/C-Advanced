using System.Text;

namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    static class OutputWriter
    {
        static OutputWriter()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);  
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
