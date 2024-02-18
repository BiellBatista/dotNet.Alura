namespace _03_06_XX_Enviando_Email.Console.Comandos;

public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);

    IComando? CriarComando(string[] argumentos);
}