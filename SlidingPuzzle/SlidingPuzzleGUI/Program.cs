using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SlidingPuzzleGUI
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SPView(args.Length > 0 ? args[0] : null));
        }
    }
}
