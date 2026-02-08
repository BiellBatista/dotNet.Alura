namespace _02_03_Identificando_areas_funcionais.API.Extensions;

public static class HttpContextExtensions
{
    public static Guid? GetClienteId(this HttpContext context)
    {
        var clienteId = context.User.Claims
                .Where(c => c.Type.Equals("ClienteId"))
                .Select(c => c.Value)
                .FirstOrDefault();

        return clienteId is not null
            ? Guid.Parse(clienteId)
            : null;
    }
}