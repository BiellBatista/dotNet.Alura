﻿namespace _02_04_XX_Isolando_Exibicao.Console.Comandos
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