namespace _01_03_Explicitando_casos_uso.API.Identity;

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