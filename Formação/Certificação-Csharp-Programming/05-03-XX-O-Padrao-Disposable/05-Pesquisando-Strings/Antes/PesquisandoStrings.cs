﻿using System;
using System.Windows.Forms;

namespace _05_03_XX_O_Padrao_Disposable.Antes
{
    public class PesquisandoStrings : IAulaItem
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public void Executar()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPesquisa());
        }
    }
}