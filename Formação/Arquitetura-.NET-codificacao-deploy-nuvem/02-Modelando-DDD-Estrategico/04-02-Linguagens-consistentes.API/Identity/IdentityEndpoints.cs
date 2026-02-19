namespace _04_02_Linguagens_consistentes.API.Identity;

public static class IdentityEndpoints
{
    public const string TAG_IDENTITY = "Identidade e Acesso";
    public const string ENDPOINT_GROUP_ROUTE = "auth";

    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder builder)
    {
        var identityGroupEndpoints = builder.MapGroup(ENDPOINT_GROUP_ROUTE);

        identityGroupEndpoints
            .MapIdentityApi<AppUser>()
            .WithTags(TAG_IDENTITY);

        return builder;
    }
}