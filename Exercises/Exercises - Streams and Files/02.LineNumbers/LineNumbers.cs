using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        using (var fileStream = new FileStream("../text.txt", FileMode.Open, FileAccess.Read))
        {
            using (var stream = new StreamReader(fileStream))
            {
                using (var writeStream = new FileStream("./output.txt", FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(writeStream))
                    {
                        var lineNumber = 1;
                        string line = "";
                        while (null != (line = stream.ReadLine()))
                        {
                            writer.WriteLine($"Line {lineNumber}: {line}");
                            lineNumber++;
                        }
                    }
                }
            }
        }
    }
}
