namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos;

public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);

    IComando? CriarComando(string[] argumentos);
}