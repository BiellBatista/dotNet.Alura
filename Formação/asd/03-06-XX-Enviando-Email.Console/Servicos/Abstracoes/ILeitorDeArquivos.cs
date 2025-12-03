namespace _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivos<T>
{
    IEnumerable<T> RealizaLeitura();
}