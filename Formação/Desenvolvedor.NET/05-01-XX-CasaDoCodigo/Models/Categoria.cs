﻿using System.ComponentModel.DataAnnotations;

namespace _05_01_XX_CasaDoCodigo.Models
{
    //MELHORIA: 3) Modelo agora inclui categoria
    public class Categoria : BaseModel
    {
        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        [Required]
        public string Nome { get; private set; }
    }
}
