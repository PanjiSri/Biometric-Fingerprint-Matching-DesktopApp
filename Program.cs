namespace Tubes3_let_me_seedik;

using System;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Console.WriteLine("Hello World");
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());

        //KMP.cetakTes();

        //string pattern = "ababababca";
        //int[] border = KMP.ComputeBorder(pattern);

        //Console.WriteLine("Pattern: " + pattern);
        //Console.WriteLine("Border array: [" + string.Join(", ", border) + "]");

        string text = "ngawi musikal cik";
        string pattern = "musik";
        int positionKMP = KMP.KmpMatch(text, pattern);
        int positionBM = BM.BmMatch(text, pattern);

        Console.WriteLine("KMP");
        if (positionKMP == -1)
        {
            Console.WriteLine("Pattern not found");
        }
        else
        {
            Console.WriteLine($"Pattern starts at position {positionKMP + 1}");
        }

        Console.WriteLine("BM");
        if (positionBM == -1)
        {
            Console.WriteLine("Pattern not found");
        }
        else
        {
            Console.WriteLine($"Pattern starts at position {positionBM + 1}");
        }

        Console.Write("LevensteinDistance = ");
        int distance = Levenshtein.LevenshteinDistance(text, pattern);
        Console.WriteLine(distance);
        Console.Write("Persentase = ");
        float persen = Levenshtein.PersentaseKemiripan(distance, text, pattern);
        Console.WriteLine(persen);


    }    
}