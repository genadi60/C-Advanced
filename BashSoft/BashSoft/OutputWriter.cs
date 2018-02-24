using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {

        }

        public static void WriteMessageOnNewLine(string message)
        {

        }

        public static void WriteEmptyLine()
        {

        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);
        }
    }
}
