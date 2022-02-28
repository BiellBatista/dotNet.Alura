using _05_XX_Usuario.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace _05_XX_Usuario.API.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        public readonly IConfiguration _configuration;

        public UserDbContext(IConfiguration configuration, DbContextOptions<UserDbContext> opt) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                Id = 999999,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));

            builder
                .Entity<CustomIdentityUser>()
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