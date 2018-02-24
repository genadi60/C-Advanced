using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        int bufferSize = 4096;
        using (var reader = new FileStream("../copyMe.png", FileMode.Open, FileAccess.Read))
        {
            using (var writer = new FileStream("./copied.png", FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
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