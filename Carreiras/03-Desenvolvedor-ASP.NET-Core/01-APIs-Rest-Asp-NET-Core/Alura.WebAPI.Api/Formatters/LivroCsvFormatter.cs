using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Formatters
{
    //para formatar um objeto para outro tipo, devo usar a classe TextOutputFormatter
    public class LivroCsvFormatter : TextOutputFormatter
    {
        public LivroCsvFormatter()
        {
            //falando que este conversor de formato é responsável pelas solicitação que esperem um retorno csv
            var textMediaType = MediaTypeHeaderValue.Parse("text/csv");
            var apptMediaType = MediaTypeHeaderValue.Parse("application/csv");

            //adicionando os tipos de aceitação que este formato aceita
            SupportedMediaTypes.Add(textMediaType);
            SupportedMediaTypes.Add(apptMediaType);

            //adicionado o suporte do encoding
            SupportedEncodings.Add(Encoding.UTF8);
        }

        //este método indica que ele só irá aceitar negociações de CSV para objetos do tipo LivroAPI
        protected override bool CanWriteType(Type type)
        {
            return type == typeof(LivroApi);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var livroEmCsv = "";

            if (context.Object is LivroApi)
            {
                var livro = context.Object as LivroApi; //convertendo o object para um LivroApi

                livroEmCsv = $"{livro.Titulo};{livro.Subtitulo};{livro.Autor};{livro.Lista};";
            }

            //este escritor irá escrever no corpo da resposta, usando o encodign de solicitação
            using (var escritor = context.WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                return escritor.WriteAsync(livroEmCsv);
            }
        }
    }
}
