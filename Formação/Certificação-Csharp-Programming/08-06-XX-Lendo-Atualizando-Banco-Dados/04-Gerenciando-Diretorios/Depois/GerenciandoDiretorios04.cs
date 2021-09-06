using System;
using System.IO;

namespace _08_06_XX_Lendo_Atualizando_Banco_Dados.Depois
{
    public class GerenciandoDiretorios04 : IAulaItem //Procurando e listando arquivos
    {
        public void Executar()
        {
            //TAREFAS:
            //Obter o diretório de início do projeto
            //Listar todos os diretórios do projeto
            //Listar todos os arquivos csharp (.cs) do projeto

            DirectoryInfo diretorioInicial = new DirectoryInfo(@"..\..\..");
            ListarDiretorios(diretorioInicial);
        }

        private void ListarDiretorios(DirectoryInfo diretorioInicial)
        {
            foreach (var diretorio in diretorioInicial.GetDirectories())
            {
                Console.WriteLine(diretorio.FullName);

                foreach (var arquivo in diretorio.GetFiles("*.cs"))
                {
                    Console.WriteLine(arquivo.FullName);
                }

                ListarDiretorios(diretorio);
            }
        }
    }
}