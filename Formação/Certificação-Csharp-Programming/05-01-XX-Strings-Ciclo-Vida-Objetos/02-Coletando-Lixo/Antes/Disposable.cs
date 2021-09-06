using System;
using System.Windows.Forms;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Antes
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