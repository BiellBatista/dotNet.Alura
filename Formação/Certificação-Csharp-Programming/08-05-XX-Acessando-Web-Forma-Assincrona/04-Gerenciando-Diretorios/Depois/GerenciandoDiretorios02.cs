using System;
using System.IO;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class GerenciandoDiretorios02 : IAulaItem //A classe Directorylnfo
    {
        public void Executar()
        {
            //TAREFA:
            //Criar um novo diretório
            //Verificar se ele foi criado
            //Exibir os atributos do diretório
            //Exibir último acesso
            //Apagar o diretório que foi criado

            DirectoryInfo localDir = new DirectoryInfo("NovoDiretorio");
            localDir.Create();

            if (localDir.Exists)
            {
                Console.WriteLine("Diretório criado com sucesso");
            }

            Console.WriteLine("Atributos: {0}", localDir.Attributes);
            Console.WriteLine("Último acesso: {0}", localDir.LastAccessTime);

            localDir.Delete();

            Console.WriteLine("Diretório removido com sucesso");
        }
    }
}