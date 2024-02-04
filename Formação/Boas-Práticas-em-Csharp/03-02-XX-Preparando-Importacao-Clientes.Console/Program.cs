using _03_02_XX_Preparando_Importacao_Clientes.Console.Comandos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.UI;
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