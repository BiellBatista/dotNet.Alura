using System;
using System.ComponentModel.DataAnnotations;

namespace LojaRazor.Models
{
    public class Usuario
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(3)]
        public string Senha { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        public string Endereco { get; set; }

        public string Complemento { get; set; }

        [Required, RegularExpression("\\d{5}-\\d{3}")]
        public string CEP { get; set; }

        public string Observacoes { get; set; }

        public bool RecebePromocoes { get; set; }
    }
}