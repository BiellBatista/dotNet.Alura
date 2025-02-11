﻿using System;
using _01_XX_xUnit_Moq.Core.Models;

namespace _01_XX_xUnit_Moq.Core.Commands
{
    /// <summary>
    /// Informações necessárias para cadastrar uma tarefa.
    /// </summary>
    public class CadastraTarefa
    {
        public CadastraTarefa(string titulo, Categoria categoria, DateTime prazo)
        {
            Titulo = titulo;
            Categoria = categoria;
            Prazo = prazo;
        }

        public string Titulo { get; }
        public Categoria Categoria { get; }
        public DateTime Prazo { get; }
    }
}
