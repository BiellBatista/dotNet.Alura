using _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Abstracoes;

namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Arquivos;

public abstract class LeitorDeArquivoCsv<T> : ILeitorDeArquivos<T>
{
    private string caminhoDoArquivoASerLido;

    public LeitorDeArquivoCsv(string caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public virtual IEnumerable<T> RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
        {
            return null;
        }
        List<T> lista = new List<T>();
        using StreamReader sr = new StreamReader(caminhoDoArquivoASerLido);
        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                var objeto = CriarDaLinhaCsv(linha);
                lista.Add(objeto);
            }
        }
        return lista;
    }

    public abstract T CriarDaLinhaCsv(string linha);
}