namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivo<T>
{
    IEnumerable<T> RealizaLeitura();
}