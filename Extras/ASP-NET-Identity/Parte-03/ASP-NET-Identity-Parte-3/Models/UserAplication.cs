using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_Identity_Parte_3.Models
{
    /*
     * Modelo, que de fato, representa o usuário do banco de dados. O outro é para a view.
     * É necessário herdar de IdentityUser para poder usar a API Identity e definir novos campos na tabela do banco de dados
     */
    public class UserAplication : IdentityUser
    {
        public string FullName { get; set; }
    }
}