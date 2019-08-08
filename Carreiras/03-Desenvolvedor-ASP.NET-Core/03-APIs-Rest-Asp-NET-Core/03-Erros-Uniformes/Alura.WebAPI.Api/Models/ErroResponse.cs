using System;
namespace Alura.WebAPI.Api.Models
{
    public class ErroResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public ErroResponse InnerError { get; set; }

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
    }
}
