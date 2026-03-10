namespace _05_02_Nem_todo_contexto_ilha.API.Identity;

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