using System;
using System.IO;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class GerenciandoArquivos01 : IAulaItem //A classe File
    {
        public void Executar()
        {
            //TAREFAS: GRAVAR E LER DADOS DE UM ARQUIVO USANDO A CLASSE File

            string conteudoInicial = "Conteúdo Inicial do Arquivo";
            string conteudoAdicional = "\nConteúdo Adicional ao Arquivo";

            File.WriteAllText("Arquivo.txt", conteudoInicial);

            File.AppendAllText("Arquivo.txt", conteudoAdicional);

            if (File.Exists("Arquivo.txt"))
                Console.WriteLine("O arquivo já existe.");

            string conteudo = File.ReadAllText("Arquivo.txt");
            Console.WriteLine("Conteúdo do arquivo: {0}", conteudo);

            File.Copy("Arquivo.txt", "CopiaArquivo.txt", overwrite: true);

            using (var leitor = File.OpenText("CopiaArquivo.txt"))
            {
                string texto = leitor.ReadToEnd();
                Console.WriteLine("Texto copiado: {0}", texto);
            }

            Console.ReadKey();
        }
    }
}