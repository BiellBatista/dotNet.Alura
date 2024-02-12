namespace _03_03_XX_Importacao_Clientes.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivos<T>
{
    IEnumerable<T> RealizaLeitura();
}