﻿using Microsoft.AspNetCore.Identity;

namespace _05_06_XX_CasaDoCodigo.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppIdentityUser class
    public class AppIdentityUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
