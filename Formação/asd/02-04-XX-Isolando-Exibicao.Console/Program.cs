using _02_04_XX_Isolando_Exibicao.Console.Comandos;
using _02_04_XX_Isolando_Exibicao.Console.Servicos;
using _02_04_XX_Isolando_Exibicao.Console.UI;
using _02_04_XX_Isolando_Exibicao.Console.Util;
using FluentResults;

var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
LeitorDeArquivo leitorDeArquivos = args.Length == 2 ? new(args[1]) : null;

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(httpClientPet,leitorDeArquivos)},
    {"list",new List(httpClientPet) },
    {"show",new Show(leitorDeArquivos) },
};

string comando = args[0].Trim();
if (comandosDoSistema.ContainsKey(comando))
{
    IComando? cmd = comandosDoSistema[comando];
    var resultado = await cmd.ExecutarAsync(args);
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}