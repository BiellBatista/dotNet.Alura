﻿using _05_02_XX_CasaDoCodigo.Areas.Identity.Data;
using _05_02_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//este atributo assembly faz com que este arquivo startup seja paralelo ao original
[assembly: HostingStartup(typeof(_05_02_XX_CasaDoCodigo.Areas.Identity.IdentityHostingStartup))]
namespace _05_02_XX_CasaDoCodigo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppIdentityContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("AppIdentityContextConnection")));

                services.AddDefaultIdentity<AppIdentityUser>(options =>
                {
                    //editando as regras de validação de senha
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddErrorDescriber<IdentityErrorDescriberPtBr>()
                    .AddEntityFrameworkStores<AppIdentityContext>();
            });
        }
    }

    /**
     * Classe responsável pela mensagens de erro, devo sobrescrever tudo, porque o padrão é inglês
     */
    internal class IdentityErrorDescriberPtBr : IdentityErrorDescriber
    {
        public override IdentityError ConcurrencyFailure()
        {
            return base.ConcurrencyFailure();
        }

        public override IdentityError DefaultError()
        {
            return base.DefaultError();
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return base.DuplicateEmail(email);
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return base.DuplicateRoleName(role);
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return base.DuplicateUserName(userName);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override IdentityError InvalidEmail(string email)
        {
            return base.InvalidEmail(email);
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return base.InvalidRoleName(role);
        }

        public override IdentityError InvalidToken()
        {
            return base.InvalidToken();
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return base.InvalidUserName(userName);
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return base.LoginAlreadyAssociated();
        }

        public override IdentityError PasswordMismatch()
        {
            return base.PasswordMismatch();
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return base.PasswordRequiresDigit();
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "A senha deve ter pelo menos uma letra minúscula('a' - 'z')."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "A senha deve ter pelo menos um caractere alfanumérico."
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return base.PasswordRequiresUniqueChars(uniqueChars);
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "A senha deve ter pelo menos uma letra maiúscula('A' - 'Z')."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return base.PasswordTooShort(length);
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return base.RecoveryCodeRedemptionFailed();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return base.UserAlreadyHasPassword();
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return base.UserAlreadyInRole(role);
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return base.UserLockoutNotEnabled();
        }

        public override IdentityError UserNotInRole(string role)
        {
            return base.UserNotInRole(role);
        }
    }
}