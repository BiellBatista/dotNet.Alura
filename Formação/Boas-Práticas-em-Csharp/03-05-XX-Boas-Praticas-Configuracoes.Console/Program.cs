using _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.UI;
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