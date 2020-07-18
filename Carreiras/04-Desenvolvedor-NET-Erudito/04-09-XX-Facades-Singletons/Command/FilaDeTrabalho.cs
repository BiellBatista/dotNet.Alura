using System.Collections.Generic;

namespace _04_09_XX_Facades_Singletons.Command
{
    public class FilaDeTrabalho
    {
        private IList<IComando> Comandos = new List<IComando>();

        public void Adiciona(IComando comando)
        {
            Comandos.Add(comando);
        }

        public void Processa()
        {
            foreach (var comando in Comandos)
            {
                comando.Executa();
            }
        }
    }
}
