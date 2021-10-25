using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Haus_Servis_Sistemleri_Pro_v7._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HausStartPage());
            Application.Run(new HausLoginPanel());
        }
    }
}
