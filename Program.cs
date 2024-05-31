namespace Tubes3_let_me_seedik;

//using MySql.Data.MySqlClient;
//using System;

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //Console.WriteLine("Hello World");
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());


        //string pattern = "ababababca";
        //int[] border = KMP.ComputeBorder(pattern);

        //Console.WriteLine("Pattern: " + pattern);
        //Console.WriteLine("Border array: [" + string.Join(", ", border) + "]");

        //string text = "ngawi musikal cik";
        //string pattern = "musik";
        //int position = KMP.KmpMatch(text, pattern);

        //if (position == -1)
        //clear{
        //    Console.WriteLine("Pattern not found");
        //}
        //else
        //{
        //    Console.WriteLine($"Pattern starts at position {position + 1}");
        //}

        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);

        // Application.Run(new Form1());

        DatabaseManager dbManager = new DatabaseManager("server=127.0.0.1; port=3307; user=root; password=baraja16!; database=database_sidik_jari");

        dbManager.OpenConnection();

        string folderPath = "./tes";

        List<string> filePaths = FileManager.GetFilePaths(folderPath);

        GrayscaleToASCIIConverter asciiConverter = new GrayscaleToASCIIConverter();

        // foreach(var path in filePaths){

        //     // dbManager.InsertFingerprintRecord(path);
        //     // Bitmap image = (Bitmap)Image.FromFile(path);

        //     // int bitsPerPixel = GetBitsPerPixel(image);

        //     // Console.WriteLine("The image has " + bitsPerPixel + " bits per pixel.");
        //     // Console.WriteLine(path);

        //     // Console.WriteLine(asciiConverter.ConvertToASCII(path));
        //     wholeImage = asciiConverter.ConvertToASCII(path);
        //     bestSegment = asciiConverter.GetBestSegment(path);
        //     Console.WriteLine(wholeImage);
        //     Console.WriteLine(bestSegment.Length);
        //     Console.WriteLine(bestSegment);
        //     break;
        // }

        String var_dummy = filePaths[0];
        String var_dummy_2 = filePaths[12];

        Console.WriteLine(var_dummy);

        string wholeImage = asciiConverter.ConvertToASCII(var_dummy);
        string bestSegment = asciiConverter.GetBestSegment(var_dummy_2);

        int position = KMP.KmpMatch(wholeImage, bestSegment);

        if (position == -1)
        {
           Console.WriteLine("Pattern not found");
        }
        else
        {
           Console.WriteLine($"Pattern starts at position {position + 1}");
        }

        dbManager.ClearFingerprintTable();

        // dbManager.RetrieveFingerprints();



        //foreach (var path in filePaths)
        //{
        //    dbManager.InsertFingerprintRecord(path);
        //}

        // string folderPath = "./tes"; 
        // string[] fileEntries = Directory.GetFiles(folderPath, "*.txt");

        // foreach (string fileName in fileEntries)
        // {
        //     Console.WriteLine(fileName); 
        //     String formattedPath = fileName.Replace("\\", "/");
        //     Console.WriteLine(formattedPath);
        //     string fileContent = File.ReadAllText(formattedPath);
        //     Console.WriteLine(fileContent);
        // }

        // string fileContent = File.ReadAllText(formattedPath);



        //dbManager.RetrieveFingerprints();

        //Console.WriteLine("Press any key to exit...");
        //Console.ReadKey();
    }    

    // static int GetBitsPerPixel(Bitmap bitmap)
    // {
    //     switch (bitmap.PixelFormat)
    //     {
    //         case PixelFormat.Format1bppIndexed:
    //             return 1;
    //         case PixelFormat.Format4bppIndexed:
    //             return 4;
    //         case PixelFormat.Format8bppIndexed:
    //             return 8;
    //         case PixelFormat.Format16bppGrayScale:
    //         case PixelFormat.Format16bppRgb555:
    //         case PixelFormat.Format16bppRgb565:
    //         case PixelFormat.Format16bppArgb1555:
    //             return 16;
    //         case PixelFormat.Format24bppRgb:
    //             return 24;
    //         case PixelFormat.Format32bppArgb:
    //         case PixelFormat.Format32bppPArgb:
    //         case PixelFormat.Format32bppRgb:
    //             return 32;
    //         case PixelFormat.Format48bppRgb:
    //             return 48;
    //         case PixelFormat.Format64bppArgb:
    //         case PixelFormat.Format64bppPArgb:
    //             return 64;
    //         default:
    //             throw new ArgumentOutOfRangeException("Unsupported PixelFormat: " + bitmap.PixelFormat);
    //     }
    // }
}