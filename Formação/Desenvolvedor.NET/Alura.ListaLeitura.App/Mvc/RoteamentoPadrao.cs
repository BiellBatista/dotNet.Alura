using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context) //DefaultHandler
        {
            //rota padrão: /<Classe>Logica/Metodo

            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var metodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";

            var tipoDeUmaClasse = Type.GetType(nomeCompleto); //pegando o tipo de uma classe
            var metodos = tipoDeUmaClasse.GetMethods().Where(m => m.Name == metodo).First(); //pegando todos os método de uma classe e depois realizando uma consulta LINQ
            var requestDelegate = (RequestDelegate) Delegate.CreateDelegate(typeof(RequestDelegate), metodos);

            return requestDelegate.Invoke(context);
        }
    }
}
