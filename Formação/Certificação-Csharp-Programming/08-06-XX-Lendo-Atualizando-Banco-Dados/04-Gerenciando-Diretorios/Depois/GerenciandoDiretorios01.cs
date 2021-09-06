using System;
using System.IO;

namespace _08_06_XX_Lendo_Atualizando_Banco_Dados.Depois
{
    public class GerenciandoDiretorios01 : IAulaItem //A Classe Directory
    {
        private const string NomeDiretorio = "NovoDiretorio";

        public void Executar()
        {
            //TAREFA:
            //Criar um novo diretório
            //Verificar se ele foi criado
            //Apagar o diretório que foi criado

            Directory.CreateDirectory(NomeDiretorio);

            if (Directory.Exists(NomeDiretorio))
            {
                Console.WriteLine("O diretório foi criado com sucesso");
            }

            Directory.Delete(NomeDiretorio);

            Console.WriteLine("O diretório foi removido com sucesso");
        }
    }
}