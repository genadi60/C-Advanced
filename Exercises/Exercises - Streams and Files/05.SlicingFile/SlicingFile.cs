using System;
using System.Collections.Generic;
using System.IO;

class SlicingFile
{
    private const int bufferSize = 4096;
    static void Main()
    {
        int parts = 5;
        string sourceFile = "../sliceMe.mp4";
        string destinationDirectory = "./";
        var partsOfFile = Slice(sourceFile, destinationDirectory, parts);
        Assemble(partsOfFile, destinationDirectory);
    }

    static List<string> Slice(string sourceFile, string destinationDirectory, int parts)
    {
        List<string> partsOfFile = new List<string>();
        using (var reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            string extention = sourceFile.Substring(sourceFile.LastIndexOf('.'));

            long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

            long currentPieceSize = 0;

            for (int counter = 1; counter <= parts; counter++)
            {
                string destinationFile = $"Part-{counter}{extention}";

                partsOfFile.Add(destinationDirectory + destinationFile);

                using (var writer = new FileStream(destinationDirectory + destinationFile, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[bufferSize];
                    int size = 0;
                    while ((size = reader.Read(buffer, 0, bufferSize)) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                        currentPieceSize += bufferSize;

                        if (currentPieceSize >= pieceSize)
                        {
                            currentPieceSize = 0;
                            size = 0;
                            break;
                        }
                    }
                    writer.Write(buffer, 0, size);
                }
            }
        }
        return partsOfFile;
    }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        string extention = files[0].Substring(files[0].LastIndexOf('.'));

        string destinationFile = $"{destinationDirectory}Assembled{extention}";

        using (var writer = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[bufferSize];

            foreach (var file in files)
            {
                using (var reader = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    int size = 0;
                    while ((size = reader.Read(buffer, 0, bufferSize)) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                    }
                    writer.Write(buffer, 0, size);
                }
            }
        }
    }
}