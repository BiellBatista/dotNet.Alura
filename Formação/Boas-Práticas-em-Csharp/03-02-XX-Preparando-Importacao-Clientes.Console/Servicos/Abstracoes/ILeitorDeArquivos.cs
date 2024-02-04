namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivos<T>
{
    IEnumerable<T> RealizaLeitura();
}