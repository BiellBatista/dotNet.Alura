﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace _03_XX_Testes_Interface_Usando_Selenium.Domain.Entidades
{
    public class Agencia
    {
        [Key]
        public int Id { get; set; }

        private int _numero;

        public int Numero
        {
            get { return _numero; }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Campo número da agência não pode ser 0.");
                }
                _numero = value;
            }
        }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value.Length < 3)
                {
                    throw new FormatException("Nome da agência deve possuir pelo menos 3 caractere.");
                }
                _nome = value;
            }
        }

        private string _endereco;

        [Required]
        [MinLength(10, ErrorMessage = "Campo deve ter no mínimo 10 caracteres.")]
        public string Endereco
        {
            get { return _endereco; }
            set
            {
                if (value.Length < 10)
                {
                    throw new FormatException("Endereço deve possuir pelo menos 10 caractere.");
                }
                _endereco = value;
            }
        }

        public virtual ICollection<ContaCorrente> Contas { get; set; }
        public Guid Identificador { get; set; }

        public Agencia()
        {
            Contas = new Collection<ContaCorrente>();
        }
    }
}