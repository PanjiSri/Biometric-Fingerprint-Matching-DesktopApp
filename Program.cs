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


        string folderPath = "./tes";

        // Ini buat dapet gambar UJI

        // string folderPath = "./citra";

        // List<string> filePaths = FileManager.GetFilePaths(folderPath);

        // string test_dummy = filePaths[2];


        List<string> filePaths = FileManager.GetFilePaths(folderPath);

        string[] nama_dummy = new string[] {"sigit rendang", "mr ironi", "mas ambatron", "ngawi musikal", "ihsan ganteng"};
        string[] path_dummy = new string[] {filePaths[0], filePaths[1], filePaths[2], filePaths[3], filePaths[4]};

        string[] nama_dummy_alay = new string[] {"5gt rnDn6", "Mr 1R0n1", "Ma5 ambtroN", "n6w mu5k4l", "1h54n 6nTEn6"};
        string[] path_dummy_alay = new string[] {filePaths[0], filePaths[1], filePaths[2], filePaths[3], filePaths[4]};

        // foreach(var nama in nama_dummy){
        //     Console.WriteLine(nama);
        // }

        // foreach(var path in path_dummy){
        //     Console.WriteLine(path);
        // }

        DatabaseManager dbManager = new DatabaseManager("server=127.0.0.1; port=3307; user=root; password=baraja16!; database=database_sidik_jari");

        // string path_hasil = dbManager.GetName(filePaths[0]);

        // Console.WriteLine(path_hasil);

        // dbManager.ClearBiodataTable();
        // dbManager.ClearFingerprintTable();

        // dbManager.SeedDatabase(nama_dummy, path_dummy);
        // dbManager.SeedDatabase(nama_dummy_alay, path_dummy_alay);

        // string[] biodata = dbManager.GetBiodata(path_hasil);

        // if (biodata != null)
        // {
        //     Console.WriteLine("Biodata ditemukan:");
        //     Console.WriteLine($"NIK: {biodata[0]}");
        //     Console.WriteLine($"Nama: {biodata[1]}");
        //     Console.WriteLine($"Tempat Lahir: {biodata[2]}");
        //     Console.WriteLine($"Tanggal Lahir: {biodata[3]}");
        //     Console.WriteLine($"Jenis Kelamin: {biodata[4]}");
        //     Console.WriteLine($"Golongan Darah: {biodata[5]}");
        //     Console.WriteLine($"Alamat: {biodata[6]}");
        //     Console.WriteLine($"Agama: {biodata[7]}");
        //     Console.WriteLine($"Status Perkawinan: {biodata[8]}");
        //     Console.WriteLine($"Pekerjaan: {biodata[9]}");
        //     Console.WriteLine($"Kewarganegaraan: {biodata[10]}");
        // }
        // else
        // {
        //     Console.WriteLine("Biodata tidak ditemukan.");
        // }

        // // dbManager.OpenConnection();

        string[] allPath = dbManager.GetAllPath();
        string[] allName = dbManager.GetAllName();

        // // foreach(var path in allPath){
        // //     Console.WriteLine(path);
        // // }

        // foreach(var name in allName){
        //     Console.WriteLine(name);
        // }

        int position = -1;

        string real_name = null;

        GrayscaleToASCIIConverter asciiConverter = new GrayscaleToASCIIConverter();        

        foreach(var path in allPath){
            string wholeImage = asciiConverter.ConvertToASCII(path);
            string bestSegment = asciiConverter.GetBestSegment(test_dummy);

            position = BM.BmMatch(wholeImage, bestSegment);

            if (position != -1)
            {
                Console.WriteLine($"Pattern starts at position {position + 1}");

                //PATH ITU ISINYA PATH KE GAMBARNYA
                real_name = dbManager.GetName(path);
                break;
            }
        }

        if(position == -1){
            Console.WriteLine("tidak ketemu");
            foreach(var path in allPath){
                string wholeImage = asciiConverter.ConvertToASCII(path);
                string bestSegment = asciiConverter.GetBestSegment(test_dummy);

                int distance = Levenshtein.LevenshteinDistance(wholeImage, bestSegment);

                float persent = Levenshtein.PersentaseKemiripan(distance, wholeImage, bestSegment);

                Console.WriteLine($"{path} {distance} {persent}");

                if(persent > 80){  
                    //INI PATH NYA DIPAKE BUAT GUI
                    real_name = dbManager.GetName(path);
                    break;
                }
            }
        }

        Regexp r = new Regexp();
        string name_regex = r.createRegex(real_name);
        string alay_name = null;
        foreach (var name in allName) {
            if (r.isMatch(name, name_regex)) {
                alay_name = name;
                break;
            }
        }
    
        if (alay_name == null) {
            Console.WriteLine("nama tidak ada");
            return;
        }

        //INI REAL_BIODATA BUAT BIODATANYA
        string[] real_biodata = dbManager.GetBiodata(alay_name);

        if (real_biodata != null)
        {
            Console.WriteLine("real_biodata ditemukan:");
            Console.WriteLine($"NIK: {real_biodata[0]}");
            Console.WriteLine($"Nama: {real_biodata[1]}");
            Console.WriteLine($"Tempat Lahir: {real_biodata[2]}");
            Console.WriteLine($"Tanggal Lahir: {real_biodata[3]}");
            Console.WriteLine($"Jenis Kelamin: {real_biodata[4]}");
            Console.WriteLine($"Golongan Darah: {real_biodata[5]}");
            Console.WriteLine($"Alamat: {real_biodata[6]}");
            Console.WriteLine($"Agama: {real_biodata[7]}");
            Console.WriteLine($"Status Perkawinan: {real_biodata[8]}");
            Console.WriteLine($"Pekerjaan: {real_biodata[9]}");
            Console.WriteLine($"Kewarganegaraan: {real_biodata[10]}");
        }
        else
        {
            Console.WriteLine("Biodata tidak ditemukan.");
        }

        // GrayscaleToASCIIConverter asciiConverter = new GrayscaleToASCIIConverter();

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

        // String var_dummy = filePaths[0];
        // String var_dummy_2 = filePaths[12];

        // Console.WriteLine(var_dummy);

        // string wholeImage = asciiConverter.ConvertToASCII(var_dummy);
        // string bestSegment = asciiConverter.GetBestSegment(var_dummy_2);

        // int position = KMP.KmpMatch(wholeImage, bestSegment);

        // if (position == -1)
        // {
        //    Console.WriteLine("Pattern not found");
        // }
        // else
        // {
        //    Console.WriteLine($"Pattern starts at position {position + 1}");
        // }

        // dbManager.ClearFingerprintTable();

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