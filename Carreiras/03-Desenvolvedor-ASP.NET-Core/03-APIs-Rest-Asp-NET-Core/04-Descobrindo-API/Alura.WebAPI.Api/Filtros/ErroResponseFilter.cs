using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alura.WebAPI.Api.Filtros
{
    //esta classe trata qualquer excecao fora do try catch
    public class ErroResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var erroResponse = ErroResponse.From(context.Exception);
            //o argumento do construtor é o erro em si
            context.Result = new ObjectResult(erroResponse) { StatusCode = 500 };
        }
    }
}
