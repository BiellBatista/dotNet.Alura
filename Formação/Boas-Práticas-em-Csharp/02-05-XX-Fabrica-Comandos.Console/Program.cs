using _05_XX_Fabrica_Comandos.Console.Comandos;
using _05_XX_Fabrica_Comandos.Console.UI;
using FluentResults;

IComando? comando = FabricaDeComandos.CriarComando(args);
if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}