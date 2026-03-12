using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace _05_04_Protegendo_subdominios_centrais.API.Identity;

public class AppUserClaimsPrincipalFactory(
    UserManager<AppUser> userManager
    , IOptions<IdentityOptions> optionsAccessor
    , IRepository<Cliente> repository)
    : UserClaimsPrincipalFactory<AppUser>(userManager, optionsAccessor)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        var cliente = await repository
            .GetFirstAsync(
            c => c.Email.Value.Equals(user.Email),
            c => c.Id);

        if (cliente is not null)
        {
            identity.AddClaim(new Claim("ClienteId", cliente.Id.ToString()));
        }

        (await UserManager.GetRolesAsync(user))
            .ToList()
            .ForEach(role => identity.AddClaim(new Claim(ClaimTypes.Role, role)));

        return identity;
    }
}