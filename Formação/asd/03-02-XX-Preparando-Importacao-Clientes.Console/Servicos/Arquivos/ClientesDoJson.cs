using _03_02_XX_Preparando_Importacao_Clientes.Console.Modelos;

namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Arquivos;

public class ClientesDoJson : LeitorDeArquivosJson<Cliente>
{
    public ClientesDoJson(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }
}