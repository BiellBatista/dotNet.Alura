namespace _01_XX_Configurando_projeto.API.Endpoints;

public static class EspecialidadeExtension
{
    public static void AddEndPointEspecialidades(this WebApplication app)
    {
        app.MapGet("/especialidades", async (_01_XX_Configurando_projeto.Context context) =>
        {
            return Results.Ok(await context.Especialidades.ToListAsync());
        });
    }
}