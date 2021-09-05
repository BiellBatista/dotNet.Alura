using System;
using System.IO;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class GerenciandoArquivos04 : IAulaItem //Informações de arquivo
    {
        public void Executar()
        {
            const string caminho = "Arquivo.txt";
            //TAREFA:
            //1. Gravar um texto em Arquivo.txt
            //2. Obter informações desse arquivo:
            //      Nome
            //      Caminho completo (diretório + nome do arquivo)
            //      Data e hora do último acesso
            //      Tamanho do arquivo (bytes)
            //      Atributos do arquivo
            //      Adicionar atributo somente-leitura
            //      Verificar os atributos novamente
            //      Remover atributo somente-leitura
            //      Verificar os atributos novamente

            File.WriteAllText(caminho, "Texto inicial do arquivo");
            FileInfo info = new FileInfo(caminho);

            Console.WriteLine("Nome {0}", info.Name);
            Console.WriteLine("Caminho completo: {0}", info.FullName);
            Console.WriteLine("Último acesso: {0}", info.LastAccessTime);
            Console.WriteLine("Tamanho: {0} bytes", info.Length);
            Console.WriteLine("Atributos: {0}", info.Attributes);

            info.Attributes = info.Attributes | FileAttributes.ReadOnly;

            Console.WriteLine("Atributos: {0}", info.Attributes);
            //o ~ é a negação do binário
            info.Attributes = info.Attributes & ~FileAttributes.ReadOnly;

            Console.WriteLine("Atributos: {0}", info.Attributes);
        }
    }
}