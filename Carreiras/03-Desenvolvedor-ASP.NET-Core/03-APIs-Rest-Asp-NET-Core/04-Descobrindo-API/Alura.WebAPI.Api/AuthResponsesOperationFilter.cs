using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alura.WebAPI.Api
{
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Responses.Add(
                "401",
                new Response { Description = "Unauthorized" });
        }
    }
}

/**
 * Até agora documentamos uma operação de forma individual usando a anotação SwaggerOperation. Mas e quando houver situações onde a mesma documentação se aplica a todas as operações? Em nossa API temos um caso assim: toda operação que não tiver um token válido irá produzir como resposta o código 401. Imagina se tivéssemos que anotar todas as operações com [ProducesResponseType(401)]? 
 */
