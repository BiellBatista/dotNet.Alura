﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _04_XX_Separando_roles.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}