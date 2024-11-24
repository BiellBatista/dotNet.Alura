static void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");

    Thread.Sleep(new Random().Next(300, 8000));

    Console.WriteLine($"Conteúdo: \n{conteudo}");
}

static void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");

    Thread.Sleep(new Random().Next(300, 8000));
}

// permite executar um trecho de código em paralelo
var thread1 = new Thread(() => LerArquivo());
// permite executar um trecho de código em paralelo
var thread2 = new Thread(() => ExibirRelatorio());

void InicializarThreads()
{
    //disparando a thread e executando o trecho
    thread1.Start();

    while (thread1.IsAlive)
        Console.WriteLine("Thread1 em execução.");

    //disparando a thread e executando o trecho
    thread2.Start();
}

InicializarThreads();

Console.WriteLine("Outras operações.");
Console.ReadKey();