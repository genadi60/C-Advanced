using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        using (var fileStream = new FileStream("../text.txt", FileMode.Open, FileAccess.Read))
        {
            using (var stream = new StreamReader(fileStream))
            {
                var counter = 0;
                string line = "";
                while (null != (line = stream.ReadLine()))
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}