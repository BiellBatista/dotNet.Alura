using _03_06_XX_Enviando_Email.Console.Comandos;
using _03_06_XX_Enviando_Email.Console.UI;
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