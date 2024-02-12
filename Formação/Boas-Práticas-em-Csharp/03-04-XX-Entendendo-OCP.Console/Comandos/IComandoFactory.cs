namespace _03_04_XX_Entendendo_OCP.Console.Comandos;

public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);

    IComando? CriarComando(string[] argumentos);
}