﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecognizeWinApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1(20, 30);
            
            Application.EnableVisualStyles();          
            Application.Run(form);
           
        }
    }
}
