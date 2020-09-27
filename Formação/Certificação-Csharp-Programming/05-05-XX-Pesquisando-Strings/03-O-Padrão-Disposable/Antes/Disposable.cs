using System;
using System.Windows.Forms;

namespace _05_05_XX_Pesquisando_Strings.Antes
{
    class Disposable2 : IAulaItem
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
