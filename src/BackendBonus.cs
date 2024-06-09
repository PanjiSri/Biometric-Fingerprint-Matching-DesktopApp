using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DotNetEnv;
using System.Threading.Tasks;

namespace Tubes3_let_me_seedik
{
    class BackEndBonus
    {
        public static float persentase { get; private set; }
        public static string[] biodata { get; private set; }
        public static string pathGambar { get; private set; }

        public BackEndBonus(bool algoritma) 
        {
            pathGambar = "";
            string targetPath = "src/citra";
            List<string> targetPaths = FileManager.GetFilePaths(targetPath);

            string input = targetPaths[0];

            Env.Load();
            string server = Env.GetString("SERVER");
            string port = Env.GetString("PORT");
            string user = Env.GetString("USER");
            string password = Env.GetString("PASSWORD");
            string database = Env.GetString("DATABASE");
            string key = Env.GetString("KEY");

            string connectionString;

            int intKey;
            bool success = int.TryParse(key, out intKey);

            if (!success)
            {
                Console.WriteLine("Format Key Tidak Valid");
            }
            

            if (string.IsNullOrEmpty(port))
            {
                connectionString = $"Server={server};User ID={user};Password={password};Database={database};";
            }
            else
            {
                connectionString = $"Server={server};Port={port};User ID={user};Password={password};Database={database};";
            }

            DatabaseManager dbManager = new DatabaseManager(connectionString);

            string[] allPath = dbManager.GetAllPath();
            int position = -1;
            float maxPersen = 0;
            string real_name = "";

            GrayscaleToASCIIConverter asciiConverter = new GrayscaleToASCIIConverter();        

            foreach(var path in allPath){
                string wholeImage = asciiConverter.ConvertToASCII(path);
                string bestSegment = asciiConverter.GetBestSegment(input);
                string upperMiddleSegment = asciiConverter.GetUpperMiddleSegment(input);
                string lowerMiddelSegment = asciiConverter.GetLowerMiddleSegment(input);
                string wholeImageInput = asciiConverter.ConvertToASCII(input);

                for(int i = 0; i < 3; i++){
                    if (algoritma)
                    {   
                        if(i == 0){
                            position = KMP.KmpMatch(wholeImage, bestSegment);
                        }
                        else if( i == 1){
                            position = KMP.KmpMatch(wholeImage, upperMiddleSegment);
                        }
                        else {
                            position = KMP.KmpMatch(wholeImage, lowerMiddelSegment);
                        }
                    }
                    else
                    {
                        if(i == 0){
                            position = BM.BmMatch(wholeImage, bestSegment);
                        }
                        else if( i == 1){
                            position = BM.BmMatch(wholeImage, upperMiddleSegment);
                        }
                        else {
                            position = BM.BmMatch(wholeImage, lowerMiddelSegment);
                        }
                    }

                    if(position != -1){
                        break;
                    }
                }

                if (position != -1)
                {

                    //PATH ITU ISINYA PATH KE GAMBARNYA
                    real_name = dbManager.GetName(path);
                    pathGambar = path;
                    maxPersen = 100;
                    break;
                }
                else
                {
                    int distance = Hamming.HammingDistance(wholeImage, wholeImageInput);

                    float persent = Hamming.PersentaseKemiripan(distance, wholeImage, wholeImageInput);

                    if (maxPersen < persent)
                    {
                        real_name = dbManager.GetName(path);
                        pathGambar = path;
                        maxPersen = persent;
                    }
                }
            }  
            persentase = maxPersen;
            string[] allName = dbManager.GetAllName();

            Regexp r = new Regexp();
            string name_regex = r.createRegex(real_name);
            string alay_name = "";
            CaesarCipher caesar = new CaesarCipher();
            foreach (var name in allName) {
                string name_decrypted = caesar.Decrypt(name, intKey);
                if (r.isMatch(name_decrypted, name_regex)) {
                    alay_name = name_decrypted;
                    break;
                }
            }
        
            if (alay_name == "") {
                Console.WriteLine("nama tidak ada");
            }

            Console.WriteLine(alay_name);
            alay_name = caesar.Encrypt(alay_name, intKey);
            biodata = dbManager.GetBiodata(alay_name);
            Console.WriteLine(biodata[0]);
            biodata[0] = caesar.Decrypt(biodata[0], intKey);
            Console.WriteLine(biodata[0]);
            biodata[1] = real_name;
            Console.WriteLine(biodata[1]);
            biodata[2] = caesar.Decrypt(biodata[2], intKey);
            Console.WriteLine(biodata[2]);
            // biodata[4] = caesar.Decrypt(biodata[4], intKey);
            // Console.WriteLine(biodata[4]);
            biodata[5] = caesar.Decrypt(biodata[5], intKey);
            Console.WriteLine(biodata[5]);
            biodata[6] = caesar.Decrypt(biodata[6], intKey);
            biodata[7] = caesar.Decrypt(biodata[7], intKey);
            biodata[9] = caesar.Decrypt(biodata[9], intKey);
            biodata[10] = caesar.Decrypt(biodata[10], intKey);
            Console.WriteLine(persentase);
        }

        public void Penyelesaian(String gambarDatabase, String gambarUji, bool algoritma)
        {
            int start;
            int kemiripan = 100;
            String pattern = "Ini siapa";
            String text = "Ini siapa sih";
            if (algoritma == true)
            {
                start = BM.BmMatch(text, pattern);
            }
            else
            {
                start = KMP.KmpMatch(text, pattern);
            }

            if (start != -1)
            {
                kemiripan = Levenshtein.LevenshteinDistance(text, pattern);
            }
            // Console.WriteLine(Levenshtein.PersentaseKemiripan(kemiripan, text, pattern));
            persentase = Levenshtein.PersentaseKemiripan(kemiripan, text, pattern);

        }
        public static int Prosedur(){
            int pilihan = 0;
            int start;
            int kemiripan = 100;
            String pattern = "Ini siapa";
            String text = "Ini siapa sih";
            if (pilihan == 0) {
                start = BM.BmMatch(text, pattern);
            } else {
                start = KMP.KmpMatch(text, pattern);
            }

            if (start != -1)
            {
                kemiripan = Levenshtein.LevenshteinDistance(text, pattern);
            }
            // Console.WriteLine(Levenshtein.PersentaseKemiripan(kemiripan, text, pattern));
            return (int) Levenshtein.PersentaseKemiripan(kemiripan, text, pattern);
        }
    }

}
