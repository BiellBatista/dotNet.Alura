﻿namespace _02_01_XX_Declarando_Dependencias.Console.Comandos
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DocComandoAttribute : Attribute
    {
        public DocComandoAttribute(string instrucao, string documentacao)
        {
            Instrucao = instrucao;
            Documentacao = documentacao;
        }

        public string Instrucao { get; }

        public string Documentacao { get; }
    }
}