static void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");

    Task.Delay(new Random().Next(300, 8000));

    Console.WriteLine($"Conteúdo: \n{conteudo}");
}

static void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");

    Task.Delay(new Random().Next(300, 8000));
}
// executa uma tarefa em paralelo (encapsula toda complexidade de trabalhar com thread)
var task1 = Task.Run(() => LerArquivo());
// executa uma tarefa em paralelo (encapsula toda complexidade de trabalhar com thread)
var task2 = Task.Run(() => ExibirRelatorio());

Console.WriteLine("Outras operações.");
Console.ReadKey();