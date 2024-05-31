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
            Regexp r = new Regexp();
            string pattern = r.createRegex("Ibrahim Ihsan Rasyid");
            Console.WriteLine(pattern);
            Console.WriteLine(r.isMatch("IbrH1m 1h5aN r5y1d", pattern));
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}
