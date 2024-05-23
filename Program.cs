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
        int position = KMP.KmpMatch(text, pattern);

        if (position == -1)
        {
            Console.WriteLine("Pattern not found");
        }
        else
        {
            Console.WriteLine($"Pattern starts at position {position + 1}");
        }
    }    
}