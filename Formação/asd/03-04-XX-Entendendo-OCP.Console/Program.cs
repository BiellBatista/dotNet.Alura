using _03_04_XX_Entendendo_OCP.Console.Comandos;
using _03_04_XX_Entendendo_OCP.Console.UI;
using FluentResults;

IComando? comando = ComandosFactory.CriarComando(args);
if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}