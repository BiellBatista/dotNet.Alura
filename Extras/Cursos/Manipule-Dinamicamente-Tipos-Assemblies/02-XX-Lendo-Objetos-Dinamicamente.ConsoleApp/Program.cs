﻿using _02_XX_Lendo_Objetos_Dinamicamente.Common;

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

    var gravadorDeCSV = new RelatorioDeBoleto("BoletosPorCedente.csv");
    gravadorDeCSV.Processar(boletos);
}