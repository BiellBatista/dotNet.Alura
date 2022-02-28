using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace _04_XX_Usuario.API.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public readonly IConfiguration _configuration;

        public UserDbContext(IConfiguration configuration, DbContextOptions<UserDbContext> opt) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                Id = 999999,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));

            builder
                .Entity<IdentityUser<int>>()
                .HasData(admin);
            builder
                .Entity<IdentityRole<int>>()
                .HasData(new IdentityRole<int>
                {
                    Id = 99999,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                });
            builder
                .Entity<IdentityUserRole<int>>()
                .HasData(new IdentityUserRole<int>
                {
                    UserId = admin.Id,
                    RoleId = 99999
                });

            builder
               .Entity<IdentityRole<int>>()
               .HasData(new IdentityRole<int>
               {
                   Id = 99997,
                   Name = "regular",
                   NormalizedName = "REGULAR"
               });
        }
    }
}