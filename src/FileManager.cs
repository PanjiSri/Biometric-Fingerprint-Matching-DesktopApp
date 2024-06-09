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

    public static List<string> GetRightThumbFingerFiles(string folderPath)
    {
        List<string> rightThumbFiles = new List<string>();

        folderPath = Path.Combine(folderPath);

        var filePaths = Directory.GetFiles(folderPath, "*Right_thumb_finger.BMP");

        foreach (var filePath in filePaths)
        {
            rightThumbFiles.Add(filePath.Replace("\\", "/"));
        }
        return rightThumbFiles;
    }

    public static List<string> GetThousandRightThumbFingerFiles(string folderPath)
    {
        List<string> rightThumbFiles = GetRightThumbFingerFiles(folderPath);

        if (rightThumbFiles.Count > 1000)
        {
            rightThumbFiles = rightThumbFiles.GetRange(0, 1000);
        }

        return rightThumbFiles;
    }

    public static string[] ReadFileToArray(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllLines(filePath);
        }
        else
        {
            throw new FileNotFoundException($"File tidak ditemukan: {filePath}");
        }
    }
}
