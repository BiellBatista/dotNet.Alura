using Microsoft.AspNetCore.Authorization;

namespace _05_XX_Politicas_customizadas.Authorization
{
    public class IdadeMinimaRequirement : IAuthorizationRequirement
    {
        public int IdadeMinima { get; set; }

        public IdadeMinimaRequirement(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }
    }
}