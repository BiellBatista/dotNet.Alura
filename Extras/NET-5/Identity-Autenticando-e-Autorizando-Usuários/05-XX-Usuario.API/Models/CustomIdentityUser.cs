using Microsoft.AspNetCore.Identity;
using System;

namespace _05_XX_Usuario.API.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}