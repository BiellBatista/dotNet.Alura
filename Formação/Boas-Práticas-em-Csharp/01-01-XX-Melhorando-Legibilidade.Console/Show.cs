﻿namespace _01_01_XX_Melhorando_Legibilidade.Console;

internal class Show
{
    public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            System.Console.WriteLine("----- Dados a serem importados -----");

            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[]? propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

                System.Console.WriteLine(pet);
            }
        }
    }
}