namespace _05_02_Nem_todo_contexto_ilha.Vendas.Extensions;

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