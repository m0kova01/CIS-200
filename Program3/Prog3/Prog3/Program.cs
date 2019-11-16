// Program 3
// CIS 200-01
// Fall 2019
// Due: 11/11/2019
// Grading ID: M1610

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    [Serializable]

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
            Application.Run(new Prog3Form());
        }
    }
}
