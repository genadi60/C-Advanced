using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

class ZippingSlicedFiles
{
    private const int bufferSize = 4096;

    static void Main()
    {
        int parts = 5;
        string sourceFile = "../sliceMe.mp4";
        string destinationDirectory = "./";
        var partsOfFile = SliceAndCompress(sourceFile, destinationDirectory, parts);
        DecompresseAndAssemble(partsOfFile, destinationDirectory);
    }

    static List<string> SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
    {
        List<string> partsOfFile = new List<string>();
        using (var reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            string extention = sourceFile.Substring(sourceFile.LastIndexOf('.'));

            long pieceSize = (long) Math.Ceiling((double) reader.Length / parts);

            long currentPieceSize = 0;

            for (int counter = 1; counter <= parts; counter++)
            {
                string destinationFile = $"Part-{counter}{extention}.gz";

                partsOfFile.Add(destinationDirectory + destinationFile);

                using (var writer = new GZipStream(new FileStream(destinationDirectory + destinationFile, FileMode.Create, FileAccess.Write),
                        CompressionLevel.Optimal))
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

    static void DecompresseAndAssemble(List<string> files, string destinationDirectory)
    {
        string fileWitheExtention = files[0].Substring(0,files[0].LastIndexOf('.'));
        string extention = fileWitheExtention.Substring(fileWitheExtention.LastIndexOf('.'));

        string destinationFile = $"{destinationDirectory}DecompressedAndAssembled{extention}";

        using (var writer = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[bufferSize];

            foreach (var file in files)
            {
                using (var reader = new GZipStream(new FileStream(file, FileMode.Open, FileAccess.Read), CompressionMode.Decompress))
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