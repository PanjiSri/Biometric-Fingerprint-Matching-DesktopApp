namespace Tubes3_let_me_seedik;

using System.Collections.Generic;
using System.IO;

public class FileManager
{
    public static List<string> GetFilePaths(string folderPath)
    {
        List<string> files = new List<string>();

        folderPath = Path.Combine(folderPath);

        var filePaths = Directory.GetFiles(folderPath, "*.BMP");


        foreach (var filePath in filePaths)
        {
            files.Add(filePath.Replace("\\", "/"));
        }
        return files;
    }
}
