﻿namespace _09_03_XX_Depurando_Aplicacoes.Depois
{
    public class Filme
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }

        public Filme(string diretor, string titulo)
        {
            Diretor = diretor;
            Titulo = titulo;
        }
    }
}