namespace _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivos<T>
{
    IEnumerable<T> RealizaLeitura();
}