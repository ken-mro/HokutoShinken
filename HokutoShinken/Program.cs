﻿using System;
using System.Windows.Forms;

namespace HokutoShinken
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new Form1();
            Application.Run();
        }
    }
}