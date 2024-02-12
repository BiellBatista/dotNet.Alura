using _03_03_XX_Importacao_Clientes.Console.Modelos;

namespace _03_03_XX_Importacao_Clientes.Console.Servicos.Arquivos;

public class ClientesDoCsv : LeitorDeArquivoCsv<Cliente>
{
    public ClientesDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    public override Cliente CriarDaLinhaCsv(string linha)
    {
        string[] propriedades = linha.Split(';');

        return new Cliente(
             id: Guid.Parse(propriedades[0]),
             nome: propriedades[1],
             email: propriedades[2]
            );
    }
}