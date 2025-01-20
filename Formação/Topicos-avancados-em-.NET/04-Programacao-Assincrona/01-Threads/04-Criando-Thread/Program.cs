static void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");

    Console.WriteLine($"Conteúdo: \n{conteudo}");
}
// permite executar um trecho de código em paralelo
var thread = new Thread(() => LerArquivo());
//disparando a thread e executando o trecho
thread.Start();

Console.WriteLine("Outras operações.");
Console.ReadKey();