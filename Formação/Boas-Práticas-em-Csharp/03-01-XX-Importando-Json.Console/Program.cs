using _03_01_XX_Importando_Json.Console.Comandos;
using _03_01_XX_Importando_Json.Console.UI;
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