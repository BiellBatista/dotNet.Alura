﻿using _03_XX_Construtores_Metodos.Common;

MostrarBanner();

while (true)
{
    MostrarMenu();

    if (int.TryParse(Console.ReadLine(), out int escolha))
    {
        ExecutarEscolha(escolha);
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}

static void MostrarBanner()
{
    Console.WriteLine(@"

    ____        __       ____              __
   / __ )__  __/ /____  / __ )____ _____  / /__
  / __  / / / / __/ _ \/ __  / __ `/ __ \/ //_/
 / /_/ / /_/ / /_/  __/ /_/ / /_/ / / / / ,<
/_____/\__, /\__/\___/_____/\__,_/_/ /_/_/|_|
      /____/

        ");
}

static void MostrarMenu()
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine();
    Console.WriteLine("1. Ler arquivo de boletos");
    Console.WriteLine("2. Gravar arquivo com boletos agrupados por cedente");
    Console.WriteLine();
    Console.Write("Digite o número da opção desejada: ");
}

static void ExecutarEscolha(int escolha)
{
    switch (escolha)
    {
        case 1:
            LerArquivoBoletos();
            break;

        case 2:
            GravarGrupoBoletos();
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

static void LerArquivoBoletos()
{
    Console.WriteLine("Lendo arquivo de boletos...");

    var leitorDeBoleto = new LeitorDeBoleto();
    var boletos = leitorDeBoleto.LerBoletos("Boletos.csv");

    foreach (var boleto in boletos)
    {
        Console.WriteLine($"Cedente: {boleto.CedenteNome}, Valor: {boleto.Valor:#0.00}, Vencimento: {boleto.DataVencimento}");
    }
}

static void GravarGrupoBoletos()
{
    Console.WriteLine("Gravando arquivo de boletos...");

    var leitorDeBoleto = new LeitorDeBoleto();
    var boletos = leitorDeBoleto.LerBoletos("Boletos.csv");

    //RelatorioDeBoleto gravadorDeCSV = new RelatorioDeBoleto("BoletosPorCedente.csv");
    //gravadorDeCSV.Processar(boletos);

    var nomeParametroConstrutor = "nomeArquivoSaida";
    var parametroConstrutor = "BoletosPorCedente.csv";
    var nomeMetodo = "Processar";
    var parametroMetodo = boletos;

    ProcessarDinamicamente(nomeParametroConstrutor, parametroConstrutor,
        nomeMetodo, parametroMetodo);
}

static void ProcessarDinamicamente(string nomeParametroConstrutor, string parametroConstrutor, string nomeMetodo, List<Boleto> parametroMetodo)
{
    var tipoClasseRelatorio = typeof(RelatorioDeBoleto);
    var construtores = tipoClasseRelatorio.GetConstructors();

    //foreach (var construtor in construtores)
    //{
    //    Console.WriteLine($"Construtor: {construtor.Name}");
    //    Console.WriteLine($"  No. de parâmetros: {construtor.GetParameters().Length}");
    //}

    //O construtor desejado deve ter como requisitos:
    //1. Um único parâmetro
    //2. Esse parâmetro deve se chamar “nomeArquivoSaida”

    var construtor = construtores
        .Single(c => c.GetParameters().Length == 1
        && c.GetParameters().Any(p => p.Name == nomeParametroConstrutor));

    var instanciaClasse = construtor.Invoke([parametroConstrutor]);
    var metodoProcessar = tipoClasseRelatorio.GetMethod(nomeMetodo);

    metodoProcessar.Invoke(instanciaClasse, [parametroMetodo]);
}