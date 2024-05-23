using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes3_let_me_seedik
{
    internal static class Program 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Regex r = new Regex();
            Console.WriteLine(r.isMatch("hai", @"(ha)+."));
            Console.WriteLine(r.isMatch("hahai", @"(ha)+."));
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}
