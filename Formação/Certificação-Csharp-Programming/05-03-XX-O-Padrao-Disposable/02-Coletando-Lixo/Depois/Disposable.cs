﻿using System;
using System.Windows.Forms;

namespace _05_03_XX_O_Padrao_Disposable.Depois
{
    internal class Disposable : IAulaItem
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public void Executar()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMensagem());
        }
    }
}