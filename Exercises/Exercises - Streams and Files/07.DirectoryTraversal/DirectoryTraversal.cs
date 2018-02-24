using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        var path = Console.ReadLine();
        var filesDictionary = new Dictionary<string, Dictionary<string, double>>();
        var files = Directory.GetFiles(path);
        for (int counter = 0; counter < files.Length; counter++)
        {
            var file = files[counter];
            var fileInfo = new FileInfo(file);
            var extention = fileInfo.Extension;
            var fileName = file.Substring(file.LastIndexOf('\\') + 1);
            double len = fileInfo.Length / 1024.0;

            if (!filesDictionary.ContainsKey(extention))
            {
                filesDictionary[extention] = new Dictionary<string, double>();
            }

            if (!filesDictionary[extention].ContainsKey(fileName))
            {
                filesDictionary[extention][fileName] = len;
            }
        }
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        if (!path.EndsWith('/'))
        {
            path += '/';
        }
        using (var writer = new StreamWriter(new FileStream($"{path}report.txt", FileMode.Create, FileAccess.Write)))
        {
            foreach (KeyValuePair<string, Dictionary<string, double>> dict in filesDictionary.OrderByDescending(k => k.Value.Count).ThenBy(k => k.Key))
            {
                var extention = dict.Key;
                writer.WriteLine(extention);
                
                foreach (KeyValuePair<string, double> file in dict.Value.OrderBy(k => k.Value))
                {
                    writer.WriteLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }
        }
    }
}