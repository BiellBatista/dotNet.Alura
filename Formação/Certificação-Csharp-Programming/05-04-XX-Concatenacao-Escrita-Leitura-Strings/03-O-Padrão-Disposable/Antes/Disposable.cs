﻿using System;
using System.Windows.Forms;

namespace _05_04_XX_Concatenacao_Escrita_Leitura_Strings.Antes
{
    internal class Disposable2 : IAulaItem
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public void Executar()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMensagem2());
        }
    }
}