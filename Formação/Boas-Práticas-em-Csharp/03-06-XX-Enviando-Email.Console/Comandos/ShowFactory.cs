﻿using _03_06_XX_Enviando_Email.Console.Servicos.Arquivos;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

public class ShowFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivosShow is null) { return null; }
        return new Show(leitorDeArquivosShow);
    }
}