﻿using _03_XX_Usuarios.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _03_XX_Usuarios.API.Data;

public class UsuarioDbContext : IdentityDbContext<Usuario>
{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
    {
    }
}