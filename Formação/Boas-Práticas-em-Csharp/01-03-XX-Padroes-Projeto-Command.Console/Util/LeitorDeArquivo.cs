﻿using _01_03_XX_Padroes_Projeto_Command.Console.Modelos;

namespace _01_03_XX_Padroes_Projeto_Command.Console.Util;

internal class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        List<Pet> listaDePet = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            System.Console.WriteLine("----- Dados a serem importados -----");

            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[]? propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
                listaDePet.Add(pet);
            }
        }

        return listaDePet;
    }
}