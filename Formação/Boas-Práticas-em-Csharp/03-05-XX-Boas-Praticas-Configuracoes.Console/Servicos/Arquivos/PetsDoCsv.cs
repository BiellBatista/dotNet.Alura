﻿using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

public class PetsDoCsv : LeitorArquivoCsv<Pet>
{
    public PetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    protected override Pet CreateObject(string linha)
    {
        string[] propriedades = linha.Split(';');
        bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
        if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

        bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
        if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

        TipoPet tipo = tipoPet == 1 ? TipoPet.Gato : TipoPet.Cachorro;

        return new Pet(petId, propriedades[1], tipo);
    }
}