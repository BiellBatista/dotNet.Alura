using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Alura.WebAPI.Api.Models
{
    public class ErroResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public ErroResponse InnerError { get; set; }
        public string[] Detalhes { get; set; }

        public static ErroResponse From(Exception e)
        {
            if (e is null)
                return null;
            return new ErroResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerError = From(e.InnerException)
            };
        }

        public static ErroResponse FromModelState(ModelStateDictionary modelState)
        {
            //o SelectMany gera uma lista apenas do segundo nível da lista primaria
            var erros = modelState.Values.SelectMany(m => m.Errors);

            return new ErroResponse
            {
                Codigo = 100,
                Mensagem = "Houve um erro no envio da requisição",
                Detalhes = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }
    }
}
