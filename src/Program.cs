namespace Tubes3_let_me_seedik;

//using MySql.Data.MySqlClient;
//using System;

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;


static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Tubes());
    }    

}