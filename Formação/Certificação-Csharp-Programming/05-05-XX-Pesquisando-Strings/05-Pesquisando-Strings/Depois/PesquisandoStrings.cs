﻿using System;
using System.Windows.Forms;

namespace _05_05_XX_Pesquisando_Strings.Depois
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